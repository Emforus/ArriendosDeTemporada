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
        public Task<Departamento> GetDepartamento(int id)
        {
            return _context.Set<Departamento>().Where(x => x.idDepartamento == id).AsQueryable().FirstOrDefaultAsync();
        }
    }
}
