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
    public class TipoPagoesController : Controller
    {
        private readonly u535755128_AngularviewContext _context;

        public TipoPagoesController(u535755128_AngularviewContext context)
        {
            _context = context;
        }

        // GET: TipoPagoes
        public async Task<IActionResult> Index()
        {
            var u535755128_AngularviewContext = _context.TipoPago.Include(t => t.IdExpoNavigation);
            return View(await u535755128_AngularviewContext.ToListAsync());
        }

        // GET: TipoPagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPago = await _context.TipoPago
                .Include(t => t.IdExpoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPago == null)
            {
                return NotFound();
            }

            return View(tipoPago);
        }

        // GET: TipoPagoes/Create
        public IActionResult Create()
        {
            ViewData["IdExpo"] = new SelectList(_context.Expositor, "Id", "Id");
            return View();
        }

        // POST: TipoPagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,IdExpo")] TipoPago tipoPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdExpo"] = new SelectList(_context.Expositor, "Id", "Id", tipoPago.IdExpo);
            return View(tipoPago);
        }

        // GET: TipoPagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPago = await _context.TipoPago.FindAsync(id);
            if (tipoPago == null)
            {
                return NotFound();
            }
            ViewData["IdExpo"] = new SelectList(_context.Expositor, "Id", "Id", tipoPago.IdExpo);
            return View(tipoPago);
        }

        // POST: TipoPagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,IdExpo")] TipoPago tipoPago)
        {
            if (id != tipoPago.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPagoExists(tipoPago.Id))
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
            ViewData["IdExpo"] = new SelectList(_context.Expositor, "Id", "Id", tipoPago.IdExpo);
            return View(tipoPago);
        }

        // GET: TipoPagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPago = await _context.TipoPago
                .Include(t => t.IdExpoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoPago == null)
            {
                return NotFound();
            }

            return View(tipoPago);
        }

        // POST: TipoPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPago = await _context.TipoPago.FindAsync(id);
            _context.TipoPago.Remove(tipoPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPagoExists(int id)
        {
            return _context.TipoPago.Any(e => e.Id == id);
        }
    }
}
