using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ArriendosDeTemporada.data;
using ArriendosDeTemporada.business;
using ArriendosDeTemporada.business.Shared;
using ArriendosDeTemporada.data.Repos;
using ArriendosDeTemporada.data.Repos.Shared;
using ArriendosDeTemporada.root.Profiles;

namespace ArriendosDeTemporada.root
{
    public class CompositionRoot
    {
        public CompositionRoot()
        {
        }

        public static void injectDependencies(IServiceCollection services)
        {
            // STRING DE CONEXION A DB, CAMBIAR ESTO PARA CAMBIAR DE BASE DE DATOS
            string DatabaseConnectionStr = "host=localhost; port=5432; database=ArriendosDeTemporada; user id=postgres; password=admin";
            services.AddDbContextPool<DatabaseContext>(options => options.UseNpgsql(DatabaseConnectionStr));

            services.AddAutoMapper(typeof(PerfilUsuario), typeof(PerfilDepartamento), typeof(PerfilFactura), 
                typeof(PerfilServicio), typeof(PerfilServicioFactura), typeof(PerfilUtilidad));
            services.AddScoped<DatabaseContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Añadir repos a dependencias
            services.AddScoped<IUsuarioRepo, UsuarioRepo>();
            services.AddScoped<IDepartamentoRepo, DepartamentoRepo>();
            services.AddScoped<IFacturaRepo, FacturaRepo>();
            services.AddScoped<IUtilidadRepo, UtilidadRepo>();

            // Añadir servicios a dependencias
            services.AddScoped<IUsuarioServicio, UsuarioServicio>();
            services.AddScoped<IDepartamentoServicio, DepartamentoServicio>();
            services.AddScoped<IFacturaServicio, FacturaServicio>();
        }
    }
}
