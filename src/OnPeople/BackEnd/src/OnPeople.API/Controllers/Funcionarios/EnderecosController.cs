using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OnPeople.API.Extensions.Users;
using OnPeople.Application.Services.Contracts.Users;
using OnPeople.Application.Services.Contracts.Funcionarios;
using OnPeople.Application.Dtos.Funcionarios;


namespace OnPeople.API.Controllers.Funcionarios;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EnderecosController : ControllerBase
{
    private readonly IEnderecosServices _enderecosServices;
    private readonly IUsersServices _usersServices;
    public EnderecosController(
        IEnderecosServices funcionariosservices,
        IUsersServices usersServices
        )
    {
        _enderecosServices = funcionariosservices;
        _usersServices = usersServices;
    }

    /// <summary>
    /// Obtém os dados de todos os endereços cadastrados por funcionario
    /// </summary>
    /// <response code="200">Dados dos endereços cadastrados</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpGet]
    public async Task<IActionResult> GetAllEnderecos()
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            if (claimUser == null) 
               return Unauthorized();


            var userLogged = await _usersServices.GetUserByUserNameAsync(User.GetUserNameClaim());

            if (userLogged == null)
                return Unauthorized();

            var enderecos = await _enderecosServices.GetAllEnderecos();

            if (enderecos == null) return NotFound("Nenhum endereço foi encontrado.");
                        
            return Ok(enderecos);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar endereços. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Obtém os dados de todos os endereços cadastrados para um funcionario
    /// </summary>
    /// <param name="funcionarioId">Identificador do funcionário</param>
    /// <response code="200">Dados dos endereços cadastrados</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpGet("{funcionarioId}/funcionario")]
    public async Task<IActionResult> GetAllEnderecosByFuncionarioId(int funcionarioId)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            if (claimUser == null) 
               return Unauthorized();


            var userLogged = await _usersServices.GetUserByUserNameAsync(User.GetUserNameClaim());

            if (userLogged == null)
                return Unauthorized();

            var enderecos = await _enderecosServices.GetAllEnderecosByFuncionarioId(funcionarioId);

            if (enderecos == null) return NotFound("Nenhum endereço foi encontrado.");
                        
            return Ok(enderecos);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar endereços. Erro: {e.Message}");
        }
    }
    /// <summary>
    /// Obtém os dados de um endereço específico
    /// </summary>
    /// <param name="enderecoId">Identificador do endereco</param>
    /// <response code="200">Dados do endereço consultado</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpGet("{enderecoId}")]
    public async Task<IActionResult> GetEnderecoById(int enderecoId)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());
            
            if (claimUser == null) 
                return Unauthorized();

            var endereco = await _enderecosServices.GetEnderecoById(enderecoId);

            if (endereco == null) return NotFound("Edereço não encontrado.");

            return Ok(endereco);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar endereço por Id. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Realiza a inclusão de um novo endereço
    /// </summary>
    /// <response code="200">Endereço cadastrado com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpPost]
    public async Task<IActionResult> CreateEndereco(EnderecoDto enderecoDto)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            if (!claimUser.Master)
                return Unauthorized();

            Console.WriteLine("---------------------------------- funcionario Id" + enderecoDto.FuncionarioId);
            var createdEndereco = await _enderecosServices.CreateEndereco(enderecoDto);

            if (createdEndereco != null) return Ok(createdEndereco);

            return BadRequest("Não foi possível cadastrar o endereço.");
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adiconar funcionário. Erro: {e.Message}");
        }
    }    
    
    /// <summary>
    /// Realiza a atualização dos dados de um endereço
    /// </summary>
    /// <param name="enderecoId">Identificador do endereço</param>
    /// <param name="enderecoDto">Dados de funcionário</param>
    /// <response code="200">Funcionário atualizado com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEndereco(int enderecoId, EnderecoDto enderecoDto)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            if (!claimUser.Master)
                return Unauthorized();

            if (enderecoDto.Id != enderecoId)
                return Unauthorized();

            var funcionario  = await _enderecosServices.UpdateEndereco(enderecoId, enderecoDto);

            if (funcionario == null) return NoContent();

            return Ok(funcionario);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar funcionário. Erro: {e.Message}");
        }
    }      
    
    /// <summary>
    /// Realiza a exclusão de um endereço
    /// </summary>
    /// <param name="enderecoId">Identificador do endereço</param>
    /// <response code="200">endereço excluído com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEndereco(int enderecoId)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                 return Unauthorized();

            var funcionario = await _enderecosServices.GetEnderecoById(enderecoId);

            if (funcionario == null) 
                return NoContent();
 
            if (await _enderecosServices.DeleteEndereco(enderecoId)){
                return Ok( new { message = "Funcionário excluído com sucesso!"});
            } else {
                return BadRequest("Falha na exclusão do funcionário.");
            }
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir funcionário. Erro: {e.Message}");
        }       
    }   

}
