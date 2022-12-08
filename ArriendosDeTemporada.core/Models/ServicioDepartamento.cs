using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.core.Models
{
    public class ServicioDepartamento
    {
        public int IDServicio { get; set; }
        public ServicioExtra Servicio { get; set; }
        public int IDDepartamento { get; set; }
        public Departamento Departamento { get; set; }
    }
}
