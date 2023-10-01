using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecyclU.Models;

namespace RecyclU.Data
{
    public class RecyclUContext : DbContext
    {
        public RecyclUContext (DbContextOptions<RecyclUContext> options)
            : base(options)
        {
        }

        public DbSet<RecyclU.Models.Usuario> Usuario { get; set; } = default!;

        public DbSet<RecyclU.Models.Empresa> Empresa { get; set; } = default!;

        public DbSet<RecyclU.Models.Universidad> Universidad { get; set; } = default!;

        public DbSet<RecyclU.Models.Negocio> Negocio { get; set; } = default!;

        public DbSet<RecyclU.Models.Post> Post { get; set; } = default!;
    }
}
