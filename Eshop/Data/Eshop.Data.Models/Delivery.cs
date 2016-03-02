namespace Eshop.Data.Models
{
    using System.Collections.Generic;
    using BaseModels;

    public class Delivery : BaseModel
    {
        private ICollection<DeliveryOption> domesticDelivery;
        private ICollection<DeliveryOption> worldwideDelivery;
        private ICollection<DeliveryOption> europeDelivery;

        public Delivery()
        {
            this.domesticDelivery = new HashSet<DeliveryOption>();
            this.worldwideDelivery = new HashSet<DeliveryOption>();
            this.europeDelivery = new HashSet<DeliveryOption>();
        }

        public int Id { get; set; }


        public virtual ICollection<DeliveryOption> WorldwideDelivery
        {
            get { return this.worldwideDelivery; }
            set { this.worldwideDelivery = value; }
        }

        public virtual ICollection<DeliveryOption> EuropeDelivery
        {
            get { return this.europeDelivery; }
            set { this.europeDelivery = value; }
        }

        public virtual ICollection<DeliveryOption> DomesticDelivery
        {
            get { return this.domesticDelivery; }
            set { this.domesticDelivery = value; }
        }
    }
}
