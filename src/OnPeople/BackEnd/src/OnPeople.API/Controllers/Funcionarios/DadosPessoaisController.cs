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
public class DadosPessoaisController : ControllerBase
{
    private readonly IDadosPessoaisServices _dadosPessoaisServices;
    private readonly IUsersServices _usersServices;
    public DadosPessoaisController(
        IDadosPessoaisServices dadosPessoaisServices,
        IUsersServices usersServices
        )
    {
        _dadosPessoaisServices = dadosPessoaisServices;
        _usersServices = usersServices;
    }

    /// <summary>
    /// Obtém os dados de todos os Dados Pessoais cadastrados
    /// </summary>
    /// <response code="200">Dados Pessoais cadastrados</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpGet]
    public async Task<IActionResult> GetAllDadosPessoais()
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            if (claimUser == null) 
               return Unauthorized();


            var userLogged = await _usersServices.GetUserByUserNameAsync(User.GetUserNameClaim());

            if (userLogged == null)
                return Unauthorized();

            var dadosPessoais = await _dadosPessoaisServices.GetAllDadosPessoais();

            if (dadosPessoais == null) return NotFound("Nenhum dado pessoal foi encontrado.");
            
            return Ok(dadosPessoais);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar dados pessoais. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Obtém os dados de todos os Dados Pessoais cadastrados
    /// </summary>
    /// <param name="funcionarioId">Identificador do funcionário</param>
    /// <response code="200">Dados Pessoais cadastrados</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpGet("{funcionarioId}/funcionario")]
    public async Task<IActionResult> GetAllDadosPessoaisByFuncionarioId(int funcionarioId)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            if (claimUser == null) 
               return Unauthorized();


            var userLogged = await _usersServices.GetUserByUserNameAsync(User.GetUserNameClaim());

            if (userLogged == null)
                return Unauthorized();

            var dadosPessoais = await _dadosPessoaisServices.GetAllDadosPessoaisByFuncionarioId(funcionarioId);

            if (dadosPessoais == null) return NotFound("Nenhum dado pessoal foi encontrado.");
            
            return Ok(dadosPessoais);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar dados pessoais. Erro: {e.Message}");
        }
    }
    /// <summary>
    /// Obtém os Dados Pessoais específico
    /// </summary>
    /// <param name="dadoPessoalId">Identificador do departamento</param>
    /// <response code="200">Dados Pessoais consultado</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpGet("{dadoPessoal}")]
    public async Task<IActionResult> GetDadoPessoalById(int dadoPessoalId)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());
            
            if (claimUser == null) 
                return Unauthorized();

            var dadoPessoal = await _dadosPessoaisServices.GetDadoPessoalById(dadoPessoalId);

            if (dadoPessoal == null) return NotFound("Dados Pessoais não encontrado.");

            return Ok(dadoPessoal);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar funcionário por Id. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Realiza a inclusão de um novo Dados Pessoais
    /// </summary>
    /// <response code="200">Dados Pessoais cadastrado com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpPost]
    public async Task<IActionResult> CreateDadoPessoal(DadoPessoalDto dadoPessoal)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            if (!claimUser.Master)
                return Unauthorized();

            var createdDadoPessoal = await _dadosPessoaisServices.CreateDadoPessoal(dadoPessoal);

            if (createdDadoPessoal != null) return Ok(createdDadoPessoal);

            return BadRequest("Não foi possível cadastrar o Dados Pessoais.");
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adiconar Dados Pessoais. Erro: {e.Message}");
        }
    }    
    
    /// <summary>
    /// Realiza a atualização dos dados de um Dados Pessoais
    /// </summary>
    /// <param name="dadoPessoalId">Identificador do Dados Pessoais</param>
    /// <param name="dadoPessoalDto">Dados de funcionário</param>
    /// <response code="200">Funcionário atualizado com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpPut("{dadoPessoalId}")]
    public async Task<IActionResult> UpdateDadoPessoal(int dadoPessoalId, DadoPessoalDto dadoPessoalDto)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            if (!claimUser.Master)
                return Unauthorized();

            if (dadoPessoalDto.Id != dadoPessoalId)
                return Unauthorized();

            var dadoPessoal  = await _dadosPessoaisServices.UpdateDadoPessoal(dadoPessoalId, dadoPessoalDto);

            if (dadoPessoal == null) return NoContent();

            return Ok(dadoPessoal);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar dado Pessoal. Erro: {e.Message}");
        }
    }      
    
    /// <summary>
    /// Realiza a exclusão de um Dados Pessoais
    /// </summary>
    /// <param name="dadoPessoalId">Identificador do Dados Pessoais</param>
    /// <response code="200">Funcionário excluído com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpDelete("{dadoPessoalId}")]
    public async Task<IActionResult> DeleteDadoPessoal(int dadoPessoalId)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                 return Unauthorized();

            if (!claimUser.Master)
                return Unauthorized();

            var dadoPessoal = await _dadosPessoaisServices.GetDadoPessoalById(dadoPessoalId);

            if (dadoPessoal == null) 
                return NoContent();
 
            if (await _dadosPessoaisServices.DeleteDadoPessoal(dadoPessoalId)){
                return Ok( new { message = "Funcionário excluído com sucesso!"});
            } else {
                return BadRequest("Falha na exclusão do funcionário.");
            }
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir Dados Pessoais. Erro: {e.Message}");
        }
        
    }   

}
