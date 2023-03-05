namespace OnPeople.Domain.Models.Contas
{
    public class ContaFuncao
    {
        public int ContaId { get; set; }
        public Conta Conta {get; set;}
        public int FuncaoId { get; set; }
        public Funcao Funcao { get; set; }
    }
}