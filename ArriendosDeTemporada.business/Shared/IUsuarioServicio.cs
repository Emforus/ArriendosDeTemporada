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
        Task<UsuarioDTO> BuscarUsername(string username);
        void CrearUsuario(Usuario Usuario);
        Task<Usuario> EditarUsuario(int id, Usuario Usuario);
        Task<Usuario> CambiarContraseña(AuthDataDTO data);
        Task<Usuario> SetEstadoUsuario(int id);
        Task<bool> Autenticar(AuthDataDTO data);
        Task<Usuario> RemoverUsuario(int id);
    }
}
