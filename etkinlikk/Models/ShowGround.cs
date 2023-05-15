using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace etkinlikk.Models
{
    public class ShowGround
    {
        [Key]
        public int ShowGroundID { get; set; }



        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "Yer Adı"), StringLength(100, MinimumLength = 3, ErrorMessage = "{0} {2} - {1} karakter olmalıdır.")]
        public string ShowGroundName { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "İlçe"), Range(1, 99, ErrorMessage = "{0} seçilmeli")]
        public int DistrictID { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "Adres Bilgisi"), StringLength(400, MinimumLength = 3, ErrorMessage = "{0} {2} - {1} karakter olmalıdır.")]
        public string Address { get; set; }

        public int? Capacity { get; set; }

        public District District { get; set; }

    }
}
