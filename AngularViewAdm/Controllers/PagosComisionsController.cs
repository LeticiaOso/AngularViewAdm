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
    public class PagosComisionsController : Controller
    {
        private readonly u535755128_AngularviewContext _context;

        public PagosComisionsController(u535755128_AngularviewContext context)
        {
            _context = context;
        }

        // GET: PagosComisions
        public async Task<IActionResult> Index()
        {
            var u535755128_AngularviewContext = _context.PagosComision.Include(p => p.IdVendedorNavigation);
            return View(await u535755128_AngularviewContext.ToListAsync());
        }

        // GET: PagosComisions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagosComision = await _context.PagosComision
                .Include(p => p.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagosComision == null)
            {
                return NotFound();
            }

            return View(pagosComision);
        }

        // GET: PagosComisions/Create
        public IActionResult Create()
        {
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "Id", "Id");
            return View();
        }

        // POST: PagosComisions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pago,Fecha,Activo,IdVendedor")] PagosComision pagosComision)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagosComision);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "Id", "Id", pagosComision.IdVendedor);
            return View(pagosComision);
        }

        // GET: PagosComisions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagosComision = await _context.PagosComision.FindAsync(id);
            if (pagosComision == null)
            {
                return NotFound();
            }
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "Id", "Id", pagosComision.IdVendedor);
            return View(pagosComision);
        }

        // POST: PagosComisions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pago,Fecha,Activo,IdVendedor")] PagosComision pagosComision)
        {
            if (id != pagosComision.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagosComision);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagosComisionExists(pagosComision.Id))
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
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "Id", "Id", pagosComision.IdVendedor);
            return View(pagosComision);
        }

        // GET: PagosComisions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagosComision = await _context.PagosComision
                .Include(p => p.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pagosComision == null)
            {
                return NotFound();
            }

            return View(pagosComision);
        }

        // POST: PagosComisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagosComision = await _context.PagosComision.FindAsync(id);
            _context.PagosComision.Remove(pagosComision);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagosComisionExists(int id)
        {
            return _context.PagosComision.Any(e => e.Id == id);
        }
    }
}
