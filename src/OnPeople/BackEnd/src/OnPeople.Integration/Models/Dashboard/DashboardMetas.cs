using OnPeople.Integration.Models.Links;

namespace OnPeople.Integration.Models.Dashboard
{
    public class DashboardMetas : LinksHATEOS
    {
        public int CountMetas { get; set; }
        public int CountMetasAprovadas { get; set; }
        public int CountMetasCumpridas { get; set; }
    }
}