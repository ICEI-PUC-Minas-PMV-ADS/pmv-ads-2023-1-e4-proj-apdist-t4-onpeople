using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OnPeople.API.Extensions.Users;
using OnPeople.Application.Services.Contracts.Users;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.API.Extensions.Pages;
using OnPeople.Application.Services.Contracts.Funcionarios;
using OnPeople.Application.Dtos.Funcionarios;
using OnPeople.Integration.Models.Dashboard;

namespace OnPeople.API.Controllers.Funcionarios;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FuncionariosController : ControllerBase
{
    private readonly IFuncionariosServices _funcionariosServices;
    private readonly IUsersServices _usersServices;
    public FuncionariosController(
        IFuncionariosServices funcionariosservices,
        IUsersServices usersServices
        )
    {
        _funcionariosServices = funcionariosservices;
        _usersServices = usersServices;
    }

    /// <summary>
    /// Obtém os dados de todos os funcionários cadastrados
    /// </summary>
    /// <response code="200">Dados dos funcionários cadastrados</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpGet]
    public async Task<IActionResult> GetAllFuncionarios([FromQuery]PageParameters pageParameters)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            if (claimUser == null) 
               return Unauthorized();


            var userLogged = await _usersServices.GetUserByUserNameAsync(User.GetUserNameClaim());

            if (userLogged == null)
                return Unauthorized();

            var funcionarios = await _funcionariosServices.GetAllFuncionarios(pageParameters, userLogged.CodEmpresa, userLogged.CodDepartamento, userLogged.CodCargo, userLogged.CodFuncionario);

            if (funcionarios == null) return NotFound("Nenhum funcionário foi encontrado.");
            
            
            Response.CreatePagination(funcionarios.CurrentPage, funcionarios.PageSize, funcionarios.TotalCounter, funcionarios.TotalPages);

