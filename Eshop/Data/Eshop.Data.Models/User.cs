namespace Eshop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using BaseModels.Contracts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser, IBaseModel
    {
        private ICollection<DeliveryAddress> deliveryAddresses;
        private ICollection<Item> items;

        public User()
        {
            this.CreatedOn = DateTime.Now;
            this.deliveryAddresses = new HashSet<DeliveryAddress>();
            this.items = new HashSet<Item>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual WishList WishList { get; set; }

        public virtual PurchaseHistory PurchaseHistory { get; set; }

        public virtual ICollection<Item> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }

        public virtual ICollection<DeliveryAddress> DeliveryAddresses
        {
            get { return this.deliveryAddresses; }
            set { this.deliveryAddresses = value; }
        }


        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(this.GenerateUserIdentity(manager));
        }
    }
}
