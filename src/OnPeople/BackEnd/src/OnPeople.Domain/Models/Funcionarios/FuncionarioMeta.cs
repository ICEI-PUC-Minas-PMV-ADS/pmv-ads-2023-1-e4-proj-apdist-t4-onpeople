
using OnPeople.Domain.Models.Funcionarios;

namespace OnPeople.Domain.Models.Funcionarios
{
    public class FuncionarioMeta
    {
        public int Id { get; set; }
        public int MetaId { get; set; }
        public Meta Meta { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public Boolean MetaCumprida { get; set; }
        public string InicioEfetivo { get; set; }
        public string FimEfetivo { get; set; }
        public int DiasEfetivo { get; set; }
        public string InicioAcordado { get; set; }
        public string FimAcordado { get; set; }
        public int DiasAcordado { get; set; }
    }
}