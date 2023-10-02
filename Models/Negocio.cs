using System.Reflection.Metadata.Ecma335;

namespace RecyclU.Models
{
    public class Negocio
    {
        public required int Id { get; set; }
        public required string UniversidadEmail { get; set; }
        public required Universidad Universidad { get; set; }
        public required string EmpresaEmail { get; set; }
        public required Empresa Empresa { get; set; }
        public required string Material { get; set; }
        public required float Peso { get; set; }
        public required float Monto { get; set; }
    }
}
