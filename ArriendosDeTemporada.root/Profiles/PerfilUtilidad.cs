using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ArriendosDeTemporada.core.Models;
using ArriendosDeTemporada.core.Models.DTOs;

namespace ArriendosDeTemporada.root.Profiles
{
    public class PerfilUtilidad : Profile
    {
        public PerfilUtilidad()
        {
            CreateMap<Utilidad, UtilidadDTO>().ReverseMap();
        }
    }
}
