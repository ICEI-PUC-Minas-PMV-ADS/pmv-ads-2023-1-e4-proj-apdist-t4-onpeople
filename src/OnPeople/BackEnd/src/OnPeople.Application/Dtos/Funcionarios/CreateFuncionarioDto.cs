using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnPeople.Domain.Models.Cargos;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Domain.Models.Empresas;
using OnPeople.Domain.Models.Funcionarios;
using OnPeople.Domain.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace OnPeople.Application.Dtos.Funcionarios
{
    public class CreateFuncionarioDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string DataAdmissao { get; set; }
        public string NomeCompleto { get; set; }
        public string DataDemissao { get; set; }
        public Boolean Ativo { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int DepartamentoId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int CargoId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int EmpresaId { get; set; }
        public int Funcao { get; set; }
        public IEnumerable<DadoPessoal> DadosPessoais { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }

    }
}