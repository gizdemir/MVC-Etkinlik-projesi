using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace etkinlikk.Models
{
    public class ShowGrdSubCat
    {
        [Key]
        public int ShowGrdSubCatID { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "Etkinlik Yeri "), Range(1, 10000, ErrorMessage = "{0} seçilmeli")]
        public int ShowGroundID { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "Alt Kategori"), Range(1, 1000, ErrorMessage = "{0} seçilmeli")]
        public int SubCategoryID { get; set; }



        public ShowGround ShowGround { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
