using OnPeople.Integration.Models.Links;

namespace OnPeople.Integration.Models.Dashboard
{
    public class DashboardCargos : LinksHATEOS
    {
        public int CountCargos { get; set; }
        public int CountCargosAtivos { get; set; }
    }
}