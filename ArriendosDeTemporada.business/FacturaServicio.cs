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
    public class FacturaServicio : Shared.IFacturaServicio
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FacturaServicio(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<FacturaDTO> ListarFacturas()
        {
            IEnumerable<FacturaDTO> facturaDTOs = _mapper.ProjectTo<FacturaDTO>(_unitOfWork.Facturas.GetAllQueryable());
            return facturaDTOs;
        }
        public IQueryable<FacturaDTO> ListarFacturasPorDepartamento(int id)
        {
            var Facturas = _unitOfWork.Facturas.Query(x => x.departamento.idDepartamento == id);
            IQueryable<FacturaDTO> facturaDTOs = _mapper.ProjectTo<FacturaDTO>(Facturas);
            return facturaDTOs;
        }
        public IQueryable<FacturaDTO> ListarFacturasPorCliente(int id)
        {
            var Facturas = _unitOfWork.Facturas.Query(x => x.usuario.ID == id);
            IQueryable<FacturaDTO> facturaDTOs = _mapper.ProjectTo<FacturaDTO>(Facturas);
            return facturaDTOs;
        }

        public async Task<FacturaDTO> BuscarFactura(int id)
        {
            var Factura = _unitOfWork.Facturas.GetFactura(id);
            return await _mapper.ProjectTo<FacturaDTO>(Factura).FirstOrDefaultAsync();
        }

        public async Task<Factura> AnularFactura(Factura factura)
        {
            var Factura = await _unitOfWork.Facturas.GetFactura(factura.ID).FirstOrDefaultAsync();
            if (Factura != null)
            {
                var departamento = await _unitOfWork.Departamentos.GetDepartamento(factura.departamento.idDepartamento).FirstOrDefaultAsync();
                if (departamento.Estado == "Reservado")
                {
                    departamento.Estado = "Disponible";
                }
                Factura.estado = "Cancelada";

                _unitOfWork.Commit();
                return Factura;
            }
            return null;
        }

        public async Task<Factura> CheckIn(Factura fac)
        {
            var Factura = await _unitOfWork.Facturas.GetFactura(fac.ID).FirstOrDefaultAsync();
            if (Factura != null)
            {
                var departamento = await _unitOfWork.Departamentos.GetDepartamento(fac.departamento.idDepartamento).FirstOrDefaultAsync();
                departamento.Estado = "En Uso";
                Factura.estado = "En Curso";
                Factura.fechaHoraCheckIn = DateTime.Now;

                _unitOfWork.Commit();
                return Factura;
            }
            return null;
        }

        public async Task<Factura> CheckOut(Factura fac)
        {
            var Factura = await _unitOfWork.Facturas.GetFactura(fac.ID).FirstOrDefaultAsync();
            if (Factura != null)
            {
                var departamento = await _unitOfWork.Departamentos.GetDepartamento(Factura.departamento.idDepartamento).FirstOrDefaultAsync();
                departamento.Estado = "Disponible";
                Factura.estado = "Completada";
                Factura.fechaHoraCheckOut = DateTime.Now;

                _unitOfWork.Commit();
                return Factura;
            }
            return null;
        }
    }
}
