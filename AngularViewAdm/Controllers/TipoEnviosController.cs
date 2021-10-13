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
    public class TipoEnviosController : Controller
    {
        private readonly u535755128_AngularviewContext _context;

        public TipoEnviosController(u535755128_AngularviewContext context)
        {
            _context = context;
        }

        // GET: TipoEnvios
        public async Task<IActionResult> Index()
        {
            var u535755128_AngularviewContext = _context.TipoEnvio.Include(t => t.IdExpoNavigation);
            return View(await u535755128_AngularviewContext.ToListAsync());
        }

        // GET: TipoEnvios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEnvio = await _context.TipoEnvio
                .Include(t => t.IdExpoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEnvio == null)
            {
                return NotFound();
            }

            return View(tipoEnvio);
        }

        // GET: TipoEnvios/Create
        public IActionResult Create()
        {
            ViewData["IdExpo"] = new SelectList(_context.Expositor, "Id", "Id");
            return View();
        }

        // POST: TipoEnvios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,IdExpo")] TipoEnvio tipoEnvio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEnvio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdExpo"] = new SelectList(_context.Expositor, "Id", "Id", tipoEnvio.IdExpo);
            return View(tipoEnvio);
        }

        // GET: TipoEnvios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEnvio = await _context.TipoEnvio.FindAsync(id);
            if (tipoEnvio == null)
            {
                return NotFound();
            }
            ViewData["IdExpo"] = new SelectList(_context.Expositor, "Id", "Id", tipoEnvio.IdExpo);
            return View(tipoEnvio);
        }

        // POST: TipoEnvios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,IdExpo")] TipoEnvio tipoEnvio)
        {
            if (id != tipoEnvio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEnvio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEnvioExists(tipoEnvio.Id))
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
            ViewData["IdExpo"] = new SelectList(_context.Expositor, "Id", "Id", tipoEnvio.IdExpo);
            return View(tipoEnvio);
        }

        // GET: TipoEnvios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEnvio = await _context.TipoEnvio
                .Include(t => t.IdExpoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEnvio == null)
            {
                return NotFound();
            }

            return View(tipoEnvio);
        }

        // POST: TipoEnvios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEnvio = await _context.TipoEnvio.FindAsync(id);
            _context.TipoEnvio.Remove(tipoEnvio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEnvioExists(int id)
        {
            return _context.TipoEnvio.Any(e => e.Id == id);
        }
    }
}
