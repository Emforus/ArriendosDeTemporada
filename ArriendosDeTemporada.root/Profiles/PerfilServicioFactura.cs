using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ArriendosDeTemporada.core.Models;
using ArriendosDeTemporada.core.Models.DTOs;

namespace ArriendosDeTemporada.root.Profiles
{
    public class PerfilServicioFactura : Profile
    {
        public PerfilServicioFactura()
        {

            CreateMap<ServicioFactura, ServicioFacturaDTO>().ForMember(
                x => x.valorServicio, y => y.MapFrom(z => DeterminarValor(z.Factura.cantidadClientes, z.Servicio)));
        }

        int DeterminarValor(int clientes, ServicioExtra serv)
        {
            if (serv.servicioUnitario)
            {
                return clientes*serv.costoServicio;
            }
            return serv.costoServicio;
        }
    }
}
