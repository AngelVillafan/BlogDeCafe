using System;
using System.Collections.Generic;

namespace BlogDeCafe.Models
{
    public partial class Usuariosnewsletter
    {
        public int Id { get; set; }
        public string Correo { get; set; } = null!;
        public bool Suscrito { get; set; }
    }
}
