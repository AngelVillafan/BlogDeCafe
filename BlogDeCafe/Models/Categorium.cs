using System;
using System.Collections.Generic;

namespace BlogDeCafe.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Publicacions = new HashSet<Publicacion>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Publicacion> Publicacions { get; set; }
    }
}
