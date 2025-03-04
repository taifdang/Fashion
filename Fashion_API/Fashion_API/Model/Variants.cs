using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fashion_API.Model
{
    public class Variants
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        //constraint
        public ICollection<VariantValues> variant_values { get; set; }
        //=>SKU = 
        // variants=[
        // {"name":"Kiểu ốp",
            // values:
            // [
            // "Ôp titan",
            // "Ôp nhựa dẻo"
            // ]
        // },
        // {"name":"Dòng điện thoại",
            // values:
            // [
            // "Iphone 11",
            // "Iphone 11 Pro Max"
            // ]
        // },

    }
}
