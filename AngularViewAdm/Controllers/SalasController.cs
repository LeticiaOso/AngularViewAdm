using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AngularViewAdm.Models;

namespace AngularViewAdm.Controllers
{
    public class SalasController : Controller
    {
        private readonly u535755128_AngularviewContext _context;

        public SalasController(u535755128_AngularviewContext context)
        {
            _context = context;
        }

        // GET: Salas
        public async Task<IActionResult> Index()
        {
            var u535755128_AngularviewContext = _context.Sala.Include(s => s.IdEventoNavigation);
            return View(await u535755128_AngularviewContext.ToListAsync());
        }

        // GET: Salas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Sala
                .Include(s => s.IdEventoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // GET: Salas/Create
        public IActionResult Create()
        {
            ViewData["IdEvento"] = new SelectList(_context.Evento, "Id", "Id");
            return View();
        }

        // POST: Salas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroSala,Nombre,TipoSala,Activo,Modificado,Espacios,IdEvento")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEvento"] = new SelectList(_context.Evento, "Id", "Id", sala.IdEvento);
            return View(sala);
        }

        // GET: Salas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Sala.FindAsync(id);
            if (sala == null)
            {
                return NotFound();
            }
            ViewData["IdEvento"] = new SelectList(_context.Evento, "Id", "Id", sala.IdEvento);
            return View(sala);
        }

        // POST: Salas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroSala,Nombre,TipoSala,Activo,Modificado,Espacios,IdEvento")] Sala sala)
        {
            if (id != sala.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaExists(sala.Id))
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
            ViewData["IdEvento"] = new SelectList(_context.Evento, "Id", "Id", sala.IdEvento);
            return View(sala);
        }

        // GET: Salas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Sala
                .Include(s => s.IdEventoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // POST: Salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sala = await _context.Sala.FindAsync(id);
            _context.Sala.Remove(sala);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaExists(int id)
        {
            return _context.Sala.Any(e => e.Id == id);
        }
    }
}
