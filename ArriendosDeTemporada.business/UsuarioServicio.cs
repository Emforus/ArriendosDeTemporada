using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using ArriendosDeTemporada.core.Models;
using ArriendosDeTemporada.data.Repos;
using ArriendosDeTemporada.data.Repos.Shared;
using ArriendosDeTemporada.core.Models.DTOs;
using AutoMapper;
using System.Linq;

namespace ArriendosDeTemporada.business
{
    public class UsuarioServicio : Shared.IUsuarioServicio
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioServicio(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<UsuarioDTO> ListarUsuarios()
        {
            IEnumerable<UsuarioDTO> UsuarioDTOs = _mapper.ProjectTo<UsuarioDTO>(_unitOfWork.Usuarios.GetAllQueryable());
            return UsuarioDTOs;
        }
        
        public async Task<UsuarioDTO> BuscarUsuario(int id)
        {
            var Usuario = await _unitOfWork.Usuarios.GetUsuario(id);
            return _mapper.Map<UsuarioDTO>(Usuario);
        }

        public void CrearUsuario(Usuario usuario)
        {
            // Valores por defecto
            usuario.fechaRegistroUsuario = DateTime.Now;
            usuario.lastLogOn = DateTime.Now;
            usuario.estadoLogico = true;

            _unitOfWork.Usuarios.Add(usuario);
            _unitOfWork.Commit();
            return;
        }

        public async Task<Usuario> DeshabilitarUsuario(int id)
        {
            var usuario = await _unitOfWork.Usuarios.GetUsuario(id);
            if (usuario != null)
            {
                usuario.estadoLogico = false;

                _unitOfWork.Commit();

                return usuario;
            }
            return null;
        }
    }
}
