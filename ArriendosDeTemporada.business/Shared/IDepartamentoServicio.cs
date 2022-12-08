using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ArriendosDeTemporada.core.Models;
using ArriendosDeTemporada.core.Models.DTOs;

namespace ArriendosDeTemporada.business.Shared
{
    public interface IDepartamentoServicio
    {
        IEnumerable<DepartamentoDTO> ListarDepartamentos();
        Task<DepartamentoDTO> BuscarDepartamento(int id);
        void CrearDepartamento(Departamento departamento);
        Task<Departamento> SetEstadoDepartamento(int id);
        Task<Departamento> EditarDepartamento(int id, Departamento depto);
        Task<FacturaDTO> ReservarDepartamento(Factura factura);
        Task<IQueryable<UtilidadDTO>> ListarUtilidades(int id);
        Task<Departamento> AñadirUtilidades(Utilidad[] util, int id);
        Task<Departamento> RemoverUtilidades(Utilidad[] util, int id);
        Task<IQueryable<ServicioDepartamentoDTO>> ListarServiciosDisponibles(int id);

    }
}
