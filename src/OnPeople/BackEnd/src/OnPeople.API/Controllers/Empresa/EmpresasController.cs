

using Microsoft.AspNetCore.Mvc;
using OnPeople.Application.Services.Contracts.Empresas;
using OnPeople.Domain.Models.Empresas;

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

            if (empresas == null) return NotFound("Nenhuma empresa encontrada.");

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

            if (empresa == null) return NotFound("Empresa por Id não encontrada.");

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

            if (empresas == null) return NotFound("Empresas por argumento não encontrada.");

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

            if (empresas == null) return NotFound("Empresas ativas não encontrada.");

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

            if (empresas == null) return NotFound("Empresas filiais não encontrada.");

            return Ok(empresas);
        }
        catch (Exception e)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa filiais. Erro: {e.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmpresa(Empresa empresa)
    {
        try
        {
            var createdEmpresa = await _empresasServices.CreateEmpresas(empresa);

            if (createdEmpresa != null) return Ok(createdEmpresa);

            return BadRequest("Empresa não casdastrada, tente novamente.");
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adiconar empresa. Erro: {e.Message}");
        }
    }    
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmpresa(int id, Empresa model)
    {
        try
        {
            var empresa  = await _empresasServices.UpdateEmpresas(id, model);

            if (empresa == null) return BadRequest("Erro ao atualizar empresa.");

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
