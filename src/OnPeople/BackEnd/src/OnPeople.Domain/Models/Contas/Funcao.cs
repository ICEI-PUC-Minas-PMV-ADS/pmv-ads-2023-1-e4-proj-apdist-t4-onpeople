namespace OnPeople.Domain.Models.Contas
{
    public class Funcao
    {
        public int Id { get; set; }
        public string NomeFuncao { get; set; }
        public IEnumerable<ContaFuncao> ContasFuncoes { get; set; }
    }
}