using etkinlikk.Data;
using etkinlikk.Models;
using etkinlikk.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace etkinlikk.Controllers
{
    public class HomeController : Controller
    {
        private readonly etkinlikkDBContext _context;

        public HomeController(etkinlikkDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? kat, int? il, int? ilce, int? altkat, string sira, string aranan) //? nullable, sayfa açılınca il seçimi yapılmadıoğı için il null olabilir,kat içinde geçerli
        {


            HomeViewModel x = new HomeViewModel();
            x.CategoryList = await _context.Categories.ToListAsync();

            x.SelectedSubCategory = await _context.SubCategories.FirstOrDefaultAsync(a => a.SubCategoryID == altkat);

            x.SubCategoryList = await _context.SubCategories.Where(a => a.CategoryID == kat).ToListAsync(); // seçili kategorinin çocuklarının listesi.

            if (x.SubCategoryList.Count == 0 && altkat != null)
            {
                x.SubCategoryList = await _context.SubCategories.Where(a => a.CategoryID == x.SelectedSubCategory.CategoryID).ToListAsync(); // seçili kategorinin çocuklarının listesi.
            }


            x.CityList = await _context.Cities.ToListAsync();// db ye gidip dataların çekilme işi burada yapılır

            x.DistrictList = await _context.Districts.Where(a => a.CityID == il).ToListAsync();

            x.SelectedCategoryID = kat;

            x.SelectedCityID = il;

            List<int> ShowGroundListBySubCategoryID = _context.ShowGrdSubCats.Where(a => a.SubCategoryID == altkat || altkat == null).Select(a => a.ShowGroundID).ToList();



            //List<int> seçiliİleAitİlçelerinIDListesi = x.DistrictList.Select(b => b.DistrictID).ToList();
            x.ShowGroundList = await _context.ShowGrounds.
                           Where(a => a.DistrictID == ilce || ilce == null).
                           Where(a => x.DistrictList.Select(b => b.DistrictID).Contains(a.DistrictID) || il == null).
                           Where(a => ShowGroundListBySubCategoryID.Contains(a.ShowGroundID) || altkat == null).
                           Where(a => a.ShowGroundName.Contains(aranan) || aranan == null).
                           //OrderBy(a => a.ShowGroundName).
                           OrderBy(a => sira == "isim" ? a.ShowGroundName : sira == "ilce" ? a.District.DistrictName : null).
                           ThenByDescending(a => sira == "isimters" ? a.ShowGroundName : sira == "ilceters" ? a.District.DistrictName : null).
                           Include(a => a.District).Take(12).ToListAsync();


            return View(x);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AramayaGit(string arananMetin)
        {

            return RedirectToAction("", "", new { aranan = arananMetin });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}