using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using ArriendosDeTemporada.core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ArriendosDeTemporada.data.Repos
{
    public class UsuarioRepo : Repository<Usuario>, Shared.IUsuarioRepo
    {
        public UsuarioRepo(DatabaseContext context) : base(context) { }
        public Task<Usuario> GetUsuario(int id)
        {
            return _context.Set<Usuario>().Where(x => x.ID == id && x.estadoLogico).AsQueryable().FirstOrDefaultAsync();
        }
        public Task<Usuario> GetUsuarioByUsername(string uid)
        {
            return _context.Set<Usuario>().Where(x => x.UID == uid && x.estadoLogico).AsQueryable().FirstOrDefaultAsync();
        }
    }
}
