using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecyclU.Data;
using RecyclU.Models;

namespace RecyclU.Controllers
{
    public class NegociosController : Controller
    {
        private readonly RecyclUContext _context;

        public NegociosController(RecyclUContext context)
        {
            _context = context;
        }

        // GET: Negocios
        public async Task<IActionResult> Index()
        {
            var recyclUContext = _context.Negocio.Include(n => n.Empresa).Include(n => n.Universidad);
            return View(await recyclUContext.ToListAsync());
        }

        // GET: Negocios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Negocio == null)
            {
                return NotFound();
            }

            var negocio = await _context.Negocio
                .Include(n => n.Empresa)
                .Include(n => n.Universidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (negocio == null)
            {
                return NotFound();
            }

            return View(negocio);
        }

        // GET: Negocios/Create
        public IActionResult Create()
        {
            ViewData["EmpresaEmail"] = new SelectList(_context.Empresa, "Email", "Email");
            ViewData["UniversidadEmail"] = new SelectList(_context.Universidad, "Email", "Email");
            return View();
        }

        // POST: Negocios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UniversidadEmail,EmpresaEmail,Material,Peso,Monto")] Negocio negocio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(negocio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaEmail"] = new SelectList(_context.Empresa, "Email", "Email", negocio.EmpresaEmail);
            ViewData["UniversidadEmail"] = new SelectList(_context.Universidad, "Email", "Email", negocio.UniversidadEmail);
            return View(negocio);
        }

        // GET: Negocios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Negocio == null)
            {
                return NotFound();
            }

            var negocio = await _context.Negocio.FindAsync(id);
            if (negocio == null)
            {
                return NotFound();
            }
            ViewData["EmpresaEmail"] = new SelectList(_context.Empresa, "Email", "Email", negocio.EmpresaEmail);
            ViewData["UniversidadEmail"] = new SelectList(_context.Universidad, "Email", "Email", negocio.UniversidadEmail);
            return View(negocio);
        }

        // POST: Negocios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UniversidadEmail,EmpresaEmail,Material,Peso,Monto")] Negocio negocio)
        {
            if (id != negocio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(negocio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NegocioExists(negocio.Id))
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
            ViewData["EmpresaEmail"] = new SelectList(_context.Empresa, "Email", "Email", negocio.EmpresaEmail);
            ViewData["UniversidadEmail"] = new SelectList(_context.Universidad, "Email", "Email", negocio.UniversidadEmail);
            return View(negocio);
        }

        // GET: Negocios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Negocio == null)
            {
                return NotFound();
            }

            var negocio = await _context.Negocio
                .Include(n => n.Empresa)
                .Include(n => n.Universidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (negocio == null)
            {
                return NotFound();
            }

            return View(negocio);
        }

        // POST: Negocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Negocio == null)
            {
                return Problem("Entity set 'RecyclUContext.Negocio'  is null.");
            }
            var negocio = await _context.Negocio.FindAsync(id);
            if (negocio != null)
            {
                _context.Negocio.Remove(negocio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NegocioExists(int id)
        {
          return (_context.Negocio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
