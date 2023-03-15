using Microsoft.AspNetCore.Identity;
using OnPeople.Domain.Models.Empresas;

namespace OnPeople.Domain.Models.Users
{
    public class User: IdentityUser<int>
    {
        public string NomeCompleto { get; set; }
        public string Visao { get; set; }
        public string Foto { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataEncerramento { get; set; }
        public Boolean Ativa { get; set; }      
        public Boolean Master { get; set; }
        public int? EmpresaId { get; set; }
        public Empresa Empresa {get; set;}
        public IEnumerable<UserRole> UsersRoles {get; set;}
    }
}