using Microsoft.AspNetCore.Mvc;
using OnPeople.Application.Services.Contracts.Cargos;
using OnPeople.Application.Dtos.Cargos;

namespace OnPeople.API.Controllers.Cargos;

[ApiController]
[Route("api/[controller]")]

public class CargosController : ControllerBase
{
    private readonly ICargosServices _cargosServices;


    public CargosController(ICargosServices cargosServices)
    {
        _cargosServices = cargosServices;

    }

    /// <summary>
    /// Obtém os dados de todos os cargos cadastrados
    /// </summary>
    /// <response code="200">Dados dos cargos cadastrados</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>

    [HttpGet]
    public async Task<ActionResult> GetAllCargos()
    {
        try
        {
            var cargos = await _cargosServices.GetAllCargosAsync();

            if (cargos == null) return NotFound("Nenhum cargo foi encontrado.");

            return Ok(cargos);
        }
        catch (Exception e)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar os cargos. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Obtém os dados de um cargo específico
    /// </summary>
    /// <param name="cargoId">Identificador do cargo</param>
    /// <response code="200">Dados do cargo consultado</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>

    [HttpGet("{cargoId}")]
    public async Task<IActionResult> GetCargoById(int cargoId)
    {
        try
        {
            var cargo = await _cargosServices.GetCargoByIdAsync(cargoId);

            if (cargo == null) return NotFound("Cargo não encontrado.");

            return Ok(cargo);
        }
        catch (Exception e)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar o cargo. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Obtém os dados de todos os cargos cadastrados para um determinado departamento
    /// </summary>
    /// <param name="departamentoId">Identificador do departamento</param>
    /// <response code="200">Dados dos cargos cadastrados para o departamento</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>

    [HttpGet("{departamentoId}/departamento")]
    public async Task<IActionResult> GetCargosByDepartamentoIdAsync(int departamentoId)
    {
        try
        {
            var cargos = await _cargosServices.GetCargosByDepartamentoIdAsync(departamentoId);

            if (cargos == null) return NotFound("O departamento informado não possui cargos cadastrados.");

            return Ok(cargos);
        }
        catch (Exception e)
        {

            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar os cargos. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Realiza a inclusão de um novo cargo
    /// </summary>
    /// <response code="200">Cargo cadastrado com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>

    [HttpPost]
    public async Task<IActionResult> CreateCargos(CargoDto cargoDto)
    {
        try
        {
            var createdCargo = await _cargosServices.CreateCargos(cargoDto);

            if (createdCargo != null) return Ok(createdCargo);

            return BadRequest("Não foi possível cadastrar o cargo.");
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao cadastrar o cargo. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Realiza a alteração de um cargo
    /// </summary>
    /// <param name="cargoId">Identificador do cargo</param>
    /// <param name="cargoDto">Cargps Cadastrados</param>
    /// <response code="200">Cargo atualizado com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>

    [HttpPut("cargoId")]
    public async Task<IActionResult> UpdateCargos(int cargoId, CargoDto cargoDto)
    {
        try
        {
            var cargo = await _cargosServices.UpdateCargo(cargoId, cargoDto);

            if (cargo == null) return BadRequest("O cargo informado não existe.");

            return Ok(cargo);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar o cargo. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Realiza a exclusão de um cargo
    /// </summary>
    /// <param name="cargoId">Identificador do cargo</param>
    /// <response code="200">Cargo excluído com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>

    [HttpDelete("cargoId")]
    public async Task<IActionResult> DeleteCargos(int cargoId)
    {
        try
        {
            var cargo = await _cargosServices.GetCargoByIdAsync(cargoId);

            if (cargo.Ativo) return BadRequest("Cargos ativos não podem ser excluídos. Inative o cargo e tente novamente.");

            if (await _cargosServices.DeleteCargo(cargoId))
            {
                return Ok("Cargo excluído com sucesso");
            }
            else
            {
                return BadRequest("Não foi possível excluir o cargo.");
            }
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir o cargo. Erro: {e.Message}");
        }
    }
}
