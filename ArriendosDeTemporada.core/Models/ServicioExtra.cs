using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.core.Models
{
    public class ServicioExtra
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fechaContrato { get; set; }
        public DateTime? fechaUltimaRenovacion { get; set; }
        public DateTime fechaExpiracion { get; set; }
        public bool estadoLogico { get; set; }
        public int costoServicio { get; set; }
        public bool servicioUnitario { get; set; }
        public ICollection<Factura> Facturas { get; set; }
        public List<ServicioFactura> ServiciosPorFactura { get; set; }
    }
}
