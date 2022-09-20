using System;
using System.Collections.Generic;
using System.Text;
using ArriendosDeTemporada.core.Models;
using System.Threading.Tasks;

namespace ArriendosDeTemporada.data.Repos.Shared
{
    public interface IUsuarioRepo : IRepository<Usuario>
    {
        Task<Usuario> GetUsuario(int id);
    }
}
