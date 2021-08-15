using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPizza1.Models
{
    public class OrdenView
    {
        public long Id { get; set; }

        public string TextoOrden { get; set; }
        public int TipoTamano { get; set; }
        public string NombreTamano { get; set; }
        public int TipoMasa { get; set; }
        public string NombreMasa { get; set; }
        public string Ingredientes { get; set; }
    }
}
