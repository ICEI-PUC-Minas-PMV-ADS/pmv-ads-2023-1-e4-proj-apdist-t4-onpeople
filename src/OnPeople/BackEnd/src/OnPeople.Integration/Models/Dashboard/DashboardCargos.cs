namespace OnPeople.Integration.Models.Dashboard
{
    public class DashboardCargos
    {
        public int CountCargos { get; set; }
        public int CountCargosAtivos { get; set; }
        public double PercentualCargosAtivos { get; set; }
        public IEnumerable<string> ListaNomeCargo{ get; set; }
        public IEnumerable<int> ListaQtdeFuncionarios { get; set; }
    }
}