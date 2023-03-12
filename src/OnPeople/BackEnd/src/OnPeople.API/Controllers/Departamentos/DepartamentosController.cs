using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnPeople.Application.Services.Contracts.Departamentos;
using OnPeople.Domain.Models.Departamentos;

namespace OnPeople.API.Controllers.Departamentos
{
    [ApiController]
    [Route("api/[controller]")]

    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentosServices _departamentosServices;
        public DepartamentosController(IDepartamentosServices departamentosServices)
        {
            _departamentosServices = departamentosServices;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllDepartamentos()
        {

            try
            {
                var departamentos = await _departamentosServices.GetAllDepartamentosAsync();

                if (departamentos == null) return NotFound("Nenhum departamento encontrada.");

                return Ok(departamentos);
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar departamentos. Erro: {e.Message}");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartamentoById(int id)
        {
            try
            {
                var departamentos = await _departamentosServices.GetDepartamentoByIdAsync(id);

                if (departamentos == null) return NotFound("Empresa por Id não encontrada.");

                return Ok(departamentos);
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar empresa por Id. Erro: {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartamento(Departamento departamento)
        {
            try
            {
                var createdDepartamento = await _departamentosServices.CreateDepartamentos(departamento);

                if (createdDepartamento != null) return Ok(createdDepartamento);

                return BadRequest("Departamento não cadastrado, tente novamente.");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adiconar empresa. Erro: {e.Message}");
            }
        }
    }
}