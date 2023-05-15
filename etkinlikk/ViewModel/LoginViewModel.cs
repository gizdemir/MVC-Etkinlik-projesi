using System.ComponentModel.DataAnnotations;
namespace etkinlikk.ViewModel
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Eposta"), StringLength(50, MinimumLength = 6, ErrorMessage = "{0}, {2}{1} karakter olmalı"), DataType(DataType.EmailAddress, ErrorMessage = "Geçersiz {0}")]
        public string Emaill { get; set; }



        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Şifre"), StringLength(20, MinimumLength = 6, ErrorMessage = "{0}, {2}{1} karakter olmalı"), DataType(DataType.Password)]
        public string Passwordd { get; set; }

    }
}
