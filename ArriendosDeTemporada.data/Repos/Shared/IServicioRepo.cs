using System;
using System.Collections.Generic;
using System.Text;
using ArriendosDeTemporada.core.Models;
using System.Threading.Tasks;
using System.Linq;

namespace ArriendosDeTemporada.data.Repos.Shared
{
    public interface IServicioRepo : IRepository<ServicioExtra>
    {
        IQueryable<ServicioExtra> GetServicio(int id);
        IQueryable<ServicioFactura> GetFacturasPorServicio(int id);
        IQueryable<ServicioDepartamento> GetDepartamentosPorServicio(int id);
        void DeleteFromFactura(ServicioFactura element);
        void DeleteFromDepartamento(ServicioDepartamento element);
        void AddToFactura(ServicioFactura element);
        void AddToDepartamento(ServicioDepartamento element);

    }
}
