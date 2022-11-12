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

        public async Task<UsuarioDTO> BuscarUsername(string username)
        {
            var Usuario = await _unitOfWork.Usuarios.GetUsuarioByUsername(username);
            return _mapper.Map<UsuarioDTO>(Usuario);
        }

        public void CrearUsuario(Usuario usuario)
        {
            // Valores por defecto
            usuario.fechaRegistroUsuario = DateTime.Now;
            usuario.Rol = usuario.Rol ?? "Cliente";
            usuario.lastLogOn = DateTime.Now;
            usuario.estadoLogico = true;
            // Encriptar contraseña con BCrypt
            usuario.passwordHash = BCrypt.Net.BCrypt.HashPassword(usuario.passwordHash);
            _unitOfWork.Usuarios.Add(usuario);
            _unitOfWork.Commit();
            return;
        }

        public async Task<Usuario> SetEstadoUsuario(int id)
        {
            var usuario = await _unitOfWork.Usuarios.Find(x => x.ID == id).AsQueryable().FirstOrDefaultAsync();
            if (usuario != null)
            {
                usuario.estadoLogico = !usuario.estadoLogico;

                _unitOfWork.Commit();

                return usuario;
            }
            return null;
        }

        public async Task<Usuario> CambiarContraseña(AuthDataDTO data)
        {
            string username = data.username;
            string password = data.password;
            if (username != null && username.Length != 0 && password != null && password.Length != 0)
            {
                var user = await _unitOfWork.Usuarios.Find(x => x.UID == username).AsQueryable().FirstOrDefaultAsync();
                if (user != null)
                {
                    user.passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
                    _unitOfWork.Commit();
                    return user;
                }
            }
            return null;
        }

        public async Task<Usuario> EditarUsuario(int id, Usuario user)
        {
            var usuario = await _unitOfWork.Usuarios.Find(x => x.ID == id).AsQueryable().FirstOrDefaultAsync();
            if (usuario != null)
            {
                usuario.UID = user.UID;
                usuario.Email = user.Email;
                usuario.nombreUsuario = user.nombreUsuario;
                usuario.Rol = user.Rol;

                _unitOfWork.Commit();

                return usuario;
            }
            return null;
        }

        public async Task<bool> Autenticar(AuthDataDTO data)
        {
            string username = data.username;
            string password = data.password;
            if (username != null && username.Length != 0 && password != null && password.Length != 0)
            {
                var Usuario = await _unitOfWork.Usuarios.GetUsuarioByUsername(username);
                if (Usuario == null || !BCrypt.Net.BCrypt.Verify(password, Usuario.passwordHash))
                {
                    return false;
                }
                else
                {
                    Usuario.lastLogOn = DateTime.Now;
                    _unitOfWork.Commit();
                    return true;
                }
            }
            return false;
        }
        public async Task<Usuario> RemoverUsuario(int id)
        {
            var user = await _unitOfWork.Usuarios.Find(x => x.ID == id).AsQueryable().FirstOrDefaultAsync();
            if (user != null)
            {
                _unitOfWork.Usuarios.Delete(user);
                _unitOfWork.Commit();
                return user;
            }
            return null;
        }
    }
}
