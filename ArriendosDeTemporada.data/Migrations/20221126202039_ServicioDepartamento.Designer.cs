﻿// <auto-generated />
using System;
using System.Collections.Generic;
using ArriendosDeTemporada.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ArriendosDeTemporada.data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221126202039_ServicioDepartamento")]
    partial class ServicioDepartamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.Departamento", b =>
                {
                    b.Property<int>("idDepartamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<int>("cantidadDormitorios")
                        .HasColumnType("int");

                    b.Property<string>("descripcionDepartamento")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("estadoLogico")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("fechaRegistroDepartamento")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("fechaUltimaMantencion")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("fechaUltimaReserva")
                        .HasColumnType("timestamp");

                    b.Property<List<string>>("fotografias")
                        .HasColumnType("varchar(100)[]");

                    b.Property<string>("regionDepartamento")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("ubicacionDepartamento")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<int>("valorBase")
                        .HasColumnType("int");

                    b.HasKey("idDepartamento")
                        .HasName("PK_Departamento");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.Factura", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("cantidadClientes")
                        .HasColumnType("integer");

                    b.Property<int?>("departamentoidDepartamento")
                        .HasColumnType("int");

                    b.Property<int>("duracion")
                        .HasColumnType("int");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<DateTime?>("fechaHoraCheckIn")
                        .HasColumnType("timestamp");

                    b.Property<DateTime?>("fechaHoraCheckOut")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("fechaHoraGeneracion")
                        .HasColumnType("timestamp");

                    b.Property<DateTime>("fechaHoraReserva")
                        .HasColumnType("timestamp");

                    b.Property<int?>("usuarioID")
                        .HasColumnType("int");

                    b.Property<int>("valor")
                        .HasColumnType("int");

                    b.Property<int>("valorDeposito")
                        .HasColumnType("int");

                    b.Property<int>("valorIVA")
                        .HasColumnType("int");

                    b.Property<int>("valorServicios")
                        .HasColumnType("int");

                    b.HasKey("ID")
                        .HasName("PK_Factura");

                    b.HasIndex("departamentoidDepartamento");

                    b.HasIndex("usuarioID");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.GenericService", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("AllowsChildren")
                        .HasColumnType("boolean");

                    b.Property<bool>("AllowsPets")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasAC")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasElevator")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasParking")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasPool")
                        .HasColumnType("boolean");

                    b.Property<bool>("HasWifi")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsWheelchairAccessible")
                        .HasColumnType("boolean");

                    b.Property<List<string>>("OtherServices")
                        .HasColumnType("varchar(100)[]");

                    b.Property<int>("idDepartamento")
                        .HasColumnType("int");

                    b.HasKey("ID")
                        .HasName("PK_Serv_Generico");

                    b.HasIndex("idDepartamento")
                        .IsUnique();

                    b.ToTable("ServiciosGenericos");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.Multa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IDFactura")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .HasColumnType("text");

                    b.Property<int>("valor")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("IDFactura")
                        .IsUnique();

                    b.ToTable("Multa");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.ServicioDepartamento", b =>
                {
                    b.Property<int>("IDServicio")
                        .HasColumnType("int");

                    b.Property<int>("IDDepartamento")
                        .HasColumnType("int");

                    b.HasKey("IDServicio", "IDDepartamento");

                    b.HasIndex("IDDepartamento");

                    b.ToTable("ServicioDepartamento");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.ServicioExtra", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("costoServicio")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<bool>("estadoLogico")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("fechaContrato")
                        .HasColumnType("date");

                    b.Property<DateTime>("fechaExpiracion")
                        .HasColumnType("date");

                    b.Property<DateTime?>("fechaUltimaRenovacion")
                        .HasColumnType("date");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<bool>("servicioUnitario")
                        .HasColumnType("boolean");

                    b.HasKey("ID")
                        .HasName("PK_Servicio");

                    b.ToTable("ServiciosExtra");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.ServicioFactura", b =>
                {
                    b.Property<int>("IDServicio")
                        .HasColumnType("int");

                    b.Property<int>("IDFactura")
                        .HasColumnType("int");

                    b.Property<int>("valorServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("IDServicio", "IDFactura");

                    b.HasIndex("IDFactura");

                    b.ToTable("ServicioFactura");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.Usuario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("UID")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<bool>("estadoLogico")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("fechaRegistroUsuario")
                        .HasColumnType("date");

                    b.Property<DateTime>("lastLogOn")
                        .HasColumnType("timestamp");

                    b.Property<string>("nombreUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("passwordHash")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("ID")
                        .HasName("PK_Usuario");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UID")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.Utilidad", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("MultaID")
                        .HasColumnType("integer");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<int?>("departamentoidDepartamento")
                        .HasColumnType("int");

                    b.Property<string>("descripcion")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<int>("valor")
                        .HasColumnType("int");

                    b.HasKey("ID")
                        .HasName("PK_Utilidad");

                    b.HasIndex("MultaID");

                    b.HasIndex("departamentoidDepartamento");

                    b.ToTable("Utilidades");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.Factura", b =>
                {
                    b.HasOne("ArriendosDeTemporada.core.Models.Departamento", "departamento")
                        .WithMany("facturas")
                        .HasForeignKey("departamentoidDepartamento");

                    b.HasOne("ArriendosDeTemporada.core.Models.Usuario", "usuario")
                        .WithMany("facturas")
                        .HasForeignKey("usuarioID");

                    b.Navigation("departamento");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.GenericService", b =>
                {
                    b.HasOne("ArriendosDeTemporada.core.Models.Departamento", null)
                        .WithOne("serviciosPrincipales")
                        .HasForeignKey("ArriendosDeTemporada.core.Models.GenericService", "idDepartamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.Multa", b =>
                {
                    b.HasOne("ArriendosDeTemporada.core.Models.Factura", "factura")
                        .WithOne("multa")
                        .HasForeignKey("ArriendosDeTemporada.core.Models.Multa", "IDFactura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("factura");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.ServicioDepartamento", b =>
                {
                    b.HasOne("ArriendosDeTemporada.core.Models.Departamento", "Departamento")
                        .WithMany("ServiciosDisponibles")
                        .HasForeignKey("IDDepartamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArriendosDeTemporada.core.Models.ServicioExtra", "Servicio")
                        .WithMany("ServiciosDisponibles")
                        .HasForeignKey("IDServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.ServicioFactura", b =>
                {
                    b.HasOne("ArriendosDeTemporada.core.Models.Factura", "Factura")
                        .WithMany("ServiciosPorFactura")
                        .HasForeignKey("IDFactura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArriendosDeTemporada.core.Models.ServicioExtra", "Servicio")
                        .WithMany("ServiciosPorFactura")
                        .HasForeignKey("IDServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factura");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.Utilidad", b =>
                {
                    b.HasOne("ArriendosDeTemporada.core.Models.Multa", null)
                        .WithMany("utilidades")
                        .HasForeignKey("MultaID");

                    b.HasOne("ArriendosDeTemporada.core.Models.Departamento", "departamento")
                        .WithMany("utilidades")
                        .HasForeignKey("departamentoidDepartamento");

                    b.Navigation("departamento");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.Departamento", b =>
                {
                    b.Navigation("facturas");

                    b.Navigation("ServiciosDisponibles");

                    b.Navigation("serviciosPrincipales");

                    b.Navigation("utilidades");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.Factura", b =>
                {
                    b.Navigation("multa");

                    b.Navigation("ServiciosPorFactura");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.Multa", b =>
                {
                    b.Navigation("utilidades");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.ServicioExtra", b =>
                {
                    b.Navigation("ServiciosDisponibles");

                    b.Navigation("ServiciosPorFactura");
                });

            modelBuilder.Entity("ArriendosDeTemporada.core.Models.Usuario", b =>
                {
                    b.Navigation("facturas");
                });
#pragma warning restore 612, 618
        }
    }
}
