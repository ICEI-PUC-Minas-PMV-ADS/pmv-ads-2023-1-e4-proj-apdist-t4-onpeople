using OnPeople.Application.Dtos.Empresas;
using OnPeople.Domain.Models.Cargos;
using OnPeople.Integration.Models.Links;
using System.ComponentModel.DataAnnotations;

namespace OnPeople.Application.Dtos.Departamentos
{
    public class DepartamentoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NomeDepartamento { get; set; }
        public string Sigla { get; set; }
        public int DiretorId { get; set; }
        public int GerenteId {get; set;}
        public int SupervisorId { get; set; }
        public string DataCriacao { get; set; }
        public string DataEncerramento { get; set; }
        public Boolean Ativo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int EmpresaId { get; set; }
        public IEnumerable<Cargo> Cargos { get; set; }
        
    }
}