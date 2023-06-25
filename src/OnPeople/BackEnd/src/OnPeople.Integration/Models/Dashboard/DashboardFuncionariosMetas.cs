namespace OnPeople.Integration.Models.Dashboard
{
    public class DashboardFuncionariosMetas
    {
        public int CountMetasAssociadas { get; set; }
        public int CountMetasCumpridas { get; set; }
        public double PercentualMetasCumpridas { get; set; }
        public IEnumerable<string> ListaNomeMeta { get; set; }
        public IEnumerable<int> ListaQtdeMetas { get; set; }
    }
}