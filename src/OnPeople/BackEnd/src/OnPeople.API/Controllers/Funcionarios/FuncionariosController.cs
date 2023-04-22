using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OnPeople.API.Controllers.Uploads;
using OnPeople.API.Extensions.Users;
using OnPeople.Application.Services.Contracts.Users;
using OnPeople.Integration.Models.Pages.Config;
using OnPeople.API.Extensions.Pages;
using OnPeople.Integration.Models.Dashboard;
using Newtonsoft.Json.Linq;
using OnPeople.Integration.Models.Links;
using OnPeople.Application.Services.Contracts.Funcionarios;
using OnPeople.Application.Dtos.Funcionarios;

namespace OnPeople.API.Controllers.Funcionarios;

[ApiController]
[Route("api/[controller]")]
public class FuncionariosController : ControllerBase
{
    private readonly IFuncionariosServices _funcionariosservices;
    private readonly IUploadService _uploadService;
    private readonly IUsersServices _usersServices;

    public FuncionariosController(
        IFuncionariosServices funcionariosservices,
        IUploadService uploadService,
        IUsersServices usersServices)
    {
        _funcionariosservices = funcionariosservices;
        _uploadService = uploadService;
        _usersServices = usersServices;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllFuncionarios([FromQuery]PageParameters pageParameters)
    {
        try
        {
            // var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

            // if (claimUser == null) 
            //     return Unauthorized();
            
            var funcionarios = await _funcionariosservices.GetAllFuncionarios(pageParameters);

            if (funcionarios == null) return NoContent();
            
            
            Response.CreatePagination(funcionarios.CurrentPage, funcionarios.PageSize, funcionarios.TotalCounter, funcionarios.TotalPages);

            return Ok(funcionarios);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresas. Erro: {e.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFuncionarioById(int id)
    {
        try
        {
            // var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());
            
            // if (claimUser == null) 
            //     return Unauthorized();

            var funcionario = await _funcionariosservices.GetFuncionarioById(id);

            if (funcionario == null) return NoContent();

            return Ok(funcionario);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa por Id. Erro: {e.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateFuncionario(CreateFuncionarioDto funcionarioDto)
    {
        try
        {
            // var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            // if (claimUser == null) 
            //     return Unauthorized();

            // if (!claimUser.Master)
            //     return Unauthorized();

            var createdFuncionario = await _funcionariosservices.CreateFuncionario(funcionarioDto);

            if (createdFuncionario != null) return Ok(createdFuncionario);

            return NoContent();
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adiconar empresa. Erro: {e.Message}");
        }
    }    
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFuncionario(int id, UpdateFuncionarioDto funcionarioDto)
    {
        try
        {
            // var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            // if (claimUser == null) 
            //     return Unauthorized();

            // if (!claimUser.Master)
            //     return Unauthorized();

            if (funcionarioDto.Id != id)
                return Unauthorized();

            var funcionario  = await _funcionariosservices.UpdateFuncionario(id, funcionarioDto);

            if (funcionario == null) return NoContent();

            return Ok(funcionario);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar empresa. Erro: {e.Message}");
        }
    }      
    
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
                return Ok( new { message = "OK"});
            } else {
                return BadRequest("Falha na exclusão do funcionário.");
            }
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir empresa. Erro: {e.Message}");
        }
        
    }   
}
