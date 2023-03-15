using OnPeople.Domain.Models.Cargos;
using OnPeople.Domain.Models.Empresas;

namespace OnPeople.Domain.Models.Departamentos
{
    public class Departamento
    {
        public int Id { get; set; }
        public string NomeDepartamento { get; set; }
        public string Sigla { get; set; }
        public int DiretorId { get; set; }
        public int GerenteId {get; set;}
        public int SupervisorId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataEncerramento { get; set; }
        public Boolean Ativo { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresas { get; set; }
        public IEnumerable<Cargo> Cargos { get; set; }
    }
}