using OnPeople.Domain.Models.Cargos;
using OnPeople.Domain.Models.Contas;
using OnPeople.Domain.Models.Departamentos;
using OnPeople.Domain.Models.Empresas;

namespace OnPeople.Domain.Models.Funcionarios
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public DateTime DataAdmissao { get; set; }
        public DateTime DataDemissao { get; set; }
        public Boolean Ativo { get; set; }
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departameto { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public Conta Conta { get; set; }
        public int FuncaoId { get; set; }
        public Funcao Funcao { get; set; }
        public int DadoPessoalId { get; set; }
        public DadoPessoal DadosPessoais { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }
        public IEnumerable<FuncionarioMeta> FuncionarioMetas { get; set; }
    }
}