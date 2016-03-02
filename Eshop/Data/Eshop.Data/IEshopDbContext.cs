namespace Eshop.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface IEshopDbContext : IDisposable
    {
        IDbSet<Cart> Carts { get; set; }

        IDbSet<CartItem> CartItems { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Delivery> Deliveries { get; set; }

        IDbSet<DeliveryAddress> DeliveryAddress { get; set; }

        IDbSet<DeliveryOption> DeliveryOptions { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Item> Items { get; set; }

        IDbSet<ItemFeature> ItemFeatures { get; set; }

        IDbSet<PurchaseHistory> PurchaseHistories { get; set; }

        IDbSet<Rate> Rates { get; set; }

        IDbSet<Review> Reviews { get; set; }

        IDbSet<WishList> WishLists { get; set; }

        int SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
