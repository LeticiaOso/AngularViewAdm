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
    public class ExpositorPagoesController : Controller
    {
        private readonly u535755128_AngularviewContext _context;

        public ExpositorPagoesController(u535755128_AngularviewContext context)
        {
            _context = context;
        }

        // GET: ExpositorPagoes
        public async Task<IActionResult> Index()
        {
            var u535755128_AngularviewContext = _context.ExpositorPago.Include(e => e.IdExpositorNavigation).Include(e => e.IdTipoPagoNavigation);
            return View(await u535755128_AngularviewContext.ToListAsync());
        }

        // GET: ExpositorPagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expositorPago = await _context.ExpositorPago
                .Include(e => e.IdExpositorNavigation)
                .Include(e => e.IdTipoPagoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expositorPago == null)
            {
                return NotFound();
            }

            return View(expositorPago);
        }

        // GET: ExpositorPagoes/Create
        public IActionResult Create()
        {
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id");
            ViewData["IdTipoPago"] = new SelectList(_context.MetodoDePago, "Id", "Id");
            return View();
        }

        // POST: ExpositorPagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdExpositor,IdTipoPago,Activo,Modificado")] ExpositorPago expositorPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expositorPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id", expositorPago.IdExpositor);
            ViewData["IdTipoPago"] = new SelectList(_context.MetodoDePago, "Id", "Id", expositorPago.IdTipoPago);
            return View(expositorPago);
        }

        // GET: ExpositorPagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expositorPago = await _context.ExpositorPago.FindAsync(id);
            if (expositorPago == null)
            {
                return NotFound();
            }
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id", expositorPago.IdExpositor);
            ViewData["IdTipoPago"] = new SelectList(_context.MetodoDePago, "Id", "Id", expositorPago.IdTipoPago);
            return View(expositorPago);
        }

        // POST: ExpositorPagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdExpositor,IdTipoPago,Activo,Modificado")] ExpositorPago expositorPago)
        {
            if (id != expositorPago.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expositorPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpositorPagoExists(expositorPago.Id))
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
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id", expositorPago.IdExpositor);
            ViewData["IdTipoPago"] = new SelectList(_context.MetodoDePago, "Id", "Id", expositorPago.IdTipoPago);
            return View(expositorPago);
        }

        // GET: ExpositorPagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expositorPago = await _context.ExpositorPago
                .Include(e => e.IdExpositorNavigation)
                .Include(e => e.IdTipoPagoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expositorPago == null)
            {
                return NotFound();
            }

            return View(expositorPago);
        }

        // POST: ExpositorPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expositorPago = await _context.ExpositorPago.FindAsync(id);
            _context.ExpositorPago.Remove(expositorPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpositorPagoExists(int id)
        {
            return _context.ExpositorPago.Any(e => e.Id == id);
        }
    }
}
