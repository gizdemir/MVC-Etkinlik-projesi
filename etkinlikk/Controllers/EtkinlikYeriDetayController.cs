using etkinlikk.Data;
using etkinlikk.Models;
using etkinlikk.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace etkinlikk.Controllers
{
    public class EtkinlikYeriDetayController : Controller
    {


        private readonly etkinlikkDBContext _context;

        public EtkinlikYeriDetayController(etkinlikkDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            ShowGroundDetayViewModel x = new ShowGroundDetayViewModel();

            x.ShowGround = await _context.ShowGrounds.Include(a => a.District).ThenInclude(b => b.City).FirstOrDefaultAsync(a => a.ShowGroundID == id);
            x.RelatedShowGroundList = await _context.ShowGrounds.Include(a => a.District).Where(a => a.DistrictID == x.ShowGround.DistrictID && a.ShowGroundID != id).Take(5).ToListAsync();

            return View(x);
        }
    }
}
