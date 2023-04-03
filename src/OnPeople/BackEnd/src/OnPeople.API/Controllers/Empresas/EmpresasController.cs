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
using Newtonsoft.Json.Linq;
using OnPeople.Integration.Models.Links;

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
            Console.WriteLine("==============================================");
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

/*            if (empresaMatriz != null && !empresaMatriz.Ativa) {
                var atualizarEmpresaAtivaDto  = new AtualizarEmpresaAtivaDto();

                atualizarEmpresaAtivaDto.Id = empresaMatriz.Id;
                atualizarEmpresaAtivaDto.Ativa = true;

                if (await _empresasServices.SetEmpresa(atualizarEmpresaAtivaDto.Id, atualizarEmpresaAtivaDto) == null)
                    return BadRequest("Falha ao ativar empresa Matriz");
            }
*/
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

    [HttpGet("{id}/Dashboard")]
    public DashboardEmpresa GetDashboard(int id)
    {     
        var dashboardEmpresa = _empresasServices.GetDashboard(id, User.GetMasterClaim());

        return dashboardEmpresa;
    }

    [HttpGet("{cnpj}/external")]
    public async Task<IActionResult> GetPublicCNPJ(string cnpj)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());
            
            if (claimUser == null) 
                return Unauthorized();
                    
            var url = $"https://publica.cnpj.ws/cnpj/{cnpj}";

            Console.WriteLine(url);
            HttpClient request = new();

            request.BaseAddress = new Uri(url);
            request.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("consultar-cnpj/json"));

            System.Net.Http.HttpResponseMessage response = request.GetAsync(url).Result;

            EmpresaCnpjDto empresaCnpjDto = new EmpresaCnpjDto();

            empresaCnpjDto = response.Content.ReadFromJsonAsync<EmpresaCnpjDto>().Result;
    
            if (response.IsSuccessStatusCode) {
                var empresaDto = new EmpresaDto();

                empresaDto.Cnpj = empresaCnpjDto.estabelecimento.cnpj;
                empresaDto.RazaoSocial = empresaCnpjDto.razao_social;
                empresaDto.PorteEmpresa = empresaCnpjDto.porte.descricao;
                empresaDto.NaturezaJuridica = empresaCnpjDto.natureza_juridica.descricao;
                empresaDto.OptanteSimples = empresaCnpjDto.simples;
                empresaDto.Filial = empresaCnpjDto.estabelecimento.tipo == "Matriz" ? false : true;
                empresaDto.NomeFantasia = empresaCnpjDto.estabelecimento.nome_fantasia;
                empresaDto.Ativa = empresaCnpjDto.estabelecimento.situacao_cadastral == "Ativa" ? true : false;
                empresaDto.DataCadastro = empresaCnpjDto.estabelecimento.data_inicio_atividade;
                empresaDto.TipoLogradouro = empresaCnpjDto.estabelecimento.tipo_logradouro;
                empresaDto.Logradouro = empresaCnpjDto.estabelecimento.logradouro;
                empresaDto.Numero = empresaCnpjDto.estabelecimento.numero;
                empresaDto.Complemento = empresaCnpjDto.estabelecimento.complemento;
                empresaDto.Bairro = empresaCnpjDto.estabelecimento.bairro;
                empresaDto.CEP = empresaCnpjDto.estabelecimento.cep;
                empresaDto.DDD = empresaCnpjDto.estabelecimento.ddd1;
                empresaDto.Telefone = empresaCnpjDto.estabelecimento.tekefine1;
                empresaDto.Email = empresaCnpjDto.estabelecimento.email;
                empresaDto.AtividadePrincipal = empresaCnpjDto.estabelecimento.atividade_principal.descricao;
                empresaDto.PaisId = empresaCnpjDto.estabelecimento.pais.id;
                empresaDto.SiglaPaisIso2 = empresaCnpjDto.estabelecimento.pais.iso2;
                empresaDto.SiglaPaisIso3 = empresaCnpjDto.estabelecimento.pais.iso3;
                empresaDto.NomePais = empresaCnpjDto.estabelecimento.pais.nome;
                empresaDto.EstadoId = empresaCnpjDto.estabelecimento.estado.id;
                empresaDto.Estado = empresaCnpjDto.estabelecimento.estado.nome;
                empresaDto.SiglaEstado = empresaCnpjDto.estabelecimento.estado.sigla;
                empresaDto.EstadoIbgeId = empresaCnpjDto.estabelecimento.estado.igbe_id;
                empresaDto.CidadeId = empresaCnpjDto.estabelecimento.cidade.id;
                empresaDto.Cidade = empresaCnpjDto.estabelecimento.cidade.nome;
                empresaDto.CidadeIbgeId = empresaCnpjDto.estabelecimento.cidade.ibge_id;
                empresaDto.CidadeSiafiId = empresaCnpjDto.estabelecimento.cidade.siafi_id;
              
                return Ok(empresaDto);
            }
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
