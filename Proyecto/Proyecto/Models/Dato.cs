using System;
using System.Collections.Generic;

#nullable disable

namespace Proyecto.Models
{
    public partial class Dato
    {
        public int Id { get; set; }
        public int Dispositivo { get; set; }
        public float Valor { get; set; }
        public DateTime Fecha { get; set; }
    }
}
