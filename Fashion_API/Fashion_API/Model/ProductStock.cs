using System.ComponentModel.DataAnnotations;

namespace Fashion_API.Model
{
    public class ProductStock
    {
        public int id { get; set; }
        public int productVariantId { get; set; }
        public int quantity { get; set; }        
        public ProductVariant productVariant { get; set; }
    }
}
