namespace BlogDeCafe.Models.ViewModels
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }
        public string? NombreCategoria { get; set; } = "";
        public IEnumerable<Publicacion>? Publicacion { get; set; }
    }
}
