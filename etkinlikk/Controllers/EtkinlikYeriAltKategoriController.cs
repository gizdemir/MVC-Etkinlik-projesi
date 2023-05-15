using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using etkinlikk.Data;
using etkinlikk.Models;

namespace etkinlikk.Controllers
{
    public class EtkinlikYeriAltKategoriController : Controller
    {
        private readonly etkinlikkDBContext _context;

        public EtkinlikYeriAltKategoriController(etkinlikkDBContext context)
        {
            _context = context;
        }

        // GET: EtkinlikYeriAltKategori
        public async Task<IActionResult> Index()
        {
            var etkinlikkDBContext = _context.ShowGrdSubCat.Include(s => s.ShowGround).Include(s => s.SubCategory);
            return View(await etkinlikkDBContext.ToListAsync());
        }

        // GET: EtkinlikYeriAltKategori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShowGrdSubCat == null)
            {
                return NotFound();
            }

            var showGrdSubCat = await _context.ShowGrdSubCat
                .Include(s => s.ShowGround)
                .Include(s => s.SubCategory)
                .FirstOrDefaultAsync(m => m.ShowGrdSubCatID == id);
            if (showGrdSubCat == null)
            {
                return NotFound();
            }

            return View(showGrdSubCat);
        }

        // GET: EtkinlikYeriAltKategori/Create
        public IActionResult Create()
        {
            ViewData["ShowGroundID"] = new SelectList(_context.ShowGrounds, "ShowGroundID", "Address");
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "SubCategoryID", "SubCategoryName");
            return View();
        }

        // POST: EtkinlikYeriAltKategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShowGrdSubCatID,ShowGroundID,SubCategoryID")] ShowGrdSubCat showGrdSubCat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(showGrdSubCat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShowGroundID"] = new SelectList(_context.ShowGrounds, "ShowGroundID", "Address", showGrdSubCat.ShowGroundID);
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "SubCategoryID", "SubCategoryName", showGrdSubCat.SubCategoryID);
            return View(showGrdSubCat);
        }

        // GET: EtkinlikYeriAltKategori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShowGrdSubCat == null)
            {
                return NotFound();
            }

            var showGrdSubCat = await _context.ShowGrdSubCat.FindAsync(id);
            if (showGrdSubCat == null)
            {
                return NotFound();
            }
            ViewData["ShowGroundID"] = new SelectList(_context.ShowGrounds, "ShowGroundID", "Address", showGrdSubCat.ShowGroundID);
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "SubCategoryID", "SubCategoryName", showGrdSubCat.SubCategoryID);
            return View(showGrdSubCat);
        }

        // POST: EtkinlikYeriAltKategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShowGrdSubCatID,ShowGroundID,SubCategoryID")] ShowGrdSubCat showGrdSubCat)
        {
            if (id != showGrdSubCat.ShowGrdSubCatID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(showGrdSubCat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowGrdSubCatExists(showGrdSubCat.ShowGrdSubCatID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShowGroundID"] = new SelectList(_context.ShowGrounds, "ShowGroundID", "Address", showGrdSubCat.ShowGroundID);
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "SubCategoryID", "SubCategoryName", showGrdSubCat.SubCategoryID);
            return View(showGrdSubCat);
        }

        // GET: EtkinlikYeriAltKategori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShowGrdSubCat == null)
            {
                return NotFound();
            }

            var showGrdSubCat = await _context.ShowGrdSubCat
                .Include(s => s.ShowGround)
                .Include(s => s.SubCategory)
                .FirstOrDefaultAsync(m => m.ShowGrdSubCatID == id);
            if (showGrdSubCat == null)
            {
                return NotFound();
            }

            return View(showGrdSubCat);
        }

        // POST: EtkinlikYeriAltKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShowGrdSubCat == null)
            {
                return Problem("Entity set 'etkinlikkDBContext.ShowGrdSubCat'  is null.");
            }
            var showGrdSubCat = await _context.ShowGrdSubCat.FindAsync(id);
            if (showGrdSubCat != null)
            {
                _context.ShowGrdSubCat.Remove(showGrdSubCat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowGrdSubCatExists(int id)
        {
          return _context.ShowGrdSubCat.Any(e => e.ShowGrdSubCatID == id);
        }
    }
}
