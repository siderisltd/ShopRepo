namespace Eshop.Services.Data.Base
{
    using System.Linq;
    using Eshop.Data.Models.BaseModels.Contracts;
    using Eshop.Data.Repositories;

    public class BaseService<T> : IBaseService<T> where T : class, IBaseModel
    {
        protected readonly IRepository<T> repo;

        protected BaseService(IRepository<T> repo)
        {
            this.repo = repo;
        }

        public IQueryable<T> All()
        {
            return this.repo.All();
        }

        public T GetById(object id)
        {
           return this.repo.GetById(id);
        }

        public int SaveChanges()
        {
            return this.repo.SaveChanges();
        }
    }
}
