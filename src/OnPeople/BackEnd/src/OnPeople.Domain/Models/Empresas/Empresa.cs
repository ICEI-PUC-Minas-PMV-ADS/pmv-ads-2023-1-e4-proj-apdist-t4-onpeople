using System.ComponentModel.DataAnnotations;
using OnPeople.Domain.Models.Contas;
using OnPeople.Domain.Models.Departamentos;

namespace OnPeople.Domain.Models.Empresas
{
    public class Empresa
    {
        public int Id { get; set; }  
        public string NomeEmpresa { get; set; }
        public string NomeFantasia { get; set; }
        public string Sigla { get; set; }
        public Boolean Ativa { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataDesativacao { get; set; }
        public Boolean  Filial { get; set; }
        public int? MatrizId { get; set; }
        public int? PresidenteId {get; set;}
        public string PadraoEmail { get; set; }
        public IEnumerable<Conta> Contas { get; set; }
        public IEnumerable<Departamento> Departamentos { get; set; }

    }
}