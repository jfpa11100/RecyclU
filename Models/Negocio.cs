using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace RecyclU.Models
{
    public class Negocio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int Id { get; set; }
        public required string UniversidadEmail { get; set; }
        public Universidad? Universidad { get; set; }
        public required string EmpresaEmail { get; set; }
        public Empresa? Empresa { get; set; }
        public required string Material { get; set; }
        public required float Peso { get; set; }
        public required float Monto { get; set; }
    }
}
