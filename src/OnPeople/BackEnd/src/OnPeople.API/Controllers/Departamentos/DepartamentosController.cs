using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnPeople.API.Extensions.Pages;
using OnPeople.API.Extensions.Users;
using OnPeople.Application.Dtos.Departamentos;
using OnPeople.Application.Services.Contracts.Departamentos;
using OnPeople.Application.Services.Contracts.Users;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;

namespace OnPeople.API.Controllers.Departamentos;

[Authorize]
[ApiController]
[Route("api/[controller]")]

public class DepartamentosController : ControllerBase
{
    private readonly IDepartamentosServices _departamentosServices;
    private readonly IUsersServices _usersServices;

    public DepartamentosController(
        IDepartamentosServices departamentosServices,
        IUsersServices usersServices)
    {
        _departamentosServices = departamentosServices;
        _usersServices = usersServices;
    }

    /// <summary>
    /// Obtém os dados de um departamento específico
    /// </summary>
    /// <param name="departamentoId">Identificador do departamento</param>
    /// <response code="200">Dados do departamento consultado</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
    [HttpGet("{departamentoId}")]
    public async Task<IActionResult> GetDepartamentoById(int departamentoId)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            if (claimUser == null) 
                return Unauthorized();

            var userLogged = await _usersServices.GetUserByUserNameAsync(User.GetUserNameClaim());

            if (userLogged == null)
                return Unauthorized();

            var departamento = await _departamentosServices.GetDepartamentoByIdAsync(departamentoId);

            if (departamento == null) return NotFound("Departamento não encontrado.");

            return Ok(departamento);
        }
        catch (Exception e)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar o departamento. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Obtém os dados de todos os departamentos cadastrados para uma determinada empresa, se a empresaId for informada como 0 (zero) será consultado o departamento de todas as empresas cadastradas
    /// </summary>
    /// <param name="pageParameters">Configuração de inicio e fim de páginas para paginação</param>
    /// <response code="200">Dados dos departamentos cadastrados para a empresa</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
    [HttpGet]
    public async Task<IActionResult> GetAllDepartamentos([FromQuery]PageParameters pageParameters)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            if (claimUser == null) 
                return Unauthorized();

            var userLogged = await _usersServices.GetUserByUserNameAsync(User.GetUserNameClaim());

            if (userLogged == null)
                return Unauthorized();

            var departamentos = await _departamentosServices.GetAllDepartamentosAsync(pageParameters, userLogged.CodEmpresa, userLogged.Master);

            if (departamentos == null) return NotFound("A empresa informada não possui departamentos cadastrados.");

            Response.CreatePagination(departamentos.CurrentPage, departamentos.PageSize, departamentos.TotalCounter, departamentos.TotalPages);

            return Ok(departamentos);
        }
        catch (Exception e)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar os departamentos. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Obtém os dados de todos os departamentos cadastrados para uma determinada empresa
    /// </summary>
    /// <param name="empresaId">Empresa para pesquisa</param>
    /// <response code="200">Dados dos departamentos cadastrados para a empresa</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
    [HttpGet("{empresaId}/departamentos")]
    public async Task<IActionResult> GetAllDepartamentosByEmpresaId(int empresaId)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            if (claimUser == null) 
                return Unauthorized();

            var departamentos = await _departamentosServices.GetAllDepartamentosByEmpresaIdAsync(empresaId);

            if (departamentos == null) return NotFound("A empresa informada não possui departamentos cadastrados.");

            return Ok(departamentos);
        }
        catch (Exception e)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar os departamentos. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Realiza a inclusão de um novo departamento
    /// </summary>
    /// <response code="200">Departamento cadastrado com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
    [HttpPost]
    public async Task<IActionResult> CreateDepartamento(DepartamentoDto departamentoDto)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            if (!claimUser.Master)
                return Unauthorized();
                
            var createdDepartamento = await _departamentosServices.CreateDepartamentos(departamentoDto);

            if (createdDepartamento != null) return Ok(createdDepartamento);

            return BadRequest("Não foi possível cadastrar o departamento.");
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao cadastrar o departamento. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Realiza a atualização dos dados de um departamento
    /// </summary>
    /// <param name="departamentoId">Identificador do departamento</param>
    /// <param name="departamentoDto">Departamentos Cadastradps</param>
    /// <response code="200">Departamento atualizado com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>

    [HttpPut("{departamentoId}")]
    public async Task<IActionResult> UpdateDepartamento(int departamentoId, DepartamentoDto departamentoDto)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            if (!claimUser.Master)
                return Unauthorized();

            if (departamentoDto.Id != departamentoId)
                return Unauthorized();

            var departamento = await _departamentosServices.UpdateDepartamento(departamentoId, departamentoDto);

            if (departamento == null) return BadRequest("O departamento informado não existe.");

            return Ok(departamento);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar os dados do departamento. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Realiza a exclusão de um departamento
    /// </summary>
    /// <param name="departamentoId">Identificador do departamento</param>
    /// <response code="200">Departamento excluído com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
    [HttpDelete("{departamentoId}")]
    public async Task<IActionResult> DeleteDepartamento(int departamentoId)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            if (claimUser == null) 
                return Unauthorized();

            var userLogged = await _usersServices.GetUserByUserNameAsync(User.GetUserNameClaim());

            if (userLogged == null)
                return Unauthorized();

            var departamento = await _departamentosServices.GetDepartamentoByIdAsync(departamentoId);

            if (departamento.Ativo) return BadRequest("Departamentos ativos não podem ser excluídos. Inative o departamento e tente novamente.");

            if (await _departamentosServices.DeleteDepartamento(departamentoId))
            {
                return Ok(("Departamento excluído com sucesso"));
            }
            else
            {
                return BadRequest("Não foi possível excluir o departamento.");
            }
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir o departamento. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Realiza a consulta estatística de departamento
    /// </summary>
    /// <param name="empresaId">Identificador da empresa (pode zero para buscar todas)</param>
    /// <response code="200">Dashboard de empresas consultado</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
    [HttpGet("{empresaId}/DashboardDepartamentos")]
    public Task<DashboardDepartamento> GetDashboardDepartamento(int empresaId)
    {     
        var dashboardDepartamento = _departamentosServices.GetDashboardDepartamento(empresaId, User.GetMasterClaim());

        return dashboardDepartamento;
    }

    /// <summary>
    /// Realiza a consulta estatística de metas por departamento
    /// </summary>
    /// <param name="empresaId">Identificador da empresa (pode zero para buscar todas)</param>
    /// <response code="200">Dashboard de empresas consultado</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
    [HttpGet("{empresaId}/DashboardDepartamentoMetas")]
    public Task<List<ListaMetas>> GetDashboardDepartamentoMetas(int empresaId)
    {     
        var listaMetas = _departamentosServices.GetDashboardDepartamentoMetas(empresaId, User.GetMasterClaim());

        return listaMetas;
    }
}
