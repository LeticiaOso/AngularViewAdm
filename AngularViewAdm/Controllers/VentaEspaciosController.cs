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
    public class VentaEspaciosController : Controller
    {
        private readonly u535755128_AngularviewContext _context;

        public VentaEspaciosController(u535755128_AngularviewContext context)
        {
            _context = context;
        }

        // GET: VentaEspacios
        public async Task<IActionResult> Index()
        {
            var u535755128_AngularviewContext = _context.VentaEspacio.Include(v => v.IdCajonNavigation).Include(v => v.IdExpositorNavigation).Include(v => v.IdVendedorNavigation);
            return View(await u535755128_AngularviewContext.ToListAsync());
        }

        // GET: VentaEspacios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaEspacio = await _context.VentaEspacio
                .Include(v => v.IdCajonNavigation)
                .Include(v => v.IdExpositorNavigation)
                .Include(v => v.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventaEspacio == null)
            {
                return NotFound();
            }

            return View(ventaEspacio);
        }

        // GET: VentaEspacios/Create
        public IActionResult Create()
        {
            ViewData["IdCajon"] = new SelectList(_context.Caja, "Id", "Id");
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id");
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "Id", "Id");
            return View();
        }

        // POST: VentaEspacios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdExpositor,IdCajon,Fecha,IdVendedor,Total,Estatus")] VentaEspacio ventaEspacio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventaEspacio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCajon"] = new SelectList(_context.Caja, "Id", "Id", ventaEspacio.IdCajon);
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id", ventaEspacio.IdExpositor);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "Id", "Id", ventaEspacio.IdVendedor);
            return View(ventaEspacio);
        }

        // GET: VentaEspacios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaEspacio = await _context.VentaEspacio.FindAsync(id);
            if (ventaEspacio == null)
            {
                return NotFound();
            }
            ViewData["IdCajon"] = new SelectList(_context.Caja, "Id", "Id", ventaEspacio.IdCajon);
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id", ventaEspacio.IdExpositor);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "Id", "Id", ventaEspacio.IdVendedor);
            return View(ventaEspacio);
        }

        // POST: VentaEspacios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdExpositor,IdCajon,Fecha,IdVendedor,Total,Estatus")] VentaEspacio ventaEspacio)
        {
            if (id != ventaEspacio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventaEspacio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaEspacioExists(ventaEspacio.Id))
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
            ViewData["IdCajon"] = new SelectList(_context.Caja, "Id", "Id", ventaEspacio.IdCajon);
            ViewData["IdExpositor"] = new SelectList(_context.Expositor, "Id", "Id", ventaEspacio.IdExpositor);
            ViewData["IdVendedor"] = new SelectList(_context.Vendedores, "Id", "Id", ventaEspacio.IdVendedor);
            return View(ventaEspacio);
        }

        // GET: VentaEspacios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaEspacio = await _context.VentaEspacio
                .Include(v => v.IdCajonNavigation)
                .Include(v => v.IdExpositorNavigation)
                .Include(v => v.IdVendedorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventaEspacio == null)
            {
                return NotFound();
            }

            return View(ventaEspacio);
        }

        // POST: VentaEspacios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventaEspacio = await _context.VentaEspacio.FindAsync(id);
            _context.VentaEspacio.Remove(ventaEspacio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaEspacioExists(int id)
        {
            return _context.VentaEspacio.Any(e => e.Id == id);
        }
    }
}
