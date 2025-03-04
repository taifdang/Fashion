

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
        //public Guid? imageKey { get; set; }
        public int product_id { get; set; }
        public string? image_url { get; set; }          
        //public Products products { get; set; }
        //public int variant_id { get; set; }
        //[JsonIgnore]
        //public ProductVariant product_variant { get; set; }

        //constraint
        public Products products { get; set; }
    }
}

