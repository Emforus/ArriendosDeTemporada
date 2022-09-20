using System;
using System.Collections.Generic;
using System.Text;
using ArriendosDeTemporada.core.Models;
using System.Threading.Tasks;

namespace ArriendosDeTemporada.data.Repos.Shared
{
    public interface IFacturaRepo : IRepository<Factura>
    {
        Task<Factura> GetFactura(int id);
    }
}
