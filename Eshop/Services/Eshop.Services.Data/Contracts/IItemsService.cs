namespace Eshop.Services.Data.Contracts
{
    using Base;
    using Eshop.Data.Models;

    public interface IItemsService : IBaseService<Item>
    {
        Item AddItem(Item itemToAdd);
    }
}
