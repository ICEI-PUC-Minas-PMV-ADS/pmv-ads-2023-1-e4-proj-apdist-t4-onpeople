using System.ComponentModel.DataAnnotations;
using OnPeople.Application.Dtos.Contas;
using OnPeople.Application.Dtos.Departamentos;

namespace OnPeople.Application.Dtos.Empresas
{
    public class EmpresaDto
    {
        public int Id { get; set; }  

        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        StringLength(50, MinimumLength = 4, ErrorMessage = "O campo {0} deve possuir um intervalo de 4 a 50 caracteres")]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        StringLength(20, MinimumLength = 4, ErrorMessage = "O campo {0} deve possuir um intervalo de 4 a 20 caracteres")]
        public string NomeFantasia { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        StringLength(7, MinimumLength = 3, ErrorMessage = "O campo {0} deve possuir um intervalo de 3 a 7 caracteres")]
        public string Sigla { get; set; }
        
        public Boolean Ativa { get; set; }
                
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string DataCadastro { get; set; }
        
        public string DataDesativacao { get; set; }
        
        public Boolean  Filial { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string PadraoEmail { get; set; }
        
        public IEnumerable<ContaDto> Contas { get; set; }
        
        public IEnumerable<DepartamentoDto> Departamentos { get; set; }
    }
}