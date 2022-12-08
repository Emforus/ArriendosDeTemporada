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
        IEnumerable<ServicioExtraDTO> ListarServicios();
        Task<ServicioExtraDTO> BuscarServicio(int id);
        void RegistrarServicio(ServicioExtra servicio);
        Task<ServicioExtra> RenovarServicio(int id);
        Task<ServicioExtra> EditarServicio(int id, ServicioExtra servicio);
        Task<ServicioExtra> SetEstadoServicio(int id);
    }
}
