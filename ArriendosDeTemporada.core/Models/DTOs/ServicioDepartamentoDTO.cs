using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.core.Models.DTOs
{
    public class ServicioDepartamentoDTO
    {
        public int IDServicio { get; set; }
        public ServicioExtraDTO Servicio { get; set; }
        public int IDDepartamento { get; set; }
        public DepartamentoDTO Departamento { get; set; }
    }
}
