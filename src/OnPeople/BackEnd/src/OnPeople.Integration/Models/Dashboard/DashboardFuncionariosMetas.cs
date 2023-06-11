using OnPeople.Integration.Models.Links;

namespace OnPeople.Integration.Models.Dashboard
{
    public class DashboardFuncionariosMetas: LinksHATEOS
    {
        public int CountMetasAssociadas { get; set; }
        public int CountMetasCumpridas { get; set; }
    }
}