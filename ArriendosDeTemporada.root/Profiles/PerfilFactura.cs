using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ArriendosDeTemporada.core.Models;
using ArriendosDeTemporada.core.Models.DTOs;

namespace ArriendosDeTemporada.root.Profiles
{
    public class PerfilFactura : Profile
    {
        public PerfilFactura()
        {
            CreateMap<Factura, FacturaDTO>().ReverseMap();
        }
    }
}
