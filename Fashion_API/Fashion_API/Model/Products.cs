using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fashion_API.Model
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string name { get; set; }
        public string? slug { get;set; }
        [Required]
        public double price { get;set; }
        public double? discount { get; set; }
        public string? description { get; set; }
        public Guid? image { get; set; }
        public int categoryId { get;set; }
        public Categories categories { get; set; }
        public ICollection<ProductGallery> productGalleries { get; set; }


    }
}
