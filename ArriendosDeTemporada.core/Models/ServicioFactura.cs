using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.core.Models
{
    public class ServicioFactura
    {
        public int valorServicio { get; set; }
        public int IDServicio { get; set; }
        public ServicioExtra Servicio { get; set; }
        public int IDFactura { get; set; }
        public Factura Factura { get; set; }
    }
}
