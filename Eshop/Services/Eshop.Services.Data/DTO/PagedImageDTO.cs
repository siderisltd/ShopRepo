namespace Eshop.Services.Data.DTO
{
    using System.Linq;
    using Eshop.Data.Models;

    public class PagedImageDTO
    {
        public IQueryable<Image> Images { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int AllItemsCount { get; set; }
    }
}
