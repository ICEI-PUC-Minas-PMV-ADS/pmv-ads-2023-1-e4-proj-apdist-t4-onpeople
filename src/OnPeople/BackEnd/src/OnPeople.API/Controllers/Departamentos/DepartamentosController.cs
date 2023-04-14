using Microsoft.AspNetCore.Mvc;
using OnPeople.Application.Services.Contracts.Departamentos;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Application.Services.Contracts.Empresas;
using OnPeople.Application.Dtos.Departamentos;

namespace OnPeople.API.Controllers.Departamentos;

[ApiController]
[Route("api/[controller]")]

public class DepartamentosController : ControllerBase
{
    private readonly IDepartamentosServices _departamentosServices;
   

    public DepartamentosController(IDepartamentosServices departamentosServices)
    {
        _departamentosServices = departamentosServices;
       
    }

    /// <summary>
    /// Obtém os dados de todos os departamentos cadastrados
    /// </summary>
    /// <response code="200">Dados dos departamentos cadastrados</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>

    [HttpGet]
    public async Task<ActionResult> GetAllDepartamentos()
    {
        try
        {
            var departamentos = await _departamentosServices.GetAllDepartamentosAsync();

            if (departamentos == null) return NotFound("Nenhum departamento foi encontrado.");

            return Ok(departamentos);
        }
        catch (Exception e)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar os departamentos. Erro: {e.Message}");
        }
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
            var departamentos = await _departamentosServices.GetDepartamentoByIdAsync(departamentoId);

            if (departamentos == null) return NotFound("Departamento não encontrado.");

            return Ok(departamentos);
        }
        catch (Exception e)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar o departamento. Erro: {e.Message}");
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
    /// <response code="200">Departamento atualizado com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>

    [HttpPut("{departamentoId}")]
    public async Task<IActionResult> UpdateDepartamento(int departamentoId, DepartamentoDto departamentoDto)
    {
        try
        {
            var departamento = await _departamentosServices.UpdateDepartamento(departamentoId, departamentoDto);

            if (departamento == null) return BadRequest("Não foi possível atualizar os dados do departamento.");

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
            if (await _departamentosServices.DeleteDepartamento(departamentoId))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Não foi possível excluir o departamento");
            }
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir o departamento. Erro: {e.Message}");
        }
    }
}
