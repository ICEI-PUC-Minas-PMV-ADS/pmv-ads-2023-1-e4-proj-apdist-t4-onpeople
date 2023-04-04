namespace OnPeople.Integration.Models.Pages.Headers
{
    public class PageHeaders
    {
        public PageHeaders(int currentPage, int itemsPage, int itemsTotal, int totalPages) {
            this.CurrentPage = currentPage;
            this.ItemsPage = itemsPage;
            this.ItemsTotal = itemsTotal;
            this.TotalPages = totalPages;
        }

        public int CurrentPage { get; set; }
        public int ItemsPage { get; set; }
        public int ItemsTotal { get; set; }
        public int TotalPages { get; set; }
    }
}