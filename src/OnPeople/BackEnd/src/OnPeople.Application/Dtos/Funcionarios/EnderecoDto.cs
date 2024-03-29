using OnPeople.Domain.Models.Cargos;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Domain.Models.Users;

namespace OnPeople.Application.Dtos.Funcionarios
{
    public class EnderecoDto
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
        public string DataCriação { get; set; }
        public string DataUltimaAtualizacao { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}