namespace BlogDeCafe.Models.ViewModels
{
    public class HomeViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public DateTime FechaPublicacion { get; set; }
        public int TotalComentarios { get; set; }
        public bool Archivado { get; set; }
        
    }
}
