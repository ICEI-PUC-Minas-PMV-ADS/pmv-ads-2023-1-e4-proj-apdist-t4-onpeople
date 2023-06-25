namespace OnPeople.Integration.Models.Dashboard
{
    public class DashboardEmpresa
    {
        public int CountEmpresas { get; set; }
        public int CountEmpresasAtivas { get; set; }
        public double PercentualEmpresasAtivas { get; set; }
        public int CountFiliais { get; set; }
        public double PercentualFiliais { get; set; }
        public int CountFiliaisAtivas { get; set; }
        public double PercentualFiliaisAtivas { get; set; }
        public double PercentualFiliaisAtivas2 { get; set; }
        public IEnumerable<string> ListaNomeEmpresa { get; set; }
        public IEnumerable<int> ListaQtdeDepartamentos { get; set; }
    }
}