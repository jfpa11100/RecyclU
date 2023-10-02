namespace RecyclU.Models
{
    public class Empresa: Usuario
    {
        public List<Negocio>? Negocios { get; set; }
    }

}
