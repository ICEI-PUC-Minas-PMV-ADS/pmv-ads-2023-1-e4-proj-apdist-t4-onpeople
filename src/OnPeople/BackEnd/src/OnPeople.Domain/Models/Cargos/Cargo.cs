using OnPeople.Domain.Models.Departamentos;
using OnPeople.Domain.Models.Funcionarios;

namespace OnPeople.Domain.Models.Cargos
{
    public class Cargo
    {
        public int Id { get; set; }
        public string NomeCargo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataEncerramento { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
    }
}