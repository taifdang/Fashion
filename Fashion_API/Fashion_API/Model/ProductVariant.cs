using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Fashion_API.Model
{
    public class ProductVariant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int productId { get; set; }
        public int colorId { get; set; }
        public int sizeId { get;set; }          
        public Guid? imageKey { get; set; }
        public ICollection<ProductGallery> productGalleries { get; set; }
        public Products products { get; set; }
        public ProductStock productStock { get; set; }
        public Size size { get; set; }
        public Color color { get; set; }

    }
}
