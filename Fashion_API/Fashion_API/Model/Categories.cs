using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fashion_API.Model
{
    public class Categories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        //[Required]
        //[StringLength(200, MinimumLength = 1)]
        public string name { get; set; }
        public string? image { get; set; }
        //public string? slug { get; set; }      
        public int type_id { get; set; }
        //constraint
        public ProductTypes product_types { get; set; }
        public ICollection<Products> products { get; set; }
       
    }
}
