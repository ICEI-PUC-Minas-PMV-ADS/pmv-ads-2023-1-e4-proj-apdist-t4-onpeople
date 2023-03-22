using System.Text.Json;
using OnPeople.Integration.Models.Pages.Headers;

namespace OnPeople.API.Extensions.Pages
{
    public static class Pagination
    {
        public static void CreatePagination(this HttpResponse responsePagination, int currentPage, int itemsPage, int totalItems, int totalPages)
        {
            var pagination = new PageHeaders(currentPage, itemsPage, totalItems, totalPages);

            var options = new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            responsePagination.Headers.Add("Pagination", JsonSerializer.Serialize(pagination, options));
            responsePagination.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}