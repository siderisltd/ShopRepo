namespace Eshop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using BaseModels;

    public class WishList : BaseModel
    {
        private ICollection<CartItem> wishItems;

        public WishList()
        {
            this.wishItems = new HashSet<CartItem>();
        }

        [Key, ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<CartItem> CartItems
        {
            get { return this.wishItems; }
            set { this.wishItems = value; }
        }
    }
}
