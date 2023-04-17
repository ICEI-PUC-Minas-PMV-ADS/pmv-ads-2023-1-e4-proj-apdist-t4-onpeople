using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OnPeople.API.Controllers.Uploads;
using OnPeople.API.Extensions.Users;
using OnPeople.Application.Dtos.Empresas;
using OnPeople.Application.Services.Contracts.Users;
using OnPeople.Application.Services.Contracts.Empresas;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.API.Extensions.Pages;
using OnPeople.Integration.Models.Dashboard;

namespace OnPeople.API.Controllers.Empresas;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EmpresasController : ControllerBase
{
    private readonly IEmpresasServices _empresasServices;
    private readonly IUploadService _uploadService;
    private readonly IUsersServices _usersServices;

    public EmpresasController(
        IEmpresasServices empresasServices,
        IUploadService uploadService,
        IUsersServices usersServices)
    {
        _empresasServices = empresasServices;
        _uploadService = uploadService;
        _usersServices = usersServices;
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

            var empresaMatriz = await _empresasServices.GetEmpresaMatrizAsync();

            if (empresaMatriz != null && empresaDto.Filial)
                empresaDto.MatrizId = empresaMatriz.Id;

            var createdEmpresa = await _empresasServices.CreateEmpresas(claimUser.CodEmpresa, claimUser.Master, empresaDto);

            if (createdEmpresa != null) return Ok(createdEmpresa);

            return NoContent();
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adiconar empresa. Erro: {e.Message}");
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

            if (empresa.Ativa)
                return BadRequest("Esta empresa está ativa no sistema e não pode ser excluída");
 
            if (await _empresasServices.DeleteEmpresas(empresaId)){
                _uploadService.DeleteImageUpload(claimUser.Id, claimUser.Master, empresa.Logotipo, "Logos");
                return Ok( new { message = "OK"});
            } else {
                return BadRequest("Falha na exclusão da empresa.");
            }
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir empresa. Erro: {e.Message}");
        }
        
    } 

    [HttpGet]
    public async Task<IActionResult> GetAllEmpresas([FromQuery]PageParameters pageParameters)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            if (claimUser == null) 
                return Unauthorized();
            
            var empresas = await _empresasServices.GetAllEmpresasAsync(pageParameters, claimUser.CodEmpresa, claimUser.Master);

            if (empresas == null) return NoContent();
            
            
            Response.CreatePagination(empresas.CurrentPage, empresas.PageSize, empresas.TotalCounter, empresas.TotalPages);

            return Ok(empresas);
        }
        catch (Exception e)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresas. Erro: {e.Message}");
        }
    }


    [HttpGet("{id}/Dashboard")]
    public DashboardEmpresa GetDashboard(int id)
    {     
        var dashboardEmpresa = _empresasServices.GetDashboard(id, User.GetMasterClaim());

        return dashboardEmpresa;
    }

    [HttpGet("Ativas")]
    public async Task<IActionResult> GetEmpresasAtivas([FromQuery]PageParameters pageParameters)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();
                
            var empresas = await _empresasServices.GetAllEmpresasAtivasAsync(pageParameters, claimUser.CodEmpresa, claimUser.Master);

            if (empresas == null) return NoContent();

            Response.CreatePagination(empresas.CurrentPage, empresas.PageSize, empresas.TotalCounter, empresas.TotalPages);

            return Ok(empresas);
        }
        catch (Exception e)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa ativas. Erro: {e.Message}");
        }
    }
  
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmpresaById(int id)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());
            
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

    [HttpGet("Filiais")]
    public async Task<IActionResult> GetEmpresasFiliais([FromQuery]PageParameters pageParameters)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            var empresas = await _empresasServices.GetAllEmpresasFiliaisAsync(pageParameters, claimUser.CodEmpresa, claimUser.Master);

            if (empresas == null) return NoContent();

            Response.CreatePagination(empresas.CurrentPage, empresas.PageSize, empresas.TotalCounter, empresas.TotalPages);

            return Ok(empresas);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa filiais. Erro: {e.Message}");
        }
    }

    [HttpGet("Matriz")]
    public async Task<IActionResult> GetEmpresaMatriz()
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            var empresa = await _empresasServices.GetEmpresaMatrizAsync();

            if (empresa == null) return NoContent();

            return Ok(empresa);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa filiais. Erro: {e.Message}");
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
    

    [HttpGet("{cnpj}/receitafederal")]
    public async Task<IActionResult> GetPublicCNPJ(string cnpj)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());
            
            if (claimUser == null) 
                return Unauthorized();
                    
            var empresaDto = await _empresasServices.GetCnpjReceitaFederalAsync(cnpj);   

            if (empresaDto != null)
                return Ok(empresaDto);
            
            return BadRequest("CNPJ Inválido");
        }
        catch (Exception e)
        {  
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa por CNPJ. Erro: {e.Message}");
        }
    }

  [HttpGet("{cnpj}/internal")]
    public async Task<IActionResult> GetCNPJ(string cnpj)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());
            
            if (claimUser == null) 
                return Unauthorized();
                    
            if (!claimUser.Master)
                return Unauthorized();

            var empresa = await _empresasServices.GetEmpresaByCnpjAsync(cnpj, claimUser.Master);
            
            if (empresa == null)
                return NoContent();

            return Ok(empresa);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa por CNPJ. Erro: {e.Message}");
        }
    }
}
