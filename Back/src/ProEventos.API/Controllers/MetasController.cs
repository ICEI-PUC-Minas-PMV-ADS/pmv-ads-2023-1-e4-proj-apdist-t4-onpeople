using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;
using ProEventos.Application.Dtos;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetasController : ControllerBase
    {
        private readonly IMetasService _metasService;

        public MetasController(IMetasService metasService)
        {
            _metasService = metasService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
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
                var meta = await _metasService.AddMetas(model);
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