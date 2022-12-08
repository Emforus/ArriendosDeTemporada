using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using ArriendosDeTemporada.core.Models;
using ArriendosDeTemporada.data.Repos;
using ArriendosDeTemporada.data.Repos.Shared;
using ArriendosDeTemporada.core.Models.DTOs;
using AutoMapper;
using BCrypt.Net;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace ArriendosDeTemporada.business
{
    public class ServicioExtraServicio : Shared.IServicioExtraServicio
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServicioExtraServicio(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<ServicioExtraDTO> ListarServicios()
        {
            IEnumerable<ServicioExtraDTO> servicios = _mapper.ProjectTo<ServicioExtraDTO>(_unitOfWork.Servicios.GetAllQueryable());
            return servicios;
        }

        public async Task<ServicioExtraDTO> BuscarServicio(int id)
        {
            var servicio = _unitOfWork.Servicios.Query(x => x.ID == id);
            return await _mapper.ProjectTo<ServicioExtraDTO>(servicio).FirstOrDefaultAsync();
        }

        public void RegistrarServicio(ServicioExtra servicio)
        {
            // Valores por defecto
            servicio.estadoLogico=true;
            _unitOfWork.Servicios.Add(servicio);
            _unitOfWork.Commit();
            return;
        }

        public async Task<ServicioExtra> EditarServicio(int id, ServicioExtra svc)
        {
            var servicio = await _unitOfWork.Servicios.Query(x => x.ID == id).FirstOrDefaultAsync(); 
            if (servicio != null)
            {
                servicio.nombre = svc.nombre;
                servicio.descripcion = svc.descripcion;
                servicio.costoServicio = svc.costoServicio;
                servicio.fechaUltimaRenovacion = svc.fechaUltimaRenovacion;
                servicio.fechaContrato = svc.fechaContrato;
                servicio.fechaExpiracion = svc.fechaExpiracion;
                servicio.servicioUnitario = svc.servicioUnitario;

                _unitOfWork.Commit();
                return servicio;
            }
            return null;
        }

        public async Task<ServicioExtra> RenovarServicio(int id)
        {
            var servicio = await _unitOfWork.Servicios.Query(x => x.ID == id).FirstOrDefaultAsync();
            if (servicio != null)
            {
                servicio.fechaUltimaRenovacion = DateTime.Now;
                servicio.fechaExpiracion = DateTime.Now.AddMonths(3);

                _unitOfWork.Commit();
                return servicio;
            }
            return null;
        }

        public async Task<ServicioExtra> SetEstadoServicio(int id)
        {
            var servicio = await _unitOfWork.Servicios.Query(x => x.ID == id).FirstOrDefaultAsync();
            if (servicio != null)
            {
                servicio.estadoLogico = !servicio.estadoLogico;

                _unitOfWork.Commit();

                return servicio;
            }
            return null;
        }
    }
}
