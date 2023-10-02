using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecyclU.Data;
using RecyclU.Models;

namespace RecyclU.Controllers
{
    public class UniversidadesController : Controller
    {
        private readonly RecyclUContext _context;
        public static Universidad? universidad {  get; set; }

        public UniversidadesController(RecyclUContext context)
        {
            _context = context;
        }

        // GET: Universidads
        public async Task<IActionResult> Index()
        {
              return _context.Universidad != null ? 
                          View(await _context.Universidad.ToListAsync()) :
                          Problem("Entity set 'RecyclUContext.Universidad'  is null.");
        }

        // GET: Universidads/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Universidad == null)
            {
                return NotFound();
            }

            var universidad = await _context.Universidad
                .FirstOrDefaultAsync(m => m.Email == id);
            if (universidad == null)
            {
                return NotFound();
            }

            return View(universidad);
        }

        // GET: Universidads/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult InfoGeneral()
        {
            return View();
        }


        // POST: Universidades/Create
        // POST: Universidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Contraseña,Nombre,Logo,Descripcion")] Universidad universidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(universidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(universidad);
        }

        // GET: Universidads/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Universidad == null)
            {
                return NotFound();
            }

            var universidad = await _context.Universidad.FindAsync(id);
            if (universidad == null)
            {
                return NotFound();
            }
            return View(universidad);
        }

        // POST: Universidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email,Contraseña,Nombre,Logo,Descripcion")] Universidad universidad)
        {
            if (id != universidad.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversidadExists(universidad.Email))
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
            return View(universidad);
        }

        // GET: Universidads/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Universidad == null)
            {
                return NotFound();
            }

            var universidad = await _context.Universidad
                .FirstOrDefaultAsync(m => m.Email == id);
            if (universidad == null)
            {
                return NotFound();
            }

            return View(universidad);
        }

        // POST: Universidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Universidad == null)
            {
                return Problem("Entity set 'RecyclUContext.Universidad'  is null.");
            }
            var universidad = await _context.Universidad.FindAsync(id);
            if (universidad != null)
            {
                _context.Universidad.Remove(universidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversidadExists(string id)
        {
          return (_context.Universidad?.Any(e => e.Email == id)).GetValueOrDefault();
        }
    }
}
