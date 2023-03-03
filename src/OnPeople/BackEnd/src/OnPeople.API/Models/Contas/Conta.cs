namespace OnPeople.API.Models.Contas
{
    public class Conta
    {
        public string NomeCompleto { get; set; }
        public string Visao { get; set; }
        public string Foto { get; set; }
        public string DataCadastro { get; set; }
        public string DataEncerramento { get; set; }
        public Boolean Ativa { get; set; }
    }
}