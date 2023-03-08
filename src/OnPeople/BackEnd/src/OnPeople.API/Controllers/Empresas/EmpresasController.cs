

using Microsoft.AspNetCore.Mvc;
using OnPeople.Application.Dtos.Empresas;
using OnPeople.Application.Services.Contracts.Empresas;

namespace OnPeople.API.Controllers.Empresas;

[ApiController]
[Route("api/[controller]")]
public class EmpresasController : ControllerBase
{
    private readonly IEmpresasServices _empresasServices;
    public EmpresasController(IEmpresasServices empresasServices)
    {
        _empresasServices = empresasServices;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllEmpresas()
    {
        try
        {
            var empresas = await _empresasServices.GetAllEmpresasAsync();

            if (empresas == null) return NoContent();

            return Ok(empresas);
        }
        catch (Exception e)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresas. Erro: {e.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmpresaById(int id)
    {
        try
        {
            var empresa = await _empresasServices.GetEmpresaByIdAsync(id);

            if (empresa == null) return NoContent();

            return Ok(empresa);
        }
        catch (Exception e)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa por Id. Erro: {e.Message}");
        }
    }

    [HttpGet("{argumento}/argumento")]
    public async Task<IActionResult> GetEmpresaByArgumento(string argumento)
    {
        try
        {
            var empresas = await _empresasServices.GetAllEmpreasByArgumentoAsync(argumento);

            if (empresas == null) return NoContent();

            return Ok(empresas);
        }
        catch (Exception e)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa por argumento. Erro: {e.Message}");
        }
    }

    [HttpGet("ativas")]
    public async Task<IActionResult> GetEmpresasAtivas()
    {
        try
        {
            var empresas = await _empresasServices.GetAllEmpresasAtivasAsync();

            if (empresas == null) return NoContent();

            return Ok(empresas);
        }
        catch (Exception e)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa ativas. Erro: {e.Message}");
        }
    }

    [HttpGet("filiais")]
    public async Task<IActionResult> GetEmpresasFiliais()
    {
        try
        {
            var empresas = await _empresasServices.GetAllEmpresasFiliaisAsync();

            if (empresas == null) return NoContent();

            return Ok(empresas);
        }
        catch (Exception e)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa filiais. Erro: {e.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmpresa(EmpresaDto empresaDto)
    {
        try
        {
            var createdEmpresa = await _empresasServices.CreateEmpresas(empresaDto);

            if (createdEmpresa != null) return Ok(createdEmpresa);

            return NoContent();
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adiconar empresa. Erro: {e.Message}");
        }
    }    
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmpresa(int id, EmpresaDto empresaDto)
    {
        try
        {
            var empresa  = await _empresasServices.UpdateEmpresas(id, empresaDto);

            if (empresa == null) return NoContent();

            return Ok(empresa);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar empresa. Erro: {e.Message}");
        }
    }      
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmpresa(int id)
    {
        try
        {
            if (await _empresasServices.DeleteEmpresas(id))
            {
                return Ok("Empresa excluída!");
            } else {
                return BadRequest("Empresa não excluída.");
            }
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir empresa. Erro: {e.Message}");
        }
    }   
}
