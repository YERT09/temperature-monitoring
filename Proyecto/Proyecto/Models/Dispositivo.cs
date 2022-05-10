using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Dispositivo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
    }
}
