using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace etkinlikk.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryID { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "Alt Kategori Adı"), StringLength(50, MinimumLength = 3, ErrorMessage = "{0} {2} - {1} karakter olmalıdır.")]
        public string SubCategoryName { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "Kategori"), Range(1, 99, ErrorMessage = "{0} seçilmeli")]
        public int CategoryID { get; set; }




        public Category Category { get; set; }
    }
}
