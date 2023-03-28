using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnPeople.API.Extensions.Users;
using OnPeople.Application.Dtos.Users;
using OnPeople.Application.Services.Contracts.Empresas;
using OnPeople.Application.Services.Contracts.Users;

namespace OnPeople.API.Controllers.Users;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IEmpresasServices _empresasServices;
    private readonly IUsersServices _usersServices;
    private readonly ITokenServices _tokenServices;

    public UsersController(
        IEmpresasServices empresasServices,
        IUsersServices usersServices,
        ITokenServices tokenServices
        )
    {
        _empresasServices = empresasServices;
        _usersServices = usersServices;
        _tokenServices = tokenServices;
    }

    [HttpGet("GetUserName")]
    public async Task<IActionResult> GetUserByUserName()
    {
        try
        {
            var claimUserName = User.GetUserNameClaim();
            
           if (claimUserName == null)
                return Unauthorized();

            var user = await _usersServices.GetUserByUserNameAsync(claimUserName);

            if (user == null) return NoContent();

            return Ok(user);
        }
        catch (Exception e)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar conta. Erro: {e.Message}");
        }
    }

    [HttpPost("CreateAccount")]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAccount(UserDto userDto)
    {
        try
        {        
            if (await _usersServices.VerifyUserExistsAsync(userDto.UserName)) {
               return BadRequest("Conta já cadastrada!");
            }

            var user = await _usersServices.CreateUsersAsync(userDto);

            var nomeEmpresa = "";
         
            if (user != null) {
                return Ok( new {
                    userName = user.UserName,
                    nomeCompleto = user.NomeCompleto,
                    id = user.Id,
                    visao = user.Visao,
                    nomeEmpresa = nomeEmpresa,
                    token = _tokenServices.CreateToken(user).Result
                });
            };

            return  BadRequest("Conta não cadastrada!");
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao cadastrar conta. Erro: {e.Message}");
        }
    } 

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(UserLoginDto userLoginDto)
    {
        try
        {
            Console.WriteLine("user: " + userLoginDto);
            var user  = await _usersServices.GetUserByUserNameAsync(userLoginDto.UserName);
            if (user == null) {
                return Unauthorized("Conta não cadastrada" );
            }

            var userValidation = await _usersServices.CheckUserPasswordAsync(user, userLoginDto.Password);

            if (!userValidation.Succeeded) {
                return Unauthorized("Conta ou Senha inválidos");
            }

            var nomeEmpresa = "";
           
            if (user.CodEmpresa > 0) {
                var empresa = await _empresasServices.GetEmpresaByIdAsync(user.CodEmpresa);
            
                if (empresa != null)
                    nomeEmpresa = empresa.RazaoSocial;
            }

            return Ok( new {
                    userName = user.UserName,
                    nomeCompleto = user.NomeCompleto,
                    id = user.Id,
                    visao = user.Visao,
                    nomeEmpresa = nomeEmpresa,
                    token = _tokenServices.CreateToken(user).Result
                });
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao realizar Login. Erro: {e.Message}");
        }
    }   
    [HttpGet("GetUser/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            if (claimUser == null) 
                return Unauthorized();

            if (!claimUser.Master && !claimUser.Gold)
                return Unauthorized();

            var user = await _usersServices.GetUserByIdAsync(id);

            if (!claimUser.Master && !claimUser.Gold)
                if (user == null || claimUser.Id != user.Id)
                    return Unauthorized();

            if (user == null) return NoContent();

            return Ok(user);
        }
        catch (Exception e)
        {      
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar conta por Id. Erro: {e.Message}");
        }
    }

    [HttpPut("UpdateUser")]
    public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            if (claimUser == null) 
                return Unauthorized();

            if (userUpdateDto.UserName != claimUser.UserName) {
                return Unauthorized("Conta inválida para atualização.");
            } 
                
            var user = await _usersServices.GetUserByUserNameAsync(claimUser.UserName);

            if (user == null || (userUpdateDto.Id != user.Id))
                return Unauthorized("Conta inválida para atualização.");

            var userChanged = await _usersServices.UpdateUserTokenAsync(userUpdateDto);

            if (userChanged == null) {
                return NoContent();
            }

            return Ok( new {
                    userName = user.UserName,
                    nomeCompleto = user.NomeCompleto,
                    id = user.Id,
                    visao = user.Visao,
                    token = _tokenServices.CreateToken(user).Result
            });

        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar a conta. Erro: {e.Message}");
        }
    }

    [HttpPut("UpdateVisao")]
    public async Task<IActionResult> UpdateVisao(UserVisaoDto userVisaoDto)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            if (claimUser == null) 
                return Unauthorized();

            if (!claimUser.Master && !claimUser.Gold)
                return Unauthorized();

            if (userVisaoDto.UserName != claimUser.UserName) 
                return Unauthorized("Conta inválida para atualização.");

            if (userVisaoDto.Id != claimUser.Id)
                return Unauthorized("Conta inválida para atualização.");

            var userChanged = await _usersServices.UpdateUserVisaoAsync(userVisaoDto);

            if (userChanged == null) {
                return NoContent();
            }

            return Ok( userChanged);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar a conta. Erro: {e.Message}");
        }
    }

    
    [HttpGet("GetUserNameVisao")]
    public async Task<IActionResult> GetVisaoByUserName()
    {
        try
        {
            var claimUserName = User.GetUserNameClaim();
            
           if (claimUserName == null)
                return Unauthorized();

            var user = await _usersServices.GetVisaoByUserNameAsync(claimUserName);

            if (user == null) return NoContent();

            return Ok(user);
        }
        catch (Exception e)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar conta. Erro: {e.Message}");
        }
    }      
}
