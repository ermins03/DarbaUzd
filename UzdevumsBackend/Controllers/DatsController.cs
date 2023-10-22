using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UzdevumsBackend.Context;
using UzdevumsBackend.Models;

namespace UzdevumsBackend.Controllers
{
    public class DatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dats
        public async Task<IActionResult> Index()
        {
              return _context.Dati != null ? 
                          View(await _context.Dati.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Dati'  is null.");
        }

        // GET: Dats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dati == null)
            {
                return NotFound();
            }

            var dats = await _context.Dati
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dats == null)
            {
                return NotFound();
            }

            return View(dats);
        }

        [Route("api/Dats/augstakaispb")]
        [HttpGet]
        public async Task<IActionResult> GetFishWithHighLeadContent()
        {
            try
            {
                var highLeadFish = await _context.Dati
                    .Where(d => d.Parameter == "Pb") 
                    .GroupBy(d => d.Species)
                    .Select(g => new
                    {
                        Species = g.Key,
                        MaxLeadValue = g.Max(d => d.Value),
                    })
                    .OrderByDescending(f => f.MaxLeadValue)
                    .FirstOrDefaultAsync();

                if (highLeadFish != null)
                {
                    return Ok(highLeadFish);
                }
                else
                {
                    return NotFound("No fish species with lead content found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
        [Route("api/fish/agustaskvalitates")]
        [HttpGet]
        public IActionResult GetFishWithHighQuality()
        {
            try
            {
                var highQualityFish = _context.Dati
                    .GroupBy(d => d.Species)
                    .Select(g => new
                    {
                        Species = g.Key,
                        MaxQuality = g.Max(d => d.Quality),
                    })
                    .OrderByDescending(f => f.MaxQuality)
                    .FirstOrDefault();

                if (highQualityFish != null)
                {
                    return Ok(highQualityFish);
                }
                else
                {
                    return NotFound("No fish species with quality ratings found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
        // GET: Dats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Project,Trip,Longitude,Latitude,DateTime,Station,BottDepthM,SampleId,Parameter,Tissue,Species,Individuals,Value,Units,Quality")] Dats dats)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dats);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dats);
        }

        // GET: Dats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dati == null)
            {
                return NotFound();
            }

            var dats = await _context.Dati.FindAsync(id);
            if (dats == null)
            {
                return NotFound();
            }
            return View(dats);
        }

        // POST: Dats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Project,Trip,Longitude,Latitude,DateTime,Station,BottDepthM,SampleId,Parameter,Tissue,Species,Individuals,Value,Units,Quality")] Dats dats)
        {
            if (id != dats.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dats);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatsExists(dats.Id))
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
            return View(dats);
        }

        [Route("api/Dats/ValueDescending")]
        [HttpGet]
        public async Task<IActionResult> SortValueDesc()
        {
            try
            {
                var sortedData = await _context.Dati
                    .OrderByDescending(d => d.Value)
                    .ToListAsync();

                return Ok(sortedData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
        // GET: Dats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dati == null)
            {
                return NotFound();
            }

            var dats = await _context.Dati
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dats == null)
            {
                return NotFound();
            }

            return View(dats);
        }

        // POST: Dats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dati == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Dati'  is null.");
            }
            var dats = await _context.Dati.FindAsync(id);
            if (dats != null)
            {
                _context.Dati.Remove(dats);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatsExists(int id)
        {
          return (_context.Dati?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
