using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnPeople.API.Extensions.Users;
using OnPeople.Application.Dtos.Users;
using OnPeople.Application.Services.Contracts.Users;

namespace OnPeople.API.Controllers.Users;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersServices _usersServices;
    private readonly ITokenServices _tokenServices;

    public UsersController(
        IUsersServices usersServices,
        ITokenServices tokenServices
        )
    {
        _usersServices = usersServices;
        _tokenServices = tokenServices;
    }

    [HttpGet("GetUserName")]
    public async Task<IActionResult> GetUserByUserName()
    {
        try
        {
            Console.WriteLine(User.GetUserIdClaim());
            var userName = User.GetUserNameClaim();

            var users = await _usersServices.GetUserByUserNameAsync(userName);

            if (users == null) return NoContent();

            return Ok(users);
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

            if (user != null) {
                return Ok( new {
                    userName = user.UserName,
                    nomeCompleto = user.NomeCompleto,
                    id = user.Id,
                    visao = user.Visao,
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
            var user  = await _usersServices.GetUserByUserNameAsync(userLoginDto.UserName);
            if (user == null) {
                return Unauthorized("Conta não cadastrada" );
            }

            var userValidation = await _usersServices.CheckUserPasswordAsync(user, userLoginDto.Password);

            if (!userValidation.Succeeded) {
                return Unauthorized("Conta ou Senha inválidos");
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
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao realizar Login. Erro: {e.Message}");
        }
    }   
    [HttpGet("GetUSer/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        try
        {
            var user = await _usersServices.GetUserByIdAsync(id);

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
            var userNameClaim = User.GetUserNameClaim();

            if (userUpdateDto.UserName != userNameClaim) {
                return Unauthorized("Conta inválida para atualização.");
            } 
                
            var user = await _usersServices.GetUserByUserNameAsync(userNameClaim);

            if (user == null || (userUpdateDto.Id != user.Id))
            {
                return Unauthorized("Conta inválida.");
            } 

            var userChanged = await _usersServices.UpdateUserTokenAsync(userUpdateDto);

            Console.WriteLine("=-=-=-=-=-=-=-=-=-Changed " + userChanged.UserName + " =-= " + (userChanged == null) );
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
            var userNameClaim = User.GetUserNameClaim();


            if (userVisaoDto.UserName != userNameClaim) {
                return Unauthorized("Conta inválida para atualização.");
            } 
                
            var user = await _usersServices.GetUserByUserNameAsync(userNameClaim);

            if (user == null || userVisaoDto.Id != user.Id) 
            {
                return Unauthorized("Conta inválida.");
            } 

            var userChanged = await _usersServices.UpdateUserVisaoAsync(userVisaoDto);
            Console.WriteLine("=-=-=-=-=-=-=-=-=-VISAO " + userVisaoDto.Id + " =-= " +user.Id );

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
}
