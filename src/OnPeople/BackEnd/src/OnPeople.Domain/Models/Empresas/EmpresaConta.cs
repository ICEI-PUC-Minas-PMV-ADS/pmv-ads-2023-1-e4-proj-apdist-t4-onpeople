using OnPeople.Domain.Models.Contas;

namespace OnPeople.Domain.Models.Empresas
{
    public class EmpresaConta
    {
    public int EmpresaId { get; set; }
        public Empresa Empresas { get; set; }
        public int ContaId { get; set; }
        public Conta Contas { get; set;}
    }
}