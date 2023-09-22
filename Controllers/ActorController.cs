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
    public class ActorController : Controller
    {
        private readonly AppDbContext _context;

        public ActorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Actor
        public async Task<IActionResult> Index()
        {
              return _context.Actores != null ? 
                          View(await _context.Actores.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Actores'  is null.");
        }


        public async Task<IActionResult> Search(string search)
        {
            IQueryable<Actor> ActoresQuery = _context.Actores;

            if (!string.IsNullOrEmpty(search))
            {
                ActoresQuery = ActoresQuery.Where(c =>
                    (c.name != null && c.name.Contains(search)) ||
                    (c.description != null && c.description.Contains(search)));
            }

            var Actores = await ActoresQuery.ToListAsync();

            return View("Index", Actores); // Redirige a la vista "Index" con los resultados de la búsqueda
        }

        // GET: Actor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Actores == null)
            {
                return NotFound();
            }

            var actor = await _context.Actores
                .FirstOrDefaultAsync(m => m.id == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // GET: Actor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,age,description,image_url")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // GET: Actor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Actores == null)
            {
                return NotFound();
            }

            var actor = await _context.Actores.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        // POST: Actor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("id,name,age,description,image_url")] Actor actor)
        {
            if (id != actor.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorExists(actor.id))
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
            return View(actor);
        }

        // GET: Actor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Actores == null)
            {
                return NotFound();
            }

            var actor = await _context.Actores
                .FirstOrDefaultAsync(m => m.id == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // POST: Actor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Actores == null)
            {
                return Problem("Entity set 'AppDbContext.Actores'  is null.");
            }
            var actor = await _context.Actores.FindAsync(id);
            if (actor != null)
            {
                _context.Actores.Remove(actor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(int? id)
        {
          return (_context.Actores?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
