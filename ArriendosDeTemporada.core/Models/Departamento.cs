using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.core.Models
{
    public class Departamento
    {
        public int idDepartamento { get; set; }
        public string nombreDepartamento { get; set; }
        public string ubicacionDepartamento { get; set; }
        public string regionDepartamento { get; set; }
        public int valorBase { get; set; }
        public string descripcionDepartamento { get; set; }
        public int cantidadDormitorios { get; set; }
        public string Estado { get; set; }
        public DateTime fechaRegistroDepartamento { get; set; }
        public DateTime? fechaUltimaReserva { get; set; }
        public DateTime? fechaUltimaMantencion { get; set; }
        public bool estadoLogico { get; set; }
        public GenericService serviciosPrincipales { get; set; }
        public List<string> fotografias { get; set; }
        public List<Utilidad> utilidades { get; set; }
        public List<Factura> facturas { get; set; }
        public ICollection<ServicioExtra> Servicios { get; set; }
        public List<ServicioDepartamento> ServiciosDisponibles { get; set; }
    }
}
