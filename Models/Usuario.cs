﻿using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace RecyclU.Models
{
    public class Usuario
    {
        [Key]
        public required string Email { get; set; }
        public required string Contraseña { get; set; }
        public required string Nombre { get; set; }
        public string? Logo { get; set; }
        public string? Descripcion { get; set; }

    }
}
