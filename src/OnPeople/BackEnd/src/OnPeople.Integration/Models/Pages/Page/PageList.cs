using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnPeople.Integration.Models.Pages.Page
{
    public class PageList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCounter { get; set; }
        
        public PageList() {}

        public PageList(List<T> items, int counter, int pageNumber, int pageSize) {
            TotalCounter = counter;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(counter / (double)pageSize);
            AddRange(items);
        }

        public static async Task<PageList<T>> CreatePageAsync(
            IQueryable<T> source, int pageNumber, int pageSize)
            {
                var counter = await source.CountAsync();
                var items = await source.Skip((pageNumber -1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();
                return new PageList<T>(items, counter, pageNumber, pageSize);
            }
    }
}