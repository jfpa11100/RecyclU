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
    public class UsuariosController : Controller
    {
        private readonly RecyclUContext _context;

        public UsuariosController(RecyclUContext context)
        {
            _context = context;
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    }
}
