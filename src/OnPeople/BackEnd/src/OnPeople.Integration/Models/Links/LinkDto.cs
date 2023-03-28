
namespace OnPeople.Integration.Models.Links
{
    public class LinkDto
    {
        public string Id { get; set; }
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Metodo { get; set; }

        public LinkDto(string id, string href, string rel, string metodo) 
        {
            this.Id = id;
            this.Href = href;
            this.Rel = rel;
            this.Metodo = metodo;
        }
    }
    public class LinksHATEOS
    {
        public List<LinkDto> Links { get; set; } = new List<LinkDto>(); 
    }
}