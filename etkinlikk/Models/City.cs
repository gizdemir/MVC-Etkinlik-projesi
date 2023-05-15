using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace etkinlikk.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "İl Adı"), StringLength(30, MinimumLength = 3, ErrorMessage = "{0} {2} - {1} karakter olmalıdır.")]
        public string CityName { get; set; }



    }
}

