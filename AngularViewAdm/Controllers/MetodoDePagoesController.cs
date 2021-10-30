﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AngularViewAdm.Models;

namespace AngularViewAdm.Controllers
{
    public class MetodoDePagoesController : Controller
    {
        private readonly u535755128_AngularviewContext _context;

        public MetodoDePagoesController(u535755128_AngularviewContext context)
        {
            _context = context;
        }

        // GET: MetodoDePagoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MetodoDePago.ToListAsync());
        }

        // GET: MetodoDePagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoDePago = await _context.MetodoDePago
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metodoDePago == null)
            {
                return NotFound();
            }

            return View(metodoDePago);
        }

        // GET: MetodoDePagoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MetodoDePagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TpoDePago,Activo,Modifacdo")] MetodoDePago metodoDePago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metodoDePago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metodoDePago);
        }

        // GET: MetodoDePagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoDePago = await _context.MetodoDePago.FindAsync(id);
            if (metodoDePago == null)
            {
                return NotFound();
            }
            return View(metodoDePago);
        }

        // POST: MetodoDePagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TpoDePago,Activo,Modifacdo")] MetodoDePago metodoDePago)
        {
            if (id != metodoDePago.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metodoDePago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetodoDePagoExists(metodoDePago.Id))
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
            return View(metodoDePago);
        }

        // GET: MetodoDePagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoDePago = await _context.MetodoDePago
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metodoDePago == null)
            {
                return NotFound();
            }

            return View(metodoDePago);
        }

        // POST: MetodoDePagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metodoDePago = await _context.MetodoDePago.FindAsync(id);
            _context.MetodoDePago.Remove(metodoDePago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetodoDePagoExists(int id)
        {
            return _context.MetodoDePago.Any(e => e.Id == id);
        }
    }
}
