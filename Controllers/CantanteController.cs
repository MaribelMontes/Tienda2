using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practice2.Models;

namespace Practice2.Controllers
{
    public class CantanteController : Controller
    {
        private readonly AppDbContext _context;

        public CantanteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Cantante
        public async Task<IActionResult> Index()
        {
              return _context.Cantantes != null ? 
                          View(await _context.Cantantes.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Cantantes'  is null.");
        }

        
        public async Task<IActionResult> Search(string search)
        {
            IQueryable<Cantante> CantantesQuery = _context.Cantantes;

            if (!string.IsNullOrEmpty(search))
            {
                CantantesQuery = CantantesQuery.Where(c =>
                    (c.Name != null && c.Name.Contains(search)) ||
                    (c.Description != null && c.Description.Contains(search)));
            }

            var Cantantes = await CantantesQuery.ToListAsync();

            return View("Index", Cantantes); // Redirige a la vista "Index" con los resultados de la búsqueda
        }
        // GET: Cantante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cantantes == null)
            {
                return NotFound();
            }

            var cantante = await _context.Cantantes
                .FirstOrDefaultAsync(m => m.id == id);
            if (cantante == null)
            {
                return NotFound();
            }
                 
             var Cantante = await _context.Cantantes.Where(m => m.id == id)
                .Include(m => m.Album).FirstAsync();

            return View(cantante);
        }

        // GET: Cantante/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cantante/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Genre,Description,Image_url")] Cantante cantante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cantante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cantante);
        }

        // GET: Cantante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cantantes == null)
            {
                return NotFound();
            }

            var cantante = await _context.Cantantes.FindAsync(id);
            if (cantante == null)
            {
                return NotFound();
            }
            return View(cantante);
        }

        // POST: Cantante/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("id,Name,Genre,Description,Image_url")] Cantante cantante)
        {
            if (id != cantante.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cantante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CantanteExists(cantante.id))
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
            return View(cantante);
        }

        // GET: Cantante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cantantes == null)
            {
                return NotFound();
            }

            var cantante = await _context.Cantantes
                .FirstOrDefaultAsync(m => m.id == id);
            if (cantante == null)
            {
                return NotFound();
            }

            return View(cantante);
        }

        // POST: Cantante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Cantantes == null)
            {
                return Problem("Entity set 'AppDbContext.Cantantes'  is null.");
            }
            var cantante = await _context.Cantantes.FindAsync(id);
            if (cantante != null)
            {
                _context.Cantantes.Remove(cantante);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CantanteExists(int? id)
        {
          return (_context.Cantantes?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
