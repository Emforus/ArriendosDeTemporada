using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.core.Models.DTOs
{
    public class FacturaDTO
    {
        public int ID { get; set; }
        public DateTime fechaHora { get; set; }
        public int valorIVA { get; set; }
        public UsuarioDTO usuario { get; set; }
        public DepartamentoDTO departamento { get; set; }
    }
}
