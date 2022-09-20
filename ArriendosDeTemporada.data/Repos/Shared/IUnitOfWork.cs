using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.data.Repos.Shared
{
    public interface IUnitOfWork
    {
        IUsuarioRepo Usuarios { get; }
        IDepartamentoRepo Departamentos { get; }
        IFacturaRepo Facturas { get; }
        void Commit();
        void CommitAsync();
        void Rollback();
    }
}
