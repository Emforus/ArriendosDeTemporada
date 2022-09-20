using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.core.Models
{
    public class Utilidad
    {
        public int ID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int valor { get; set; }
        public Departamento departamento { get; set; }
    }
}
