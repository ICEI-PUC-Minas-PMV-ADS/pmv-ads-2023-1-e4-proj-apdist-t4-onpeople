using OnPeople.Domain.Models.Empresas;

namespace OnPeople.Domain.Models.Departamentos
{
    public class DepartamentoEmpresa
    {
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set;}
    }
}