using Fashion_API.Model;

namespace Fashion_API.DTO
{
    public class VariantDTO
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int colorId { get; set; }
        public int sizeId { get; set; }
        //public Guid? imageKey { get; set; }
        public int quantity { get; set; }       
        public IFormFile? file { get; set; }

    }
}
