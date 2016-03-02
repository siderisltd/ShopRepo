namespace Eshop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using BaseModels;

    public class CartItem : BaseModel
    {
        public int Id { get; set; }

        [Required]
        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string CartId { get; set; }

        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }

        public string WishListId { get; set; }

        [ForeignKey("WishListId")]
        public virtual WishList WishList { get; set; }

        public string PurchaseHistoryId { get; set; } 

        [ForeignKey("PurchaseHistoryId")]
        public virtual PurchaseHistory PurchaseHistory { get; set; }
    }
}
