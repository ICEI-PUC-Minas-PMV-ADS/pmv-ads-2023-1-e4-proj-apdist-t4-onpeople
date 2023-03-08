using System.ComponentModel.DataAnnotations;
using OnPeople.Domain.Models.Contas;
using OnPeople.Domain.Models.Departamentos;

namespace OnPeople.Domain.Models.Empresas
{
    public class Empresa
    {
        [Key]
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
        
        public int? MatrizId { get; set; }
        
        public int? PresidenteId {get; set;}
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string PadraoEmail { get; set; }
        
        public IEnumerable<Conta> Contas { get; set; }
        
        public IEnumerable<Departamento> Departamentos { get; set; }

    }
}