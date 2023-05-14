using OnPeople.Domain.Models.Departamentos;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Domain.Models.Funcionarios;

namespace OnPeople.Domain.Models.Cargos
{
    public class Cargo
    {
        public int Id { get; set; }
        public string NomeCargo { get; set; }
        public Boolean Ativo { get; set; }
        public string DataCriacao { get; set; }
        public string DataEncerramento { get; set; }
        public int DepartamentoId { get; set; }
        public int EmpresaId { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }
    }
}