            return Ok(funcionarios);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar funcionários. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Obtém os dados de um funcionário específico
    /// </summary>
    /// <param name="funcionarioId">Identificador do departamento</param>
    /// <response code="200">Dados do departamento consultado</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpGet("{funcionarioId}")]
    public async Task<IActionResult> GetFuncionarioById(int funcionarioId)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());
            
            if (claimUser == null) 
                return Unauthorized();

            var funcionario = await _funcionariosServices.GetFuncionarioById(funcionarioId);

            if (funcionario == null) return NotFound("Funcionário não encontrado.");

            return Ok(funcionario);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar funcionário por Id. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Realiza a inclusão de um novo funcionário
    /// </summary>
    /// <response code="200">Funcionário cadastrado com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpPost]
    public async Task<IActionResult> CreateFuncionario(CreateFuncionarioDto funcionarioDto)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            if (!claimUser.Master)
                return Unauthorized();

            var createdFuncionario = await _funcionariosServices.CreateFuncionario(funcionarioDto);

            if (createdFuncionario != null) return Ok(createdFuncionario);

            return BadRequest("Não foi possível cadastrar o funcionário.");
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
    public async Task<IActionResult> UpdateFuncionario(int id, UpdateFuncionarioDto funcionarioDto)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            if (funcionarioDto.Id != id)
                return Unauthorized();

            var funcionario  = await _funcionariosServices.UpdateFuncionario(id, funcionarioDto);

            if (funcionario == null) return NoContent();

            return Ok(funcionario);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar funcionário. Erro: {e.Message}");
        }
    }      
    
    /// <summary>
    /// Realiza a exclusão de um funcionário
    /// </summary>
    /// <param name="funcionarioId">Identificador do funcionário</param>
    /// <response code="200">Funcionário excluído com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFuncionario(int funcionarioId)
    {
        try
        {
            //  var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            // if (claimUser == null) 
            //     return Unauthorized();

            // if (!claimUser.Master)
            //     return Unauthorized();

            var funcionario = await _funcionariosServices.GetFuncionarioById(funcionarioId);

            if (funcionario == null) 
                return NoContent();
 
            if (await _funcionariosServices.DeleteFuncionario(funcionarioId)){
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
   /// <summary>
    /// Obtém os dados de funcionários na funcao de diretor, supervisor e gerente
    /// </summary>
    /// <param name="departamentoId">Identificador do departamento</param>
    /// <response code="200">Dados do funcionarios consultado</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpGet("{departamentoId}/chefes")]
    public async Task<IActionResult> GetFuncionariosChefesBydepartamentoId(int departamentoId)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());
            
            if (claimUser == null) 
                return Unauthorized();

            var funcionario = await _funcionariosServices.GetFuncionariosChefesByDepartamentoId(departamentoId);

            if (funcionario == null) return NotFound("Funcionário não encontrado.");

            return Ok(funcionario);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar funcionário por Id. Erro: {e.Message}");
        }
    }
 
     /// <summary>
    /// Obtém os dados de todos os funcionários de um cargo determinado
    /// </summary>
    /// <param name="cargoId">Identificador do cargo</param>
    /// <response code="200">Dados do funcionarios consultado</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpGet("{cargoId}/cargo")]
    public async Task<IActionResult> GetFuncionarioByCargoId(int cargoId)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());
            
            if (claimUser == null) 
                return Unauthorized();

            var funcionario = await _funcionariosServices.GetFuncionariosByCargoId(cargoId);

            if (funcionario == null) return NotFound("Funcionários não encontrado.");

            return Ok(funcionario);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar funcionário por Id. Erro: {e.Message}");
        }
    }
    /// <summary>
    /// Realiza a consulta estatística de funcionários
    /// </summary>
    /// <param name="empresaId">Identificador de empresa</param>
    /// <param name="departamentoId">Identificador de departamento</param>
    /// <param name="cargoId">Identificador de cargo</param>
    /// <param name="funcionarioId">Identificador de funcionario</param>
    /// <response code="200">Dashboard de funcionarios consultado</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
    [HttpGet("{empresaId}/{departamentoId}/{cargoId}/{funcionarioId}/DashboardFuncionarios")]
    public Task<DashboardFuncionarios> GetDashboardFuncionarios(int empresaId, int departamentoId, int cargoId, int funcionarioId)
    {     
        var dashboardFuncionarios = _funcionariosServices.GetDashboardFuncionario(empresaId, departamentoId, cargoId, funcionarioId);
        return dashboardFuncionarios;
    }   

    /// <summary>
    /// Realiza a consulta estatística de metas por funcionários
    /// </summary>
    /// <param name="empresaId">Identificador de empresa</param>
    /// <param name="departamentoId">Identificador de departamento</param>
    /// <param name="cargoId">Identificador de cargo</param>
    /// <param name="funcionarioId">Identificador de funcionario</param>
    /// <response code="200">Dashboard de funcionarios consultado</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
    [HttpGet("{empresaId}/{departamentoId}/{cargoId}/{funcionarioId}/DashboardFuncionarioMetas")]
    public Task<List<ListaMetas>> GetDashboardFuncionarioMetas(int empresaId, int departamentoId, int cargoId, int funcionarioId)
    {     
        var listaMetas = _funcionariosServices.GetDashboardFuncionarioMetas(empresaId, departamentoId, cargoId, funcionarioId);

        return listaMetas;
    }    
    /// <summary>
    /// Realiza a consulta estatística de metas
    /// </summary>
    /// <param name="empresaId">Identificador de empresa</param>
    /// <param name="departamentoId">Identificador de departamento</param>
    /// <param name="cargoId">Identificador de cargo</param>
    /// <param name="funcionarioId">Identificador de funcionario</param>
    /// <response code="200">Dashboard de funcionarios consultado</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
    [HttpGet("{empresaId}/{departamentoId}/{cargoId}/{funcionarioId}/DashboardMetas")]
    public Task<DashboardFuncionariosMetas> GetDashboardMetas(int empresaId, int departamentoId, int cargoId, int funcionarioId)
    {     
        var dashboardMetas = _funcionariosServices.GetDashboardMetas(empresaId, departamentoId, cargoId, funcionarioId);
        return dashboardMetas;
    }  
}

