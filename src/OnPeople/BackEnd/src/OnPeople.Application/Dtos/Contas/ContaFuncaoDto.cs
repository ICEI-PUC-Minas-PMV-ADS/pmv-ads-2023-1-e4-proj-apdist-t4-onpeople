
namespace OnPeople.Application.Dtos.Contas
{
    public class ContaFuncaoDto
    {
        public int ContaId { get; set; }
        public ContaDto Conta {get; set;}
        public int FuncaoId { get; set; }
        public FuncaoDto Funcao { get; set; }
    }
}