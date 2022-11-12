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
            CreateMap<Factura, FacturaDTO>().ForMember(
                x => x.valorTotal, y => y.MapFrom(z => DeterminarValor(z.departamento.valorBase, z.duracion, z.valorIVA))).ReverseMap();
        }

        private static int DeterminarValor(int valor, int dias, int iva)
        {
            return (valor * dias) + iva;
        }
    }
}
