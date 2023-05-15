using etkinlikk.Models;

namespace etkinlikk.ViewModel
{
    public class ShowGroundDetailViewModel
    {
        public ShowGround ShowGround { get; set; }
        public List<SubCategory> SubCategoryList{ get; set; }
        public List<ShowGrdSubCat> ShowGrdSubCatList{ get; set; }
        
    }
}
