

using System.ComponentModel.DataAnnotations;
using OnPeople.Application.Dtos.Empresas;

namespace OnPeople.Application.Dtos.Contas
{
    public class ContaDto
    {
        
        public int Id { get; set; }
        public string NomeCompleto { get; set; } 
        public string Visao { get; set; }
        public string Foto { get; set; }
        public string DataCadastro { get; set; }
        public string DataEncerramento { get; set; }
        public Boolean Ativa { get; set; }
        IEnumerable<ContaFuncaoDto> ContasFuncoes {get; set;}
        public int EmpresaId { get; set; }   
        EmpresaDto Empresas {get; set;}
    }
}