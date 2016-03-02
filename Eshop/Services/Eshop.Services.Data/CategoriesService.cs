using Eshop.Data.Repositories;

namespace Eshop.Services.Data
{
    using Contracts;
    using Eshop.Data.Models;

    public class CategoriesService : ICategoriesService
    {
        private IRepository<Category> repo;

        public CategoriesService(IRepository<Category> repo)
        {
            this.repo = repo;
        }
    }
}
