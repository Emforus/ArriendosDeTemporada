using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.core.Models
{
    public class Factura
    {
        public int ID { get; set; }
        public DateTime fechaHora { get; set; }
        public int valorIVA { get; set; }
        public int cantidadClientes { get; set; }
        public Usuario usuario { get; set; }
        public Departamento departamento { get; set; }
        public ICollection<ServicioExtra> Servicios { get; set; }
        public List<ServicioFactura> ServiciosPorFactura { get; set; }
    }
}
