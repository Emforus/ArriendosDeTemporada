using System;
using System.Collections.Generic;
using System.Text;
using ArriendosDeTemporada.core.Models;
using System.Threading.Tasks;

namespace ArriendosDeTemporada.data.Repos.Shared
{
    public interface IUtilidadRepo : IRepository<Utilidad>
    {
        Task<Utilidad> GetUtilidad(int id);
        Task<List<Utilidad>> GetUtilidadesByDepartamento(int id);
    }
}
