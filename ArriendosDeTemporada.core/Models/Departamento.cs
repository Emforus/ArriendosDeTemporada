using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.core.Models
{
    public enum Estado
    {
        Disponible,
        Reservado,
        EnUso,
        MantencionAgendada,
        EnMantencion
    }

    public class Departamento
    {
        public int idDepartamento { get; set; }
        public string ubicacionDepartamento { get; set; }
        public int tamañoDepartamento { get; set; }
        public Estado Estado { get; set; }
        public bool estadoLogico { get; set; }
        public List<Utilidad> utilidades { get; set; }
        public List<Factura> facturas { get; set; }
    }
}
