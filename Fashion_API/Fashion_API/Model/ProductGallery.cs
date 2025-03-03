

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Fashion_API.Model
{
    public class ProductGallery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }        
        public Guid? imageKey { get; set; }
        public string? imageUrl { get; set; }
        //public int productId { get; set; }
        [JsonIgnore]
        //public Products products { get; set; }
        public ProductVariant productVariant { get; set; }
    }
}

