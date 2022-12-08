using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.core.Models
{
    public class Multa
    {
        public int ID { get; set; }
        public string descripcion { get; set; }
        public int valor { get; set; }
        public List<Utilidad> utilidades { get; set; }
        public int IDFactura { get; set; }
        public Factura factura { get; set; }
    }
}
