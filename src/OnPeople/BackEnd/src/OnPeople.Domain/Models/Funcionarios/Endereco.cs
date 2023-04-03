namespace OnPeople.Domain.Models.Funcionarios
{
    public class Endereco
    {
        public int  Id { get; set; }
        public string TipoEndereco { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Pais { get; set; }
        public string CaixaPostal { get; set; }
        public string ComplementoEndereco { get; set; }
        public DateTime DataCriação { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionarios { get; set; }
    }
}