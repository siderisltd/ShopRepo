namespace Eshop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.BaseModels.Contracts;

    public class EshopDbContext : IdentityDbContext<User>, IEshopDbContext
    {
        public EshopDbContext()
            : base("EshopDbConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Cart> Carts { get; set; }

        public IDbSet<CartItem> CartItems { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Delivery> Deliveries { get; set; }

        public IDbSet<DeliveryAddress> DeliveryAddress { get; set; }

        public IDbSet<DeliveryOption> DeliveryOptions { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Item> Items { get; set; }

        public IDbSet<ItemFeature> ItemFeatures { get; set; }

        public IDbSet<PurchaseHistory> PurchaseHistories { get; set; }

        public IDbSet<Rate> Rates { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public IDbSet<WishList> WishLists { get; set; }

        public static EshopDbContext Create()
        {
            return new EshopDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }


        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                            e.Entity is IAuditInfo &&
                            ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo) entry.Entity;

                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }


        }
    }
}