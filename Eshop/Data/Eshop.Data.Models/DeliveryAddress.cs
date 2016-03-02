namespace Eshop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using BaseModels;

    public class DeliveryAddress : BaseModel
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string StreetAddress { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsMain { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
