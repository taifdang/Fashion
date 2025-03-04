using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Fashion_API.Model
{
    public class ProductVariant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int product_id { get; set; }      
        //public int colorId { get; set; }
        //public int sizeId { get; set; }
        //public Guid? imageKey { get; set; }
        //public ICollection<ProductGallery> productGalleries { get; set; }
        //[JsonIgnore]
        //public Products products { get; set; }
        //[JsonIgnore]

        //public ProductStock productStock { get; set; }
        //[JsonIgnore]
        //public Size size { get; set; }
        //[JsonIgnore]
        //public Color color { get; set; }
        public double price { get; set; }
        public double new_price { get; set; }
        public int stock { get; set; }
        //combination [variant_id - value]
        public string sku { get; set; }
        //constraint
        public Products products { get; set; }

    }

}
