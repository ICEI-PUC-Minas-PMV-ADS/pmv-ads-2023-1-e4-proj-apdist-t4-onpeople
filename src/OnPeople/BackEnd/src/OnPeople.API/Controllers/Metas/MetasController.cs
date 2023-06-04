

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnPeople.API.Extensions.Users;
using OnPeople.Application.Services.Contracts.Metas;
using OnPeople.Application.Services.Contracts.Users;
using OnPeople.Domain.Models.Metas;
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
        public async Task<IActionResult> GetAllMetas()
        {
            try
            {
                var claimUser = await _usersServices.GetUserByIdAsync(User.GetUserIdClaim());

                if (claimUser == null) 
                    return Unauthorized();

                var userLogged = await _usersServices.GetUserByUserNameAsync(User.GetUserNameClaim());

                if (userLogged == null)
                    return Unauthorized();

                var metas = await _metasService.GetAllMetasAsync();
                if (metas == null) return NoContent();

                return Ok(metas);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar metas. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var metas = await _metasService.GetMetaByIdAsync(id);
                if (metas == null) return NoContent();

                return Ok(metas);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar metas. Erro: {ex.Message}");
            }
        }

        [HttpGet("{tipoMeta}/tipo")]
        public async Task<IActionResult> GetByTipo(string tipoMeta)
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

        [HttpPost]
        public async Task<IActionResult> Post(MetaDto model)
        {
            try
            {
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MetaDto model)
        {
            try
            {
                var meta = await _metasService.UpdateMeta(id, model);
                if (meta == null) return NoContent();

                return Ok(meta);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar metas. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var meta = await _metasService.GetMetaByIdAsync(id);
                if (meta == null) return NoContent();

                return await _metasService.DeleteMeta(id) ? 
                       Ok("Deletado") : 
                       throw new Exception("Ocorreu um problem não específico ao tentar deletar Meta.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar meta. Erro: {ex.Message}");
            }
        }
    }
}