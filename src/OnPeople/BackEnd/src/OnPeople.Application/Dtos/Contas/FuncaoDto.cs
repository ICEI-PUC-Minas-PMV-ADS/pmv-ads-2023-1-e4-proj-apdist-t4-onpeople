

namespace OnPeople.Application.Dtos.Contas
{
    public class FuncaoDto
    {
        public int Id { get; set; }
        public string NomeFuncao { get; set; }
        public IEnumerable<ContaFuncaoDto> ContasFuncoes { get; set; }
    }
}