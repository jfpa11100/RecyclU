using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecyclU.Data;
using RecyclU.Models;
using System.Diagnostics;

namespace RecyclU.Controllers
{
    public class HomeController : Controller
    {
        private readonly RecyclUContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(RecyclUContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(string email, string password)
        {
            var usuario = await _context.Usuario.SingleOrDefaultAsync(u => u.Email == email);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Email not found.");
                return View();
            }

            if (usuario.Contraseña == password)
            {
                // usuario logged in

                if (usuario is Empresa)
                {
                    // Guardar el usuario que entró
                    EmpresasController.empresa = (Empresa?)usuario;
                    return RedirectToAction("Index", "Empresas");
                }
                else if (usuario is Universidad)
                {
                    // Guardar el usuario que entró
                    UniversidadesController.universidad = (Universidad?)usuario;
                    return RedirectToAction("Index", "Universidades");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}