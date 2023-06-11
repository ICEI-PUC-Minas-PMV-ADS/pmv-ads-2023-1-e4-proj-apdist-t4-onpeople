

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnPeople.API.Extensions.Pages;
using OnPeople.API.Extensions.Users;
using OnPeople.Application.Services.Contracts.Metas;
using OnPeople.Application.Services.Contracts.Users;
using OnPeople.Domain.Models.Metas;
using OnPeople.Integration.Models.Dashboard;
using OnPeople.Integration.Models.Pages.Config;

namespace OnPeople.API.Controllers.Metas
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MetasController : ControllerBase
    {
        private readonly IMetasService _metasService;
        private readonly IUsersServices _usersServices;

        public MetasController(
            IMetasService metasService,
            IUsersServices usersServices
            )
        {
            _metasService = metasService;
            _usersServices = usersServices;
        }

        /// <summary>
        /// Obtém os dados de todas as metas cadastradas
        /// </summary>
        /// <response code="200">Dados das metas cadastradas</response>
        /// <response code="400">Parâmetros incorretos</response>
        /// <response code="500">Erro interno</response>
        [HttpGet]
        public async Task<IActionResult> GetAllMetas([FromQuery] PageParameters pageParameters)
        {
            try
            {
                var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

                if (claimUser == null)
                    return Unauthorized();

                var userLogged = await _usersServices.GetUserByUserNameAsync(User.GetUserNameClaim());

                if (userLogged == null)
                    return Unauthorized();

                var metas = await _metasService.GetAllMetasAsync(pageParameters, userLogged.CodEmpresa);
                if (metas == null) return NoContent();

                Response.CreatePagination(metas.CurrentPage, metas.PageSize, metas.TotalCounter, metas.TotalPages);

                return Ok(metas);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar metas. Erro: {ex.Message}");
            }
        }


        /// <summary>
        /// Obtém os dados de uma meta específica
        /// </summary>
        /// <param name="metaId">Identificador da meta</param>
        /// <response code="200">Dados do cargo consultado</response>
        /// <response code="400">Parâmetros incorretos</response>
        /// <response code="500">Erro interno</response>
        [HttpGet("{metaId}")]
        public async Task<IActionResult> GetMetaById(int metaId)
        {
            try
            {
                var metas = await _metasService.GetMetaByIdAsync(metaId);
                if (metas == null) return NoContent();

                return Ok(metas);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar metas. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Obtém os dados de todoa as metas cadastradas para um determinado tipo
        /// </summary>
        /// <param name="tipoMeta">Identificador do tipo de meta</param>
        /// <response code="200">Dados dos cargos cadastrados para o departamento</response>
        /// <response code="400">Parâmetros incorretos</response>
        /// <response code="500">Erro interno</response>
        [HttpGet("{tipoMeta}/tipo")]
        public async Task<IActionResult> GetMetaByTipo(string tipoMeta)
        {
            try
            {
                var metas = await _metasService.GetAllMetasByTipoAsync(tipoMeta);
                if (metas == null) return NoContent();

                return Ok(metas);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar metas. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Realiza a inclusão de uma nova meta
        /// </summary>
        /// <response code="200">Meta cadastrado com sucesso</response>
        /// <response code="400">Parâmetros incorretos</response>
        /// <response code="500">Erro interno</response>
        [HttpPost]
        public async Task<IActionResult> Post(MetaDto model)
        {
            try
            {
                var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

                if (claimUser == null)
                    return Unauthorized();

                if (!claimUser.Master)
                    return Unauthorized();

                var meta = await _metasService.CreateMetas(model);
                if (meta == null) return NoContent();

                return Ok(meta);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar metas. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Realiza a alteração de uma meta
        /// </summary>
        /// <param name="metaId">Identificador da meta</param>
        /// <param name="metaDto">Metas Cadastrados</param>
        /// <response code="200">Meta atualizado com sucesso</response>
        /// <response code="400">Parâmetros incorretos</response>
        /// <response code="500">Erro interno</response>
        [HttpPut("{metaId}")]
        public async Task<IActionResult> Put(int metaId, MetaDto metaDto)
        {
            try
            {
                var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

                if (claimUser == null)
                    return Unauthorized();

                Console.WriteLine("Aqui");
                if (metaDto.Id != metaId)
                    return Unauthorized();

                var meta = await _metasService.UpdateMeta(metaId, metaDto);
                if (meta == null) return NoContent();

                return Ok(meta);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar metas. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Realiza a exclusão de uma meta
        /// </summary>
        /// <param name="metaId">Identificador da meta</param>
        /// <response code="200">Meta excluído com sucesso</response>
        /// <response code="400">Parâmetros incorretos</response>
        /// <response code="500">Erro interno</response>
        [HttpDelete("{metaId}")]
        public async Task<IActionResult> Delete(int metaId)
        {
            try
            {
                var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

                if (claimUser == null)
                    return Unauthorized();

                if (!claimUser.Master)
                    return Unauthorized();

                var meta = await _metasService.GetMetaByIdAsync(metaId);

                if (meta == null) return NoContent();

                return await _metasService.DeleteMeta(metaId) ?
                       Ok("Deletado") :
                       throw new Exception("Ocorreu um problem não específico ao tentar deletar Meta.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar meta. Erro: {ex.Message}");
            }
        }

        /// <summary>
        /// Realiza a consulta estatística de meta
        /// </summary>
        /// <param name="empresaId">Identificador da empresa (pode zero para buscar todas)</param>
        /// <response code="200">Dashboard de empresas consultado</response>
        /// <response code="400">Parâmetros incorretos</response>
        /// <response code="500">Erro interno</response>

        [HttpGet("{empresaId}/Dashboard")]
        public DashboardMetas GetDashboard(int empresaId)
        {
            var dashboardCargo = _metasService.GetDashboard(empresaId);

            return dashboardCargo;
        }
    }
}