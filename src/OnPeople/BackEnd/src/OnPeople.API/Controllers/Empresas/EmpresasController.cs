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
        IUsersServices usersServices)
    {
        _empresasServices = empresasServices;
        _uploads = uploads;
        _usersServices = usersServices;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllEmpresas()
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            if (claimUser == null) 
                return Unauthorized();
            
            var empresas = await _empresasServices.GetAllEmpresasAsync(claimUser.CodEmpresa, claimUser.Master);

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
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());
            Console.WriteLine("===================================" + claimUser.UserName);
            if (claimUser == null) 
                return Unauthorized();
                
            if (!claimUser.Master)
                if (claimUser.CodEmpresa != id)
                    return Unauthorized();
                    
            var empresa = await _empresasServices.GetEmpresaByIdAsync(id);

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
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();
                
            var empresas = await _empresasServices.GetAllEmpreasByArgumentoAsync(claimUser.CodEmpresa, claimUser.Master, argumento);

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
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();
                
            var empresas = await _empresasServices.GetAllEmpresasAtivasAsync(claimUser.CodEmpresa, claimUser.Master);

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
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            var empresas = await _empresasServices.GetAllEmpresasFiliaisAsync(claimUser.CodEmpresa, claimUser.Master);

            if (empresas == null) return NoContent();

            return Ok(empresas);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa filiais. Erro: {e.Message}");
        }
    }

    [HttpGet("Matrizes")]
    public async Task<IActionResult> GetEmpresasMatrizes()
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            var empresas = await _empresasServices.GetAllEmpresasMatrizesAsync(claimUser.CodEmpresa, claimUser.Master);

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
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            if (!claimUser.Master)
                return Unauthorized();
            
            var createdEmpresa = await _empresasServices.CreateEmpresas(claimUser.CodEmpresa, claimUser.Master, empresaDto);

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
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            if (!claimUser.Master)
                return Unauthorized();

            if (empresaDto.Id != id)
                return Unauthorized();

            var empresa  = await _empresasServices.UpdateEmpresa(id, empresaDto);

            if (empresa == null) return NoContent();

            return Ok(empresa);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar empresa. Erro: {e.Message}");
        }
    }      
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmpresa(int empresaId)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            if (!claimUser.Master)
                return Unauthorized();

            var empresa = await _empresasServices.GetEmpresaByIdAsync(empresaId);

            if (empresa == null) 
                return NoContent();

            if (await _empresasServices.DeleteEmpresas(empresaId)){
                _uploads.DeleteImageUpload(claimUser.Id, claimUser.Master, empresa.Logotipo, "Logos");
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
