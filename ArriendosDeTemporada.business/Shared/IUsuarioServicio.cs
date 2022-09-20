using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ArriendosDeTemporada.core.Models;
using ArriendosDeTemporada.core.Models.DTOs;

namespace ArriendosDeTemporada.business.Shared
{
    public interface IUsuarioServicio
    {
        IEnumerable<UsuarioDTO> ListarUsuarios();
        Task<UsuarioDTO> BuscarUsuario(int id);
        void CrearUsuario(Usuario Usuario);
        Task<Usuario> DeshabilitarUsuario(int id);

        // void RemoverUsuario(Usuario Usuario);
    }
}
