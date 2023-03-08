using Microsoft.AspNetCore.Mvc;
using OnPeople.Application.Dtos.Contas;
using OnPeople.Application.Services.Contracts.Contas;

namespace OnPeople.API.Controllers.Empresas;

[ApiController]
[Route("api/[controller]")]
public class ContasController : ControllerBase
{
    private readonly IContasServices _contasServices;
    public ContasController(IContasServices contasServices)
    {
        _contasServices = contasServices;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContaById(int id)
    {
        try
        {
            var conta = await _contasServices.GetContaByIdAsync(id);

            if (conta == null) return NoContent();

            return Ok(conta);
        }
        catch (Exception e)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar conta por Id. Erro: {e.Message}");
        }
    }

    [HttpGet("{argumento}/argumento")]
    public async Task<IActionResult> GetContaByArgumento(string argumento)
    {
        try
        {
            var contas = await _contasServices.GetAllContasByArgumentoAsync(argumento);

            if (contas == null) return NoContent();

            return Ok(contas);
        }
        catch (Exception e)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar conta por argumento. Erro: {e.Message}");
        }
    }

    [HttpGet("ativas")]
    public async Task<IActionResult> GetContasAtivas()
    {
        try
        {
            var contas = await _contasServices.GetAllContasAtivasAsync();

            if (contas == null) return NoContent();

            return Ok(contas);
        }
        catch (Exception e)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar contas ativas. Erro: {e.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmpresa(ContaDto contaDto)
    {
        try
        {
            var createdConta = await _contasServices.CreateContas(contaDto);

            if (createdConta != null) return Ok(createdConta);

            return  NoContent();
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adiconar conta. Erro: {e.Message}");
        }
    }    
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Updateconta(int id, ContaDto contaDto)
    {
        try
        {
            var conta  = await _contasServices.UpdateContas(id, contaDto);

            if (conta == null) return NoContent();

            return Ok(conta);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar conta. Erro: {e.Message}");
        }
    }      
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConta(int id)
    {
        try
        {
            var conta = await _contasServices.GetContaByIdAsync(id);

            if (conta == null) return NoContent();

            if (await _contasServices.DeleteContas(id))
            {
                return Ok("Conta excluída!");
            } else {
                return BadRequest("Conta não excluída.");
            }
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir empresa. Erro: {e.Message}");
        }
    }   
}
