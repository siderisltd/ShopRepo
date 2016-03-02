namespace Eshop.Services.Data.Base
{
    using System.Linq;
    using Eshop.Data.Models.BaseModels.Contracts;

    public interface IBaseService<T> where T : class, IBaseModel
    {
        IQueryable<T> All();

        T GetById(object id);

        int SaveChanges();
    }
}
