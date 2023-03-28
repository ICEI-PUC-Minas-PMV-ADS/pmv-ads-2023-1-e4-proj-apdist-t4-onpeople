using OnPeople.Domain.Models.Departamentos;
using OnPeople.Domain.Models.Users;

namespace OnPeople.Domain.Models.Empresas
{
    public class Empresa
    {
        public int Id { get; set; }  
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string PorteEmpresa { get; set; }
        public string NaturezaJuridica { get; set; }
        public string OptanteSimples { get; set; }
        public Boolean  Filial { get; set; }
        public string NomeFantasia { get; set; }
        public Boolean Ativa { get; set; }
        public string SiglaEmpresa { get; set; }
        public string DataCadastro { get; set; }
        public string DataDesativacao { get; set; }
        public string PadraoEmail { get; set; }
        public int MatrizId { get; set; }
        public string Logotipo { get; set; }
        public int PresidenteId {get; set;}
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
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Departamento> Departamentos { get; set; }
    }
}