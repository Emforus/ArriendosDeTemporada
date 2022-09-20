using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.core.Models.DTOs
{
    public class DepartamentoDTO
    {
        public int idDepartamento { get; set; }
        public string ubicacionDepartamento { get; set; }
        public int tamañoDepartamento { get; set; }
        public Estado Estado { get; set; }
        public bool estadoLogico { get; set; }
    }
}
