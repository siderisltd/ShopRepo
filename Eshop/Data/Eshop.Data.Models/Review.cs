namespace Eshop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using BaseModels;

    public class Review : BaseModel
    {
        public int Id { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }
    }
}
