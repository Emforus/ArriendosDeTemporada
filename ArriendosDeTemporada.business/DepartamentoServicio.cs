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
using System.Collections;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.FileProviders;

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

            _unitOfWork.Departamentos.Add(Departamento);
            _unitOfWork.Commit();
            return;
        }

        public void CargarFotos(List<IFormFile> pics)
        {
            if (pics != null && pics.Count > 0)
            {
                foreach (IFormFile img in pics)
                {
                    var fileName = Path.GetFileName(img.FileName);
                    Console.WriteLine(fileName);
                    var filePath = new PhysicalFileProvider(
                        "C:/Users/seb_carrascot/Desktop/Front_ArriendosDeTemporada/src/assets/img/deptos"
                    ).Root + $@"/{fileName}";
                    using (FileStream fs = File.Create(filePath))
                    {
                        img.CopyTo(fs);
                        fs.Flush();
                    }
                }
            }
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
                Departamento.nombreDepartamento = depto.nombreDepartamento;
                Departamento.ubicacionDepartamento = depto.ubicacionDepartamento;
                Departamento.regionDepartamento = depto.regionDepartamento;
                Departamento.descripcionDepartamento = depto.descripcionDepartamento;
                Departamento.valorBase = depto.valorBase;
                Departamento.cantidadDormitorios = depto.cantidadDormitorios;
                Departamento.Estado = depto.Estado;
                Departamento.fotografias = depto.fotografias;
                Departamento.serviciosPrincipales = depto.serviciosPrincipales;

                var Utilidades = await _unitOfWork.Utilidades.GetUtilidadesByDepartamento(id);
                depto.utilidades ??= new List<Utilidad>();
                Departamento.utilidades ??= new List<Utilidad>();
                //Eliminar registros no detectados
                foreach (Utilidad item in Utilidades)
                {
                    var util = depto.utilidades.Find(x => x.ID == item.ID);
                    if (util != null)
                    {
                        continue;
                    }
                    else
                    {
                        Departamento.utilidades.Remove(item);
                        _unitOfWork.Utilidades.Delete(item);
                    }
                }

                //Actualizar existentes, registrar nuevas
                foreach (Utilidad item in depto.utilidades)
                {
                    if (item.ID == 0)
                    {
                        item.departamento = Departamento;
                        Departamento.utilidades.Add(item);
                        _unitOfWork.Utilidades.Add(item);
                    }
                    else
                    {
                        var util = Utilidades.Find(x => x.ID == item.ID);
                        if (util != null)
                        {
                            util.nombre = item.nombre;
                            util.valor = item.valor;
                            util.descripcion = item.descripcion;
                            util.cantidad = item.cantidad;
                            util.estado = item.estado;
                        }
                    }
                }

                var Servicios = await _unitOfWork.Departamentos.GetServiciosPorDepartamento(id);
                depto.ServiciosDisponibles ??= new List<ServicioDepartamento>();
                Departamento.ServiciosDisponibles ??= new List<ServicioDepartamento>();
                //Eliminar registros no detectados
                foreach (ServicioDepartamento svc in Servicios)
                {
                    var item = depto.ServiciosDisponibles.Find(x => x.IDServicio == svc.IDServicio);
                    if (item != null)
                    {
                        continue;
                    }
                    else
                    {
                        Departamento.ServiciosDisponibles.Remove(svc);
                        _unitOfWork.Servicios.DeleteFromDepartamento(svc);
                    }
                }

                //Registrar nuevos
                foreach (ServicioDepartamento svc in depto.ServiciosDisponibles)
                {
                    var item = Servicios.Find(x => x.IDServicio == svc.IDServicio);
                    if (item != null)
                    {
                        continue;
                    } else { 
                        svc.Departamento = Departamento;
                        svc.Servicio = null;
                        Departamento.ServiciosDisponibles.Add(svc);
                        _unitOfWork.Servicios.AddToDepartamento(svc);
                    }
                }

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
                foreach (ServicioFactura item in factura.ServiciosPorFactura)
                {
                    item.Servicio = null;
                    item.Factura = factura;
                }

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

        public async Task<IQueryable<UtilidadDTO>> ListarUtilidades(int id)
        {
            var Departamento = await _unitOfWork.Departamentos.GetDepartamento(id).FirstOrDefaultAsync();
            if (Departamento != null)
            {
                var Utilidades = await _unitOfWork.Utilidades.GetUtilidadesByDepartamento(id);
                return _mapper.ProjectTo<UtilidadDTO>(Utilidades.AsQueryable());
                
            }
            return null;
        }

        public async Task<IQueryable<ServicioDepartamentoDTO>> ListarServiciosDisponibles(int id)
        {
            var Departamento = await _unitOfWork.Departamentos.GetDepartamento(id).FirstOrDefaultAsync();
            if (Departamento != null)
            {
                var Servicios = await _unitOfWork.Departamentos.GetServiciosPorDepartamento(id);
                return _mapper.ProjectTo<ServicioDepartamentoDTO>(Servicios.AsQueryable());

            }
            return null;
        }

        public async Task<Departamento> AñadirUtilidades(Utilidad[] util, int id)
        {
            var Departamento = await _unitOfWork.Departamentos.GetDepartamento(id).FirstOrDefaultAsync();
            if (Departamento != null && util != null)
            {
                Departamento.utilidades = Departamento.utilidades ?? await _unitOfWork.Utilidades.GetUtilidadesByDepartamento(id);
                foreach (Utilidad u in util)
                {
                    u.departamento = Departamento;
                    Departamento.utilidades.Add(u);
                }
                _unitOfWork.Utilidades.AddMany(util);

                _unitOfWork.Commit();

                return Departamento;
            }
            return null;
        }

        public async Task<Departamento> RemoverUtilidades(Utilidad[] util, int id)
        {
            var Departamento = await _unitOfWork.Departamentos.GetDepartamento(id).FirstOrDefaultAsync();
            if (Departamento != null && util != null)
            {
                Departamento.utilidades ??= await _unitOfWork.Utilidades.GetUtilidadesByDepartamento(id);
                foreach (Utilidad item in util)
                {
                    var u = Departamento.utilidades.Find(x => x.ID == item.ID);
                    if (u != null)
                    {
                        _unitOfWork.Utilidades.Delete(u);
                        Departamento.utilidades.Remove(u);
                    }
                }
                _unitOfWork.Commit();
                return Departamento;
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
