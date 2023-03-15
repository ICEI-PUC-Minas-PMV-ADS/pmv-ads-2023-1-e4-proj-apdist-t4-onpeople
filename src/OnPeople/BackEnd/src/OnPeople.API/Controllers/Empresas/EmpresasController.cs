using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnPeople.API.Controllers.Uploads;
using OnPeople.API.Extensions.Users;
using OnPeople.Application.Dtos.Empresas;
using OnPeople.Application.Services.Contracts.Users;
using OnPeople.Application.Services.Contracts.Empresas;

namespace OnPeople.API.Controllers.Empresas;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EmpresasController : ControllerBase
{
    private readonly IEmpresasServices _empresasServices;
    private readonly IUploads _uploads;
    private readonly IUsersServices _usersServices;

    public EmpresasController(
        IEmpresasServices empresasServices,
        IUploads uploads,
        IUsersServices contasServices)
    {
        _empresasServices = empresasServices;
        _uploads = uploads;
        _usersServices = contasServices;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllEmpresas()
    {
        try
        {
            var userId = User.GetUserIdClaim();
            Console.WriteLine("=-=-=-=-=-= " + userId);
            var conta = await _usersServices.GetUserByIdAsync(userId);
            
            var empresas = await _empresasServices.GetAllEmpresasAsync(conta.Id, conta.Master);

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
            var conta = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            var empresa = await _empresasServices.GetEmpresaByIdAsync(conta.Id, conta.Master, id);

            if (empresa == null) return NoContent();

            return Ok(empresa);
        }
        catch (Exception e)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa por Id. Erro: {e.Message}");
        }
    }

    [HttpGet("{argumento}/Argumento")]
    public async Task<IActionResult> GetEmpresaByArgumento(string argumento)
    {
        try
        {
            var conta = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            var empresas = await _empresasServices.GetAllEmpreasByArgumentoAsync(conta.Id, conta.Master, argumento);

            if (empresas == null) return NoContent();

            return Ok(empresas);
        }
        catch (Exception e)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa por argumento. Erro: {e.Message}");
        }
    }

    [HttpGet("Ativas")]
    public async Task<IActionResult> GetEmpresasAtivas()
    {
        try
        {
            var conta = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            var empresas = await _empresasServices.GetAllEmpresasAtivasAsync(conta.Id, conta.Master);

            if (empresas == null) return NoContent();

            return Ok(empresas);
        }
        catch (Exception e)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa ativas. Erro: {e.Message}");
        }
    }

    [HttpGet("Filiais")]
    public async Task<IActionResult> GetEmpresasFiliais()
    {
        try
        {
            var conta = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            var empresas = await _empresasServices.GetAllEmpresasFiliaisAsync(conta.Id, conta.Master);

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
            var conta = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            var createdEmpresa = await _empresasServices.CreateEmpresas(conta.Id, conta.Master, empresaDto);

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
            var conta = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            var empresa  = await _empresasServices.UpdateEmpresas(conta.Id, conta.Master, id, empresaDto);

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
            var conta = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            var empresa = await _empresasServices.GetEmpresaByIdAsync(conta.Id, conta.Master, id);

            if (empresa == null) return NoContent();

            if (await _empresasServices.DeleteEmpresas(conta.Id, conta.Master, id)){
                _uploads.DeleteImageUpload(conta.Id, conta.Master, empresa.Logotipo, "Logos");
                return Ok( new { message = "OK"});
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
