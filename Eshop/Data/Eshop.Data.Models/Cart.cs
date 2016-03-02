namespace Eshop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using BaseModels;

    public class Cart : BaseModel
    {
        private ICollection<CartItem> cartItems;

        public Cart()
        {
            this.cartItems = new HashSet<CartItem>();
        }

        [Key, ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<CartItem> CartItems
        {
            get { return this.cartItems; }
            set { this.cartItems = value; }
        }
    }
}
