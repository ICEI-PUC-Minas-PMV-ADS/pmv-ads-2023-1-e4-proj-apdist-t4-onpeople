

using Microsoft.AspNetCore.Mvc;

using OnPeople.API.Models.Empresas;

namespace OnPeople.API.Controllers.Empresas;

    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        public IEnumerable<Empresa> _empresa = new Empresa[] 
            {
                new Empresa() {
                    EmpresaId = 1,
                    NomeEmpresa = "Xing Ling Industria do Brasil",
                    NomeFantasia = "Xing Ling Corporation",
                    SiglaEmpresa = "XLC",
                    Ativa = true,
                    DataCadastro = DateTime.Now.ToString(),
                    Filial = false
                },
                                new Empresa() {
                    EmpresaId = 2,
                    NomeEmpresa = "Xing Ling Industry International",
                    NomeFantasia = "Xing Ling Corporation",
                    SiglaEmpresa = "XLC",
                    Ativa = true,
                    DataCadastro = DateTime.Now.AddDays(1).ToString(),
                    Filial = false
                },
            };
        public EmpresaController()
        {

        }

        
        [HttpGet]
        public IEnumerable<Empresa> Get()
        {
            return _empresa;
        }

        [HttpGet("{id}")]
        public IEnumerable<Empresa> GetById(int id)
        {
            return _empresa.Where(empresa => empresa.EmpresaId == id);
        }
    }
