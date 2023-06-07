using OnPeople.Integration.Models.Links;

namespace OnPeople.Integration.Models.Dashboard
{
    public class DashboardMetas : LinksHATEOS
    {
        public int CountMetas { get; set; }
        public int MetasAtivas { get; set; }
        public int MetasAprovadas { get; set; }
        public int MetasAssociadas { get; set; }
        public int MetasCumpridas { get; set; }
    }
}