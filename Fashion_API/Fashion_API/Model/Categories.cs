using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fashion_API.Model
{
    public class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string name { get; set; }
        public string? slug { get; set; }      
        public int productType_id { get; set; }
        public ProductTypes productTypes { get; set; }
        public ICollection<Products> products { get; set; }
       
    }
}
