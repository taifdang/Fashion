using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fashion_API.Model
{
    public class VariantValues
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int variant_id { get; set; }
        public string value { get; set; }
        public string? image { get; set; }
        //constraint
        public Variants variants { get; set; }
            //variant_combination => SKU (int-int => string=>string)
            //variant_values:[
            //{variant_combination:[
            //  "Op tian",
            //  "Iphone 11"
            //],
            //new_price:100000,
            //stock:10},
            //{variant_combination:[
            //  "Op nhua",
            //  "Iphone 11 pro max"
            //],
            //new_price:100000,
            //stock:10},
        //]
    }
}
