using OnPeople.Application.Dtos.Empresas;

namespace OnPeople.Application.Dtos.Departamentos
{
    public class DepartamentoDto
    {
        public int Id { get; set; }
        public string NomeDepartamento { get; set; }
        public string Sigla { get; set; }
        public int DiretorId { get; set; }
        public int GerenteId {get; set;}
        public int SupervisorId { get; set; }
        public string DataCriacao { get; set; }
        public string DataEncerramento { get; set; }
        public Boolean Ativo { get; set; }
        public int EmpresaId { get; set; }
        public EmpresaDto Empresas { get; set; }
    }
}