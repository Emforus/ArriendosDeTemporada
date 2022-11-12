using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ArriendosDeTemporada.core.Models;
using ArriendosDeTemporada.core.Models.DTOs;

namespace ArriendosDeTemporada.business.Shared
{
    public interface IServicioExtraServicio
    {
        IEnumerable<DepartamentoDTO> ListarServicios();
        Task<DepartamentoDTO> BuscarServicio(int id);
        void RegistrarServicio(ServicioExtra servicio);
        Task<Departamento> DeshabilitarServicio(int id);
    }
}
