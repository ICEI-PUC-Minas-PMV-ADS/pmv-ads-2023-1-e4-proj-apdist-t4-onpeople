using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnPeople.Domain.Models.Cargos;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Domain.Models.Users;

namespace OnPeople.Application.Dtos.Funcionarios
{
    public class UpdateFuncionarioDto
    {
        public int Id { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataDemissao { get; set; }
        public Boolean Ativo { get; set; }
        public int? UserId { get; set; }
        public User Users { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamentos { get; set; }
        public int CargoId { get; set; }
        public Cargo Cargos { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresas { get; set; }
        public int Funcao { get; set; }
        public IEnumerable<DadoPessoal> DadosPessoais { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }

    }
}