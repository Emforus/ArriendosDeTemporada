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
    public class ServicioRepo : Repository<ServicioExtra>, Shared.IServicioRepo
    {
        public ServicioRepo(DatabaseContext context) : base(context) { }
        public IQueryable<ServicioExtra> GetServicio(int id)
        {
            return _context.Set<ServicioExtra>().Where(x => x.ID == id);
        }
        public IQueryable<ServicioFactura> GetFacturasPorServicio(int id)
        {
            return _context.Set<ServicioFactura>().Where(x => x.IDServicio == id);
        }
        public IQueryable<ServicioDepartamento> GetDepartamentosPorServicio(int id)
        {
            return _context.Set<ServicioDepartamento>().Where(x => x.IDServicio == id);
        }
        public void AddToFactura(ServicioFactura entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _context.Set<ServicioFactura>().Add(entity);
        }
        public void DeleteFromFactura(ServicioFactura entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _context.Set<ServicioFactura>().Remove(entity);
        }
        public void AddToDepartamento(ServicioDepartamento entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _context.Set<ServicioDepartamento>().Add(entity);
        }
        public void DeleteFromDepartamento(ServicioDepartamento entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _context.Set<ServicioDepartamento>().Remove(entity);
        }
    }
}
