using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.core.Models.DTOs
{
    public class FacturaDTO
    {
        public int ID { get; set; }
        public DateTime fechaHoraGeneracion { get; set; }
        public DateTime? fechaHoraCheckIn { get; set; }
        public DateTime? fechaHoraCheckOut { get; set; }
        public DateTime fechaHoraReserva { get; set; }
        public int duracion { get; set; }
        public int valor { get; set; }
        public int valorIVA { get; set; }
        public int valorDeposito { get; set; }
        public int valorServicios { get; set; }
        public int cantidadClientes { get; set; }
        public string estado { get; set; }
        public UsuarioDTO usuario { get; set; }
        public DepartamentoDTO departamento { get; set; }
    }
}
