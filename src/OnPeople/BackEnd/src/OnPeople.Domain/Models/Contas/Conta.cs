using OnPeople.Domain.Models.Empresas;

namespace OnPeople.Domain.Models.Contas
{
    public class Conta
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Visao { get; set; }
        public string Foto { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataEncerramento { get; set; }
        public Boolean Ativa { get; set; }
        IEnumerable<ContaFuncao> ContasFuncoes {get; set;}
        IEnumerable<Empresa> Empresas {get; set;}
    }
}