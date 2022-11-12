using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.core.Models
{
    public class Factura
    {
        public int ID { get; set; }
        public DateTime fechaHoraGeneracion { get; set; }
        public DateTime? fechaHoraCheckIn { get; set; }
        public DateTime? fechaHoraCheckOut { get; set; }
        public DateTime fechaHoraReserva { get; set; }
        public int duracion { get; set; }
        public int valorIVA { get; set; }
        public int cantidadClientes { get; set; }
        public string estado { get; set; }
        public Usuario usuario { get; set; }
        public Departamento departamento { get; set; }
        public ICollection<ServicioExtra> Servicios { get; set; }
        public List<ServicioFactura> ServiciosPorFactura { get; set; }
    }
}
