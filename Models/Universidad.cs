using System.Reflection.Metadata.Ecma335;

namespace RecyclU.Models
{
    public class Universidad: Usuario
    {
        public List<Post>? Posts { get; set; }
        public List<Negocio>? Negocios { get; set; }
    }
}
