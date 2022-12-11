using System;
using System.Collections.Generic;

namespace BlogDeCafe.Models
{
    public partial class Publicacion
    {
        public Publicacion()
        {
            Comentarios = new HashSet<Comentario>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Autor { get; set; } = null!;
        public DateTime FechaPublicacion { get; set; }
        public string Contenido { get; set; } = null!;
        public bool Archivado { get; set; }
        public int? IdCategoria { get; set; }
        public string Publicacioncol { get; set; } = null!;

        public virtual Categorium? IdCategoriaNavigation { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
