using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ArriendosDeTemporada.core.Models;
using ArriendosDeTemporada.data.Repos.Shared;
using Microsoft.EntityFrameworkCore;


namespace ArriendosDeTemporada.data.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IUsuarioRepo _UsuarioRepo;
        private IDepartamentoRepo _DepartamentoRepo;
        private IFacturaRepo _FacturaRepo;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IUsuarioRepo Usuarios
        {
            get { return _UsuarioRepo = _UsuarioRepo ?? new UsuarioRepo(_context); }
        }

        public IDepartamentoRepo Departamentos
        {
            get { return _DepartamentoRepo = _DepartamentoRepo ?? new DepartamentoRepo(_context); }
        }

        public IFacturaRepo Facturas
        {
            get { return _FacturaRepo = _FacturaRepo ?? new FacturaRepo(_context); }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async void CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context.Dispose();
        }
    }
}
