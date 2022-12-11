using System;
using System.Collections.Generic;

namespace BlogDeCafe.Models
{
    public partial class Comentario
    {
        public int Id { get; set; }
        public string? Autor { get; set; }
        public string Comentario1 { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public int Idpublicacion { get; set; }

        public virtual Publicacion IdpublicacionNavigation { get; set; } = null!;
    }
}
