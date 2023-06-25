using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using OnPeople.API.Controllers.Uploads;
using OnPeople.API.Extensions.Users;
using OnPeople.API.Extensions.Pages;

using OnPeople.Application.Dtos.Empresas;
using OnPeople.Application.Services.Contracts.Users;
using OnPeople.Application.Services.Contracts.Empresas;

using OnPeople.Integration.Models.Pages.Config;
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
    private readonly HttpClient _httpClient = new();
    private EmpresaCnpjDto _empresaCnpjDto = new();
    private readonly EmpresaDto _empresaDto = new();

    public EmpresasController(
        IEmpresasServices empresasServices,
        IUploadService uploadService,
        IUsersServices usersServices)
    {
        _empresasServices = empresasServices;
        _uploadService = uploadService;
        _usersServices = usersServices;
    }


    /// <summary>
    /// Obtém os dados de todas as empresas cadastradas de acordo com o perfil
    /// </summary>
    /// <response code="200">Dados da empresas cadastradas</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
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

    /// <summary>
    /// Obtém os dados de uma empresa específico
    /// </summary>
    /// <param name="empresaId">Identificador da empresa</param>
    /// <response code="200">Dados da empresa consultado</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
    [HttpGet("{EmpresaId}")]
    public async Task<IActionResult> GetEmpresaById(int empresaId)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());
            
            if (claimUser == null) 
                return Unauthorized();
                
            if (!claimUser.Master)
                if (claimUser.CodEmpresa != empresaId)
                    return Unauthorized();
                    
            var empresa = await _empresasServices.GetEmpresaByIdAsync(empresaId);

            if (empresa == null) return NoContent();

            return Ok(empresa);
        }
        catch (Exception e)
        {
            
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa por Id. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Obtém os dados das empresas ativas
    /// </summary>
    /// <response code="200">Dados do departamento consultado</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>

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

    /// <summary>
    /// Obtém os dados das empresas filiais
    /// </summary>
    /// <response code="200">Dados das empresas consultadas</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
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

    /// <summary>
    /// Obtém os dados das empresas Matrizes
    /// </summary>
    /// <response code="200">Dados das empresas consultadas</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
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

    /// <summary>
    /// Realiza a inclusão de uma nova empresa
    /// </summary>
    /// <response code="200">Empresa cadastrado com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
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
    
    /// <summary>
    /// Realiza a atualização dos dados de uma empresa
    /// </summary>
    /// <param name="empresaId">Identificador do departamento</param>
    /// <param name="empresaDto">IEmpresas Cadastradaso</param>
    /// <response code="200">Empresa atualizada com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>

    [HttpPut("{empresaId}")]
    public async Task<IActionResult> UpdateEmpresa(int empresaId, EmpresaDto empresaDto)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());   

            if (claimUser == null) 
                return Unauthorized();

            if (!claimUser.Master)
                return Unauthorized();

            if (empresaDto.Id != empresaId)
                return Unauthorized();
        
            var empresa  = await _empresasServices.UpdateEmpresa(empresaId, empresaDto);

            if (empresa == null) return NoContent();

            return Ok(empresa);
        }
        catch (Exception e)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar empresa. Erro: {e.Message}");
        }
    }      
    
    /// <summary>
    /// Realiza a exclusão de uma empresa
    /// </summary>
    /// <param name="empresaId">Identificador da empresa</param>
    /// <response code="200">Empresa excluído com sucesso</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>

    [HttpDelete("{empresaId}")]
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


    /// <summary>
    /// Realiza a consulta da empresa na Receita Federal
    /// </summary>
    /// <param name="cnpj">CNPJ da empresa </param>
    /// <response code="200">Consulta da empresa na Receita Fedeal realizada</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
    [HttpGet("{cnpj}/external")]
    public async Task<IActionResult> GetPublicCNPJ(string cnpj)
    {
        try
        {
            var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());
            
            if (claimUser == null) 
                return Unauthorized();
                    
            var url = $"https://publica.cnpj.ws/cnpj/{cnpj}";

            _httpClient.BaseAddress = new Uri(url);

            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("consultar-cnpj/json"));

            System.Net.Http.HttpResponseMessage response = _httpClient.GetAsync(url).Result;

            _empresaCnpjDto = response.Content.ReadFromJsonAsync<EmpresaCnpjDto>().Result;
    
            if (response.IsSuccessStatusCode) {

                _empresaDto.Cnpj = _empresaCnpjDto.estabelecimento.cnpj;
                _empresaDto.RazaoSocial = _empresaCnpjDto.razao_social;
                _empresaDto.PorteEmpresa = _empresaCnpjDto.porte.descricao;
                _empresaDto.NaturezaJuridica = _empresaCnpjDto.natureza_juridica.descricao;
                _empresaDto.OptanteSimples = _empresaCnpjDto.simples;
                _empresaDto.Filial = _empresaCnpjDto.estabelecimento.tipo == "Matriz" ;
                _empresaDto.NomeFantasia = _empresaCnpjDto.estabelecimento.nome_fantasia;
                _empresaDto.Ativa = _empresaCnpjDto.estabelecimento.situacao_cadastral == "Ativa";
                _empresaDto.DataCadastro = _empresaCnpjDto.estabelecimento.data_inicio_atividade;
                _empresaDto.TipoLogradouro = _empresaCnpjDto.estabelecimento.tipo_logradouro;
                _empresaDto.Logradouro = _empresaCnpjDto.estabelecimento.logradouro;
                _empresaDto.Numero = _empresaCnpjDto.estabelecimento.numero;
                _empresaDto.Complemento = _empresaCnpjDto.estabelecimento.complemento;
                _empresaDto.Bairro = _empresaCnpjDto.estabelecimento.bairro;
                _empresaDto.CEP = _empresaCnpjDto.estabelecimento.cep;
                _empresaDto.DDD = _empresaCnpjDto.estabelecimento.ddd1;
                _empresaDto.Telefone = _empresaCnpjDto.estabelecimento.tekefine1;
                _empresaDto.EmailEmpresa = _empresaCnpjDto.estabelecimento.email;
                _empresaDto.AtividadePrincipal = _empresaCnpjDto.estabelecimento.atividade_principal.descricao;
                _empresaDto.PaisId = _empresaCnpjDto.estabelecimento.pais.id;
                _empresaDto.SiglaPaisIso2 = _empresaCnpjDto.estabelecimento.pais.iso2;
                _empresaDto.SiglaPaisIso3 = _empresaCnpjDto.estabelecimento.pais.iso3;
                _empresaDto.NomePais = _empresaCnpjDto.estabelecimento.pais.nome;
                _empresaDto.EstadoId = _empresaCnpjDto.estabelecimento.estado.id;
                _empresaDto.Estado = _empresaCnpjDto.estabelecimento.estado.nome;
                _empresaDto.SiglaEstado = _empresaCnpjDto.estabelecimento.estado.sigla;
                _empresaDto.EstadoIbgeId = _empresaCnpjDto.estabelecimento.estado.igbe_id;
                _empresaDto.CidadeId = _empresaCnpjDto.estabelecimento.cidade.id;
                _empresaDto.Cidade = _empresaCnpjDto.estabelecimento.cidade.nome;
                _empresaDto.CidadeIbgeId = _empresaCnpjDto.estabelecimento.cidade.ibge_id;
                _empresaDto.CidadeSiafiId = _empresaCnpjDto.estabelecimento.cidade.siafi_id;
              
                return Ok(_empresaDto);
            }
            return BadRequest("CNPJ Inválido");
        }
        catch (Exception e)
        {  
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa por CNPJ. Erro: {e.Message}");
        }
    }

    /// <summary>
    /// Realiza a consulta da empresa npor CNPJ
    /// </summary>
    /// <param name="cnpj">CNPJ da empresa </param>
    /// <response code="200">Consulta da empresa realizada</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>

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

    /// <summary>
    /// Realiza a consulta estatística de empresa
    /// /// </summary>
    /// <param name="empresaId">Identificador da empresa (pode zero para buscar todas)</param>
    /// <response code="200">Dashboard de empresas consultado</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
    [HttpGet("{empresaId}/DashboardEmpresas")]
    public Task<DashboardEmpresa> GetDashboardEmpresa(int empresaId)
    {     
        var dashboardEmpresa = _empresasServices.GetDashboardEmpresa(empresaId, User.GetMasterClaim());

        return dashboardEmpresa;
    }

    /// <summary>
    /// Realiza a consulta estatística de metas por empresa
    /// /// </summary>
    /// <param name="empresaId">Identificador da empresa (pode zero para buscar todas)</param>
    /// <response code="200">Dashboard de empresas consultado</response>
    /// <response code="400">Parâmetros incorretos</response>
    /// <response code="500">Erro interno</response>
    
    [HttpGet("{empresaId}/DashboardEmpresaMetas")]
    public Task<List<ListaMetas>> GetDashboardEmpresaMeta(int empresaId)
    {     
        var listaMetas = _empresasServices.GetDashboardEmpresaMetas(empresaId, User.GetMasterClaim());

        return listaMetas;
    }
}
