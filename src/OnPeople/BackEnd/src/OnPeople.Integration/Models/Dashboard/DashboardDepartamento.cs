namespace OnPeople.Integration.Models.Dashboard
{
    public class DashboardDepartamento 
    {
        public int CountDepartamentos { get; set; }
        public int CountDepartamentosAtivos { get; set; }
        public double PercentualDepartamentosAtivos { get; set; }
        public IEnumerable<string> ListaNomeDepartamentos { get; set; }
        public IEnumerable<int> ListaQtdeCargos { get; set; }
    }
}