using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OnPeople.API.Extensions.Users;
using OnPeople.Application.Services.Contracts.Users;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.API.Extensions.Pages;
using OnPeople.Application.Services.Contracts.Funcionarios;
using OnPeople.Application.Dtos.Funcionarios;
using OnPeople.Application.Services.Contracts.FuncionariosMetas;

namespace OnPeople.API.Controllers.Funcionarios;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FuncionariosController : ControllerBase
{
    private readonly IFuncionariosServices _funcionariosservices;
    private readonly IFuncionarioMetaServices _funcionarioMetaservices;
    private readonly IUsersServices _usersServices;
    public FuncionariosController(
        IFuncionariosServices funcionariosservices,
        IFuncionarioMetaServices funcionarioMetaservices,
        IUsersServices usersServices
        )
    {
        _funcionariosservices = funcionariosservices;
        _funcionarioMetaservices = funcionarioMetaservices;
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

            var funcionarios = await _funcionariosservices.GetAllFuncionarios(pageParameters, userLogged.CodEmpresa, userLogged.CodDepartamento, userLogged.CodCargo);

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

            var funcionario = await _funcionariosservices.GetFuncionarioById(funcionarioId);

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

            var createdFuncionario = await _funcionariosservices.CreateFuncionario(funcionarioDto);

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

            Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= " + funcionarioDto.Id);
            var funcionario  = await _funcionariosservices.UpdateFuncionario(id, funcionarioDto);

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

            var funcionario = await _funcionariosservices.GetFuncionarioById(funcionarioId);

            if (funcionario == null) 
                return NoContent();
 
            if (await _funcionariosservices.DeleteFuncionario(funcionarioId)){
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
    /// Associa uma meta a um funcionário
    /// </summary>
    /// <param name="funcionarioId">Identificador do funcionário</param>
    /// <param name="metaId">Identificador da meta</param>
    /// <response code="200">Associação feita com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    [HttpPost("{id}")]
    public async Task<IActionResult> AssociarMetaAFuncionario(int funcionarioId, int metaId)
    {
        try
        {
            if (await _funcionarioMetaservices.AssociarMetaAFuncionario(funcionarioId, metaId) == 1){
                return Ok( new { message = "Associação feita com sucesso!"});
            } else {
                return BadRequest("Falha na associação de meta ao funcionário.");
            }
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao associar meta a funcionário. Erro: {e.Message}");
        }
        
    } 
}
