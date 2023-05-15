using etkinlikk.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace etkinlikk.Models
{
    public class Userr
    {

        [Key]
        public int UserrID { get; set; }


        [Required(ErrorMessage = "{0} gerekli"),Display(Name ="Eposta"), StringLength(50, MinimumLength = 6, ErrorMessage = "{0}, {2}-{1} karakter olmalı"), DataType(DataType.EmailAddress, ErrorMessage = "Geçersiz {0}")]
        public string Emaill { get; set; }



        [Required(ErrorMessage = "{0} gerekli"), Display(Name ="Şifre"),StringLength(20, MinimumLength = 6, ErrorMessage = "{0}, {2}{1} karakter olmalı"),  DataType(DataType.Password)]
        public string Passwordd { get; set; }

        [NotMapped, Display(Name = "Şifre Tekrarı"), DataType(DataType.Password), Compare("Passwordd", ErrorMessage = "Şifre ve Şifre Tekrarı aynı değil")]
        public string PasswordRepeatt{ get; set; }


        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Rol")]
        public byte RoleeID { get; set; }

        

        public Rolee Rolee { get; set; } // navigasyon için gerekli

    }
}
