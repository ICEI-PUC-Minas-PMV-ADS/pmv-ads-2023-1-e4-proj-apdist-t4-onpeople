namespace OnPeople.Domain.Models.Funcionarios
{
    public class DadoPessoal
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string TituloEleitor { get; set; }
        public Boolean ImpedimentoEleitora { get; set; }
        public string Identidade { get; set; }
        public DateTime DataExpedicao { get; set; }
        public string UfEmissao { get; set; }
        public String EstadoCivil { get; set; }
        public string CarteiraTrabalho { get; set; }
        public String PisPasep { get; set; }
        public DateTime DataExpedicaoCarteiraTrabalho { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionarios { get; set; }
    }
}