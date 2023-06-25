namespace OnPeople.Integration.Models.Dashboard
{
    public class DashboardFuncionarios 
    {
        public int CountFuncionarios { get; set; }
        public IEnumerable<string> ListaNomeFuncionario { get; set; }
        public IEnumerable<int> ListaQtdeMetas { get; set; }
    }
}