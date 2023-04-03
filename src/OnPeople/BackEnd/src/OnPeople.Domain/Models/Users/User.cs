using Microsoft.AspNetCore.Identity;
using OnPeople.Domain.Models.Cargos;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Domain.Models.Metas;

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
        public Boolean Gold { get; set; }
        public Boolean Bronze { get; set; }
        public int CodEmpresa { get; set; }
        public string NomeEmpresa { get; set; }
        public int CodCargo { get; set; }
        public int CodDepartamento { get; set; }
        public int CodFuncionario { get; set; }
        public int CodMeta { get; set; }
        public IEnumerable<UserRole> UsersRoles {get; set;}
    }
}