using System.ComponentModel.DataAnnotations;
using OnPeople.Application.Dtos.Contas;
using OnPeople.Application.Dtos.Departamentos;

namespace OnPeople.Application.Dtos.Empresas
{
    public class EmpresaDto
    {
        public int Id { get; set; }  
        public string NomeEmpresa { get; set; }
        public string NomeFantasia { get; set; }
        public string Sigla { get; set; }
        public Boolean Ativa { get; set; }
        public string DataCadastro { get; set; }
        public string DataDesativacao { get; set; }
        public Boolean  Filial { get; set; }
        public int MatrizId { get; set; }
        public int PresidenteId {get; set;}
        public string PadraoEmail { get; set; }
        public IEnumerable<ContaDto> EmpresasContas { get; set; }
        public IEnumerable<DepartamentoDto> Departamentos { get; set; }
    }
}