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
    public class DepartamentoRepo : Repository<Departamento>, Shared.IDepartamentoRepo
    {
        public DepartamentoRepo(DatabaseContext context) : base(context) { }
        public IQueryable<Departamento> GetDepartamento(int id)
        {
            return _context.Set<Departamento>().Where(x => x.idDepartamento == id);
        }
        public Task<List<ServicioDepartamento>> GetServiciosPorDepartamento(int id)
        {
            return _context.Set<ServicioDepartamento>().Where(x => x.IDDepartamento == id).AsQueryable().ToListAsync();
        }
    }
}
