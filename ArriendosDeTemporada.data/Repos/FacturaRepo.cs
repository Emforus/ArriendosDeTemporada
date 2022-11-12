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
    public class FacturaRepo : Repository<Factura>, Shared.IFacturaRepo
    {
        public FacturaRepo(DatabaseContext context) : base(context) { }
        public IQueryable<Factura> GetFactura(int id)
        {
            return _context.Set<Factura>().Where(x => x.ID == id);
        }
    }
}
