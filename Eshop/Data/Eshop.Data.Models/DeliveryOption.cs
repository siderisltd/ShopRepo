namespace Eshop.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using BaseModels;

    public class DeliveryOption : BaseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MinDays { get; set; }

        public int MaxDays { get; set; }

        public decimal Price { get; set; }

        public int? DomesticDeliveryId { get; set; }

        [InverseProperty("DomesticDelivery")]
        [ForeignKey("DomesticDeliveryId")]
        public virtual Delivery DomesticDelivery { get; set; }

        public int? WorldwideDeliveryId { get; set; }

        [InverseProperty("WorldwideDelivery")]
        [ForeignKey("WorldwideDeliveryId")]
        public virtual Delivery WorldwideDelivery { get; set; }

        public int? EuropeDeliveryId { get; set; }

        [InverseProperty("EuropeDelivery")]
        [ForeignKey("EuropeDeliveryId")]
        public virtual Delivery EuropeDelivery { get; set; }
    }
}
