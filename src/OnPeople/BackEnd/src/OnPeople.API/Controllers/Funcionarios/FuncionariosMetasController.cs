using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OnPeople.API.Extensions.Users;
using OnPeople.Application.Services.Contracts.Users;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.API.Extensions.Pages;
using OnPeople.Application.Services.Contracts.Funcionarios;
using OnPeople.Application.Dtos.Funcionarios;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Domain.Models.Funcionarios;

namespace OnPeople.API.Controllers.Funcionarios;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FuncionariosMetasController : ControllerBase
{
    private readonly IFuncionariosMetasServices _funcionariosMetasServices;
    private readonly IUsersServices _usersServices;
    public FuncionariosMetasController(
        IFuncionariosMetasServices funcionariosMetasServices,
        IUsersServices usersServices
        )
    {
        _funcionariosMetasServices = funcionariosMetasServices;
        _usersServices = usersServices;
    }

    /// <summary>
    /// Obtém os dados de todos os funcionários que possuem uma mesma meta
    /// </summary>
    /// <param name="metaId">Identificador da meta</param>
    /// <response code="200">Dados dos funcionários/meta cadastrados</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpGet("{metaId}/funcionarios")]
    public async Task<IActionResult> GetAllFuncionariosByMetaIdAsync(int metaId)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            if (claimUser == null) 
               return Unauthorized();

            var funcionariosMeta = await _funcionariosMetasServices.GetAllFuncionariosByMetaIdAsync(metaId);

            if (funcionariosMeta == null) return NotFound("Nenhum funcionário/meta foi encontrado.");

            return Ok(funcionariosMeta);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar funcionários. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Obtém os dados de todos os funcionários que possuem uma mesma meta
    /// </summary>
    /// <param name="funcionarioId">Identificador do funcionario</param>
    /// <response code="200">Dados dos metas/funcionario cadastrados</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpGet("{funcionarioId}/metas")]
    public async Task<IActionResult> GetAllMetasByFuncioanrioIdAsync(int funcionarioId)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            if (claimUser == null) 
               return Unauthorized();

            var metasFuncionario = await _funcionariosMetasServices.GetAllMetasByFuncionarioIdAsync(funcionarioId);

            if (metasFuncionario == null) return NotFound("Nenhum meta/funcionario foi encontrado.");

            return Ok(metasFuncionario);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar funcionários. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Realiza a inclusão de um novo funcionário
    /// </summary>
    /// <response code="200">Funcionário cadastrado com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpPost]
    public async Task<IActionResult> CreateFuncionario(FuncionarioMetaDto funcionarioMetaDto)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            var createdFuncionarioMeta = await _funcionariosMetasServices.CreateFuncionarioMeta(funcionarioMetaDto);

            if (createdFuncionarioMeta != null) return Ok(createdFuncionarioMeta);

            return BadRequest("Não foi possível cadastrar o funcionário/Meta.");
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adiconar funcionário. Erro: {e.Message}");
        }
    }    
    
    /// <summary>
    /// Realiza a atualização dos dados de um funcionário
    /// </summary>
    /// <param name="id">Identificador do funcionário</param>
    /// <param name="funcionarioDto">Dados de funcionário</param>
    /// <response code="200">Funcionário atualizado com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFuncionarioMeta(int id, FuncionarioMetaDto funcionarioDto)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            var funcionarioMeta  = await _funcionariosMetasServices.UpdateFuncionarioMeta(id, funcionarioDto);

            if (funcionarioMeta == null) return NoContent();

            return Ok(funcionarioMeta);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar funcionário. Erro: {e.Message}");
        }
    }      
    
    /// <summary>
    /// Realiza a exclusão de um funcionário
    /// </summary>
    /// <param name="funcionarioMetaId">Identificador do funcionário/Meta</param>
    /// <response code="200">Funcionário excluído com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFuncionarioMeta(int funcionarioMetaId)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            var funcionarioMeta = await _funcionariosMetasServices.GetFuncionarioMetaByIdAsync(funcionarioMetaId);

            if (funcionarioMeta == null) 
                return NoContent();
 
            if (await _funcionariosMetasServices.DeleteFuncionarioMeta(funcionarioMetaId)){
                return Ok( new { message = "Funcionário/Meta excluído com sucesso!"});
            } else {
                return BadRequest("Falha na exclusão do funcionário.");
            }
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir funcionário. Erro: {e.Message}");
        }
        
    }   

    /// <summary>
    /// Realiza a consulta estatística de funcionários/metas
    /// </summary>
    /// <param name="empresaId">Identificador da empresa (pode zero para buscar todas)</param>
    /// <param name="departamentoId">Identificador de departamento</param>
    /// <param name="metaId">Identificador de metas</param>
    /// <param name="funcionarioId">Identificador de funcionario</param>
    /// <response code="200">Dashboard de funcionarios consultado</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
    [HttpGet("{funcionarioId}/{metaId}/dashboard")]
    public DashboardFuncionariosMetas GetDashboard(int funcionarioId, int metaId)
    {     
        var dashboardFuncionariosMetas = _funcionariosMetasServices.GetDashboard(funcionarioId, metaId);

        return dashboardFuncionariosMetas;
    }    
}

