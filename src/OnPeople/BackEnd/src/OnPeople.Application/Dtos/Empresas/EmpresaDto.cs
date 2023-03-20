using System.ComponentModel.DataAnnotations;
using OnPeople.Application.Dtos.Departamentos;
using OnPeople.Domain.Models.Users;

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
        public DateTime DataCadastro { get; set; }
        
        public DateTime? DataDesativacao { get; set; }
        
        public Boolean  Filial { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        StringLength(25, MinimumLength = 5, ErrorMessage = "O campo {0} deve possuir um intervalo de 5 a 25 caracteres")]
        public string PadraoEmail { get; set; }
        
        public int? MatrizId { get; set; }

        public string Logotipo { get; set; }
        
        public IEnumerable<DepartamentoDto> Departamentos { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}