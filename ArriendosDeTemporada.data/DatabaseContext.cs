using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ArriendosDeTemporada.core.Models;

namespace ArriendosDeTemporada.data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<ServicioExtra> ServiciosExtra { get; set; }
        public DbSet<Utilidad> Utilidades { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurar DB con Fluent API de EntityFrameworkCore

            //Entidades a tablas
            modelBuilder.Entity<Departamento>().ToTable("Departamentos");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Factura>().ToTable("Facturas");
            modelBuilder.Entity<ServicioExtra>().ToTable("ServiciosExtra");
            modelBuilder.Entity<Utilidad>().ToTable("Utilidades");
            modelBuilder.Entity<GenericService>().ToTable("ServiciosGenericos");

            //Configuracion de llaves primarias
            modelBuilder.Entity<Departamento>().HasKey(c => c.idDepartamento).HasName("PK_Departamento");
            modelBuilder.Entity<Usuario>().HasKey(s => s.ID).HasName("PK_Usuario");
            modelBuilder.Entity<Factura>().HasKey(p => p.ID).HasName("PK_Factura");
            modelBuilder.Entity<ServicioExtra>().HasKey(s => s.ID).HasName("PK_Servicio");
            modelBuilder.Entity<Utilidad>().HasKey(p => p.ID).HasName("PK_Utilidad");
            modelBuilder.Entity<GenericService>().HasKey(p => p.ID).HasName("PK_Serv_Generico");

            //Configuracion de columnas
            modelBuilder.Entity<Departamento>().Property(c => c.idDepartamento).HasColumnType("int").UseIdentityColumn().IsRequired();
            modelBuilder.Entity<Departamento>().Property(c => c.ubicacionDepartamento).HasColumnType("varchar(40)").IsRequired();
            modelBuilder.Entity<Departamento>().Property(c => c.regionDepartamento).HasColumnType("varchar(40)").IsRequired();
            modelBuilder.Entity<Departamento>().Property(c => c.descripcionDepartamento).HasColumnType("varchar(200)").IsRequired();
            modelBuilder.Entity<Departamento>().Property(c => c.Estado).HasColumnType("varchar(40)").IsRequired();
            modelBuilder.Entity<Departamento>().Property(p => p.valorBase).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Departamento>().Property(p => p.cantidadDormitorios).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Departamento>().Property(c => c.fechaRegistroDepartamento).HasColumnType("timestamp").IsRequired();
            modelBuilder.Entity<Departamento>().Property(c => c.fechaUltimaReserva).HasColumnType("timestamp").IsRequired(false);
            modelBuilder.Entity<Departamento>().Property(c => c.fechaUltimaMantencion).HasColumnType("timestamp").IsRequired(false);
            modelBuilder.Entity<Departamento>().Property(c => c.estadoLogico).HasColumnType("boolean").IsRequired();
            modelBuilder.Entity<Departamento>().Property(c => c.fotografias).HasColumnType("varchar(100)[]").IsRequired(false);

            modelBuilder.Entity<Usuario>().Property(c => c.ID).HasColumnType("int").UseIdentityColumn().IsRequired();
            modelBuilder.Entity<Usuario>().Property(c => c.UID).HasColumnType("varchar(40)").IsRequired();
            modelBuilder.Entity<Usuario>().HasIndex(c => c.UID).IsUnique();
            modelBuilder.Entity<Usuario>().Property(c => c.Email).HasColumnType("varchar(40)").IsRequired();
            modelBuilder.Entity<Usuario>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<Usuario>().Property(c => c.Rol).HasColumnType("varchar(40)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(c => c.nombreUsuario).HasColumnType("varchar(40)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(c => c.fechaRegistroUsuario).HasColumnType("date").IsRequired();
            modelBuilder.Entity<Usuario>().Property(c => c.lastLogOn).HasColumnType("timestamp").IsRequired();
            modelBuilder.Entity<Usuario>().Property(c => c.passwordHash).HasColumnType("varchar(200)").IsRequired();
            modelBuilder.Entity<Usuario>().Property(c => c.estadoLogico).HasColumnType("boolean").IsRequired();

            modelBuilder.Entity<Utilidad>().Property(c => c.ID).HasColumnType("int").UseIdentityColumn().IsRequired();
            modelBuilder.Entity<Utilidad>().Property(c => c.nombre).HasColumnType("varchar(40)").IsRequired();
            modelBuilder.Entity<Utilidad>().Property(c => c.descripcion).HasColumnType("varchar(40)").IsRequired(false);
            modelBuilder.Entity<Utilidad>().Property(c => c.valor).HasColumnType("int").IsRequired();

            modelBuilder.Entity<Factura>().Property(p => p.ID).HasColumnType("int").UseIdentityColumn().IsRequired();
            modelBuilder.Entity<Factura>().Property(p => p.valorIVA).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Factura>().Property(p => p.duracion).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Factura>().Property(p => p.estado).HasColumnType("varchar(40)").IsRequired();
            modelBuilder.Entity<Factura>().Property(p => p.fechaHoraGeneracion).HasColumnType("timestamp").IsRequired();
            modelBuilder.Entity<Factura>().Property(p => p.fechaHoraCheckIn).HasColumnType("timestamp").IsRequired(false);
            modelBuilder.Entity<Factura>().Property(p => p.fechaHoraCheckOut).HasColumnType("timestamp").IsRequired(false);
            modelBuilder.Entity<Factura>().Property(p => p.fechaHoraReserva).HasColumnType("timestamp").IsRequired();

            modelBuilder.Entity<ServicioExtra>().Property(p => p.ID).HasColumnType("int").UseIdentityColumn().IsRequired();
            modelBuilder.Entity<ServicioExtra>().Property(p => p.nombre).HasColumnType("varchar(40)").IsRequired();
            modelBuilder.Entity<ServicioExtra>().Property(p => p.descripcion).HasColumnType("varchar(40)").IsRequired();
            modelBuilder.Entity<ServicioExtra>().Property(p => p.costoServicio).HasColumnType("int").IsRequired();
            modelBuilder.Entity<ServicioExtra>().Property(p => p.servicioUnitario).HasColumnType("boolean").IsRequired();
            modelBuilder.Entity<ServicioExtra>().Property(p => p.fechaContrato).HasColumnType("date").IsRequired();
            modelBuilder.Entity<ServicioExtra>().Property(p => p.fechaExpiracion).HasColumnType("date").IsRequired();
            modelBuilder.Entity<ServicioExtra>().Property(p => p.fechaUltimaRenovacion).HasColumnType("date").IsRequired(false);
            modelBuilder.Entity<ServicioExtra>().Property(p => p.estadoLogico).HasColumnType("boolean").IsRequired();

            modelBuilder.Entity<GenericService>().Property(p => p.ID).HasColumnType("int").UseIdentityColumn().IsRequired();
            modelBuilder.Entity<GenericService>().Property(p => p.HasWifi).HasColumnType("boolean").IsRequired();
            modelBuilder.Entity<GenericService>().Property(p => p.AllowsPets).HasColumnType("boolean").IsRequired();
            modelBuilder.Entity<GenericService>().Property(p => p.HasAC).HasColumnType("boolean").IsRequired();
            modelBuilder.Entity<GenericService>().Property(p => p.HasElevator).HasColumnType("boolean").IsRequired();
            modelBuilder.Entity<GenericService>().Property(p => p.HasParking).HasColumnType("boolean").IsRequired();
            modelBuilder.Entity<GenericService>().Property(p => p.HasPool).HasColumnType("boolean").IsRequired();
            modelBuilder.Entity<GenericService>().Property(p => p.AllowsChildren).HasColumnType("boolean").IsRequired();
            modelBuilder.Entity<GenericService>().Property(p => p.IsWheelchairAccessible).HasColumnType("boolean").IsRequired();
            modelBuilder.Entity<GenericService>().Property(c => c.OtherServices).HasColumnType("varchar(100)[]").IsRequired(false);

            //Configuracion de relaciones
            modelBuilder.Entity<Factura>().HasOne(f => f.departamento).WithMany(d => d.facturas);
            modelBuilder.Entity<Factura>().HasOne(f => f.usuario).WithMany(u => u.facturas);            
            modelBuilder.Entity<Factura>().HasMany(f => f.Servicios).WithMany(p => p.Facturas).UsingEntity<ServicioFactura>(
                x => x.HasOne(pp => pp.Servicio).WithMany(p => p.ServiciosPorFactura).HasForeignKey(pp => pp.IDServicio),
                x => x.HasOne(pp => pp.Factura).WithMany(p => p.ServiciosPorFactura).HasForeignKey(pp => pp.IDFactura),
                x =>
                {
                    x.Property(pp => pp.valorServicio).HasDefaultValue(0);
                    x.HasKey(pp => new { pp.IDServicio, pp.IDFactura });
                });
            modelBuilder.Entity<Utilidad>().HasOne(f => f.departamento).WithMany(u => u.utilidades);
            modelBuilder.Entity<Departamento>().HasOne(f => f.serviciosPrincipales).WithOne().HasForeignKey<GenericService>(g => g.idDepartamento);
        }
    }
}
