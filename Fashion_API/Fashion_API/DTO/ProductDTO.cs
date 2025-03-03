using Fashion_API.Model;
using System.ComponentModel.DataAnnotations;

namespace Fashion_API.DTO
{
    public class ProductDTO
    {
        public int id { get; set; }    
        public string name { get; set; }    
        public double price { get; set; }
        public double? discount { get; set; }
        public string? description { get; set; }
        //public Guid? image { get; set; }
        public int category_id { get; set; }   
        public List<ProductGallery>? productGalleries { get; set; }
        public IFormFile? file { get; set; }
    }
}
