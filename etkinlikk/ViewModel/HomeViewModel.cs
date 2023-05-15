using etkinlikk.Models;

namespace etkinlikk.ViewModel
{
    public class HomeViewModel
    {
        public List<Category> CategoryList { get; set; }
        public List<SubCategory> SubCategoryList { get; set; }
        public List<City> CityList { get; set; }
        public List<District> DistrictList { get; set; }
        public int? SelectedCategoryID { get; set; }
        public int? SelectedCityID { get; set; }
        public SubCategory? SelectedSubCategory { get; set; }
        public List<ShowGround> ShowGroundList { get; set; }

    }
}
