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
    public class UtilidadRepo : Repository<Utilidad>, Shared.IUtilidadRepo
    {
        public UtilidadRepo(DatabaseContext context) : base(context) { }
        public Task<Utilidad> GetUtilidad(int id)
        {
            return _context.Set<Utilidad>().Where(x => x.ID == id).AsQueryable().FirstOrDefaultAsync();
        }
        public Task<List<Utilidad>> GetUtilidadesByDepartamento(int id)
        {
            return _context.Set<Utilidad>().Where(x => x.departamento.idDepartamento == id).AsQueryable().ToListAsync();
        }
    }
}
