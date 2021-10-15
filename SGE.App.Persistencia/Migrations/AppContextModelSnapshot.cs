﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGE.App.Persistencia;

namespace SGE.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SGE.App.Dominio.Calificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("GrupoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("VrPonderado")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("Calificaciones");
                });

            modelBuilder.Entity("SGE.App.Dominio.Ciclo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ciclos");
                });

            modelBuilder.Entity("SGE.App.Dominio.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("SGE.App.Dominio.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CicloId")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FormadorId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TutorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CicloId");

                    b.HasIndex("FormadorId");

                    b.HasIndex("TutorId");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("SGE.App.Dominio.Horario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DiaSemana")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GrupoId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("HoraFinal")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HoraInicial")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("SGE.App.Dominio.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("EstudianteId")
                        .HasColumnType("int");

                    b.Property<int?>("GrupoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstudianteId");

                    b.HasIndex("GrupoId");

                    b.ToTable("Matricula");
                });

            modelBuilder.Entity("SGE.App.Dominio.Municipio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Municipios");
                });

            modelBuilder.Entity("SGE.App.Dominio.Nota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CalificacionId")
                        .HasColumnType("int");

                    b.Property<int?>("EstudianteId")
                        .HasColumnType("int");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CalificacionId");

                    b.HasIndex("EstudianteId");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("SGE.App.Dominio.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SGE.App.Dominio.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Entro")
                        .HasColumnType("bit");

                    b.Property<int?>("MunicipioId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MunicipioId");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SGE.App.Dominio.Calificacion", b =>
                {
                    b.HasOne("SGE.App.Dominio.Grupo", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId");

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("SGE.App.Dominio.Grupo", b =>
                {
                    b.HasOne("SGE.App.Dominio.Ciclo", "Ciclo")
                        .WithMany()
                        .HasForeignKey("CicloId");

                    b.HasOne("SGE.App.Dominio.Usuario", "Formador")
                        .WithMany()
                        .HasForeignKey("FormadorId");

                    b.HasOne("SGE.App.Dominio.Usuario", "Tutor")
                        .WithMany()
                        .HasForeignKey("TutorId");

                    b.Navigation("Ciclo");

                    b.Navigation("Formador");

                    b.Navigation("Tutor");
                });

            modelBuilder.Entity("SGE.App.Dominio.Horario", b =>
                {
                    b.HasOne("SGE.App.Dominio.Grupo", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId");

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("SGE.App.Dominio.Matricula", b =>
                {
                    b.HasOne("SGE.App.Dominio.Usuario", "Estudiante")
                        .WithMany()
                        .HasForeignKey("EstudianteId");

                    b.HasOne("SGE.App.Dominio.Grupo", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId");

                    b.Navigation("Estudiante");

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("SGE.App.Dominio.Municipio", b =>
                {
                    b.HasOne("SGE.App.Dominio.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId");

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("SGE.App.Dominio.Nota", b =>
                {
                    b.HasOne("SGE.App.Dominio.Calificacion", "Calificacion")
                        .WithMany()
                        .HasForeignKey("CalificacionId");

                    b.HasOne("SGE.App.Dominio.Matricula", "Estudiante")
                        .WithMany()
                        .HasForeignKey("EstudianteId");

                    b.Navigation("Calificacion");

                    b.Navigation("Estudiante");
                });

            modelBuilder.Entity("SGE.App.Dominio.Usuario", b =>
                {
                    b.HasOne("SGE.App.Dominio.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioId");

                    b.HasOne("SGE.App.Dominio.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId");

                    b.Navigation("Municipio");

                    b.Navigation("Rol");
                });
#pragma warning restore 612, 618
        }
    }
}
