namespace Eshop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using BaseModels;
    using System.Collections.Generic;

    public class Item : BaseModel
    {
        private ICollection<ItemFeature> itemFeatures;
        private ICollection<Image> images;
        private ICollection<Rate> rating;
        private ICollection<Review> reviews;

        public Item()
        {
            this.itemFeatures = new HashSet<ItemFeature>();
            this.images = new HashSet<Image>();
            this.rating = new HashSet<Rate>();
            this.reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountPercentage { get; set; }

        public int DeliveryId { get; set; }

        [ForeignKey("DeliveryId")]
        public virtual Delivery Delivery { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }

        public virtual ICollection<Rate> Rating
        {
            get { return this.rating; }
            set { this.rating = value; }
        }

        public virtual ICollection<ItemFeature> ItemFeatures
        {
            get { return this.itemFeatures; }
            set { this.itemFeatures = value; }
        }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }
    }
}
