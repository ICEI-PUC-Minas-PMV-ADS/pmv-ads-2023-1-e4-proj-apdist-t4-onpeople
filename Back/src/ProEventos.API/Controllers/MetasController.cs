using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;

namespace OnPeople.API.Controllers.Metas
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
                if (metas == null) return NotFound("Nenhuma meta encontrada!");

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
                if (metas == null) return NotFound("Metas por Id não encontrado.");

                return Ok(metas);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar metas. Erro: {ex.Message}");
            }
        }

        [HttpGet("{tipo}/tipo")]
        public async Task<IActionResult> GetByTipo(string tipoMeta)
        {
            try
            {
                var metas = await _metasService.GetAllMetasByTipoAsync(tipoMeta);
                if (metas == null) return NotFound("Metas por tipo não encontradas.");

                return Ok(metas);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar metas. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Meta model)
        {
            try
            {
                var meta = await _metasService.AddMetas(model);
                if (meta == null) return BadRequest("Erro ao tentar adicionar meta.");

                return Ok(meta);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar metas. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Meta model)
        {
            try
            {
                var meta = await _metasService.UpdateMeta(id, model);
                if (meta == null) return BadRequest("Erro ao tentar atualizar meta.");

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
                return await _metasService.DeleteMeta(id) ? 
                       Ok("Deletado com sucesso!") : 
                       BadRequest("Meta não deletada!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar meta. Erro: {ex.Message}");
            }
        }
    }
}