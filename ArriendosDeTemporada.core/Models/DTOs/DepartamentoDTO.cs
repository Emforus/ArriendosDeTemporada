using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.core.Models.DTOs
{
    public class DepartamentoDTO
    {
        public int idDepartamento { get; set; }
        public string ubicacionDepartamento { get; set; }
        public string regionDepartamento { get; set; }
        public int valorBase { get; set; }
        public int cantidadDormitorios { get; set; }
        public string descripcionDepartamento { get; set; }
        public string Estado { get; set; }
        public DateTime fechaRegistroDepartamento { get; set; }
        public DateTime? fechaUltimaReserva { get; set; }
        public DateTime? fechaUltimaMantencion { get; set; }
        public GenericService serviciosPrincipales { get; set; }
        public bool estadoLogico { get; set; }
        public List<string> fotografias { get; set; }
        public List<FacturaDTO> facturas { get; set; }
        public List<UtilidadDTO> utilidades { get; set; }
        public List<ServicioDepartamentoDTO> ServiciosDisponibles { get; set; }
    }
}
