using System.ComponentModel.DataAnnotations;
using OnPeople.Application.Dtos.Departamentos;
using OnPeople.Domain.Models.Users;
using OnPeople.Integration.Models.Links;

namespace OnPeople.Application.Dtos.Empresas
{
    public class EmpresaDto : LinksHATEOS
    {
        public int Id { get; set; }  

        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        StringLength(200, MinimumLength = 4, ErrorMessage = "O campo {0} deve possuir um intervalo de 4 a 200 caracteres")]
        public string RazaoSocial { get; set; }
        
        [StringLength(50, ErrorMessage = "O campo {0} deve possuir no máximo a 50 caracteres")]
        public string PorteEmpresa { get; set; }
        
        [StringLength(200, ErrorMessage = "O campo {0} deve possuir no máximo a 200 caracteres")]
        public string NaturezaJuridica { get; set; }
        
        [StringLength(20, ErrorMessage = "O campo {0} deve possuir no máximo a 20 caracteres")]
        public string OptanteSimples { get; set; }
        
        public Boolean  Filial { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        StringLength(100, MinimumLength = 4, ErrorMessage = "O campo {0} deve possuir um intervalo de 4 a 100 caracteres")]
        public string NomeFantasia { get; set; }

        public Boolean Ativa { get; set; }

            public string SiglaEmpresa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string DataCadastro { get; set; }

        public string DataDesativacao { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        StringLength(40, MinimumLength = 5, ErrorMessage = "O campo {0} deve possuir um intervalo de 5 a 40 caracteres")]
        public string PadraoEmail { get; set; }
        
        public int MatrizId { get; set; }
                
        public string Logotipo { get; set; }
        
        public int? PresidenteId {get; set;}
        
        public string TipoLogradouro { get; set; }
        
        public string Logradouro { get; set; }
        
        public string Numero { get; set; }
        
        public string Complemento { get; set; } 
        
        public string Bairro { get; set; }
        
        public string CEP { get; set; }
        
        public string DDD { get; set; }
        
        public string Telefone { get; set; }
        
        public string Email { get; set; }
        
        public string AtividadePrincipal { get; set; }
        
        public string PaisId { get; set; }
        
        public string SiglaPaisIso2 { get; set; }
        
        public string SiglaPaisIso3 { get; set; }
        
        public string NomePais { get; set; }
        
        public int EstadoId { get; set; }
        
        public string Estado { get; set; }
        
        public string SiglaEstado { get; set; }
        
        public int EstadoIbgeId { get; set; }
        
        public int CidadeId { get; set; }
        
        public string Cidade { get; set; }
        
        public int CidadeIbgeId { get; set; }
        
        public string CidadeSiafiId { get; set; }
        
        public IEnumerable<DepartamentoDto> Departamentos { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}