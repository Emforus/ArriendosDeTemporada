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

namespace ArriendosDeTemporada.business
{
    public class DepartamentoServicio : Shared.IDepartamentoServicio
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartamentoServicio(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<DepartamentoDTO> ListarDepartamentos()
        {
            IEnumerable<DepartamentoDTO> DepartamentoDTOs = _mapper.ProjectTo<DepartamentoDTO>(_unitOfWork.Departamentos.GetAllQueryable());
            return DepartamentoDTOs;
        }
        
        public async Task<DepartamentoDTO> BuscarDepartamento(int id)
        {
            var Departamento = _unitOfWork.Departamentos.GetDepartamento(id);
            return await _mapper.ProjectTo<DepartamentoDTO>(Departamento).FirstOrDefaultAsync();
        }

        public void CrearDepartamento(Departamento Departamento)
        {
            // Valores por defecto
            Departamento.estadoLogico = true;
            Departamento.Estado = "Disponible";
            Departamento.fechaRegistroDepartamento = DateTime.Now;
            _unitOfWork.Departamentos.Add(Departamento);
            _unitOfWork.Commit();
            return;
        }

        public async Task<Departamento> SetEstadoDepartamento(int id)
        {
            var Departamento = await _unitOfWork.Departamentos.Find(x => x.idDepartamento == id).AsQueryable().FirstOrDefaultAsync();
            if (Departamento != null)
            {
                Departamento.estadoLogico = !Departamento.estadoLogico;

                _unitOfWork.Commit();

                return Departamento;
            }
            return null;
        }

        public async Task<Departamento> EditarDepartamento(int id, Departamento depto)
        {
            var Departamento = await _unitOfWork.Departamentos.Find(x => x.idDepartamento == id).AsQueryable().FirstOrDefaultAsync();
            if (Departamento != null)
            {
                Departamento.ubicacionDepartamento = depto.ubicacionDepartamento;
                Departamento.regionDepartamento = depto.regionDepartamento;
                Departamento.descripcionDepartamento = depto.descripcionDepartamento;
                Departamento.valorBase = depto.valorBase;
                Departamento.cantidadDormitorios = depto.cantidadDormitorios;
                Departamento.Estado = depto.Estado;
                Departamento.fotografias = depto.fotografias;

                _unitOfWork.Commit();

                return Departamento;
            }
            return null;
        }

        public async Task<FacturaDTO> ReservarDepartamento(Factura factura)
        {
            int depto = factura.departamento.idDepartamento;
            int user = factura.usuario.ID;
            var Departamento = await _unitOfWork.Departamentos.GetDepartamento(depto).FirstOrDefaultAsync();
            var Usuario = await _unitOfWork.Usuarios.GetUsuario(user);
            if (Departamento != null && Usuario != null)
            {
                factura.usuario = Usuario;
                factura.departamento = Departamento;
                factura.fechaHoraGeneracion = DateTime.Now;
                factura.estado = "Pendiente";

                _unitOfWork.Facturas.Add(factura);

                Departamento.Estado = "Reservado";
                Departamento.fechaUltimaReserva = DateTime.Now;
                Departamento.facturas.Add(factura);

                Usuario.facturas.Add(factura);

                _unitOfWork.Commit();

                return _mapper.Map<FacturaDTO>(factura);
            }
            return null;
        }

        public async Task<Utilidad> AñadirUtilidad(Utilidad util, int id)
        {
            var Departamento = await _unitOfWork.Departamentos.GetDepartamento(id).FirstOrDefaultAsync();
            if (Departamento != null && util != null)
            {
                util.departamento = Departamento;
                Departamento.utilidades.Add(util);
                _unitOfWork.Utilidades.Add(util);

                _unitOfWork.Commit();

                return util;
            }
            return null;
        }

        public async Task<Utilidad> RemoverUtilidad(Utilidad util, int id)
        {
            var Departamento = await _unitOfWork.Departamentos.GetDepartamento(id).FirstOrDefaultAsync();
            if (Departamento != null && util != null)
            {
                if (Departamento.utilidades.Remove(util))
                {
                    _unitOfWork.Utilidades.Delete(util);

                    _unitOfWork.Commit();
                    return util;
                }
                return null;
            }
            return null;
        }

        public async Task<GenericService> ActualizarServicios(GenericService servicios, int id)
        {
            var Departamento = await _unitOfWork.Departamentos.GetDepartamento(id).FirstOrDefaultAsync();
            if (Departamento != null && servicios != null)
            {
                Departamento.serviciosPrincipales = servicios;
                _unitOfWork.Commit();
                return servicios;
            }
            return null;
        }
    }
}
