using OnPeople.Domain.Models.Contas;
using OnPeople.Domain.Models.Departamentos;

namespace OnPeople.Domain.Models.Empresas
{
    public class EmpresaDepartamento
    {
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set;}
    }
}