using OnPeople.Domain.Models.Funcionarios;


namespace OnPeople.Application.Dtos.Funcionarios
{
    public class DadoPessoalDto
    {
         public int Id { get; set; }
        public string CPF { get; set; }
        public string TituloEleitor { get; set; }
        public Boolean ImpedimentoEleitoral { get; set; }
        public string Identidade { get; set; }
        public string DataExpedicao { get; set; }
        public string UfEmissao { get; set; }
        public string EstadoCivil { get; set; }
        public string CarteiraTrabalho { get; set; }
        public string PisPasep { get; set; }
        public string DataExpedicaoCarteiraTrabalho { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}