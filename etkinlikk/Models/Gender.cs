using System.ComponentModel.DataAnnotations;

namespace etkinlikk.Models
{
    public class Gender
    {
        [Key]

        public int GenderId { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "Cinsiyet Adı"), StringLength(30, MinimumLength = 5, ErrorMessage = "{0} {2} - {1} karakter olmalıdır.")]
        public string GenderName { get; set; }


    }
}
