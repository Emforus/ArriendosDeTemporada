using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ArriendosDeTemporada.core.Models;
using ArriendosDeTemporada.core.Models.DTOs;

namespace ArriendosDeTemporada.business.Shared
{
    public interface IFacturaServicio
    {
        IEnumerable<FacturaDTO> ListarFacturas();
        IQueryable<FacturaDTO> ListarFacturasPorDepartamento(int id);
        IQueryable<FacturaDTO> ListarFacturasPorCliente(int id);
        Task<FacturaDTO> BuscarFactura(int id);
        Task<Factura> AnularFactura(Factura factura);
    }
}
