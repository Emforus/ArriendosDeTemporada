using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.core.Models.DTOs
{
    public class UsuarioDTO
    {
        public int ID { get; set; }
        public string UID { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string nombreUsuario { get; set; }
        public DateTime fechaRegistroUsuario { get; set; }
        public DateTime lastLogOn { get; set; }
    }
}
