namespace Eshop.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.IO;
    using BaseModels;
    using Enums;

    public class Image : BaseModel
    {
        public int Id { get; set; }

        [StringLength(300)]
        public string Title { get; set; }

        public ImageType ImageType { get; set; }

        public string PathOriginalSize { get; set; }

        public string PathResizedImage { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        [Required]
        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

        public bool IsMain { get; set; }

        [NotMapped]
        public Stream Stream { get; set; }
    }
}
