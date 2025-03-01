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
        public string? image { get; set; }
        public int category_id { get;set; }
        public Categories categories { get; set; }


    }
}
