using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace etkinlikk.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "Kategori Adı"), StringLength(20, MinimumLength = 3, ErrorMessage = "{0} {2} - {1} karakter olmalıdır.")]
        public string CategoryName { get; set; }

    }
}
