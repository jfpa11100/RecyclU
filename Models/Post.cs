namespace RecyclU.Models
{
    public class Post
    {
        public required int Id { get; set; }
        public required string Imagen { get; set; }
        public required string Descripcion { get; set; }
        public required float Precio { get; set; }
        public required string Material { get; set; }
        public required float Peso { get; set; }
    }
}
