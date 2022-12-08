using System;
using System.Collections.Generic;
using System.Text;
using ArriendosDeTemporada.core.Models;
using System.Threading.Tasks;
using System.Linq;

namespace ArriendosDeTemporada.data.Repos.Shared
{
    public interface IFacturaRepo : IRepository<Factura>
    {
        IQueryable<Factura> GetFactura(int id);
        IQueryable<ServicioFactura> GetServiciosPorFactura(int id);
    }
}
