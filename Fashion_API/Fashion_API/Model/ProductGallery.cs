

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fashion_API.Model
{
    public class ProductGallery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }        
        public Guid? imageKey { get; set; }
        public string? imageUrl { get; set; }
        public int productId { get; set; }
        public Products products { get; set; }
    }
}

