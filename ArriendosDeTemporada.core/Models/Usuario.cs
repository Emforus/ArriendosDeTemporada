using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.core.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public string UID { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string nombreUsuario { get; set; }
        public DateTime fechaRegistroUsuario { get; set; }
        public DateTime lastLogOn { get; set; }
        public string passwordHash { get; set; }
        public bool estadoLogico { get; set; }
        public List<Factura> facturas { get; set; }
    }
}
