using OnPeople.Domain.Models.Funcionarios;
using System.ComponentModel.DataAnnotations;

namespace OnPeople.Application.Dtos.Cargos
{
    public class CargoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string NomeCargo { get; set; }
        public Boolean Ativo { get; set; }
        public string DataCriacao { get; set; }
        public string DataEncerramento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int DepartamentoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int EmpresaId { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }

    }
}