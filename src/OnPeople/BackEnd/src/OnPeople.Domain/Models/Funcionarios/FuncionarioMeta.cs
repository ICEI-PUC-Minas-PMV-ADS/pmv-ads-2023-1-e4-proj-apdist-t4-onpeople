using OnPeople.Domain.Models.Metas;

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
        public DateTime InicioEfetivo { get; set; }
        public DateTime FimEfetivo { get; set; }
        public int DiasEfetivo { get; set; }
        public DateTime InicioAcordado { get; set; }
        public DateTime FimAcordado { get; set; }
        public int DiasAcordado { get; set; }
    }
}