namespace Eshop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using BaseModels;

    public class PurchaseHistory : BaseModel
    {
        private ICollection<CartItem> wishItems;

        public PurchaseHistory()
        {
            this.wishItems = new HashSet<CartItem>();
        }

        [Key, ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }

        public virtual ICollection<CartItem> WishItems
        {
            get { return this.wishItems; }
            set { this.wishItems = value; }
        }
    }
}
