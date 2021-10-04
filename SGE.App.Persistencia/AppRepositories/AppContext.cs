using System;
using Microsoft.EntityFrameworkCore;
using SGE.App.Dominio;
using SGE.App.Persistencia;

namespace SGE.App.Persistencia
{
    public class AppContext:DbContext
    {        
        
        public DbSet<Departamento> Departamentos{get; set;}
        public DbSet<Municipio> Municipios{get; set;}
        public DbSet<Rol> Roles{get; set;}            
        public DbSet<Usuario> Usuarios{get; set;}
        public DbSet<Ciclo> Ciclos{get; set;}
        public DbSet<Horario> Horarios{get; set;}
        public DbSet<Grupo> Grupos{get; set;}
        public DbSet<Calificacion> Calificaciones{get; set;}
        public DbSet<Nota> Notas{get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder conn){
            if(!conn.IsConfigured){
                conn.UseSqlServer("Data source = (localdb)\\MSSQLLocalDB; Initial Catalog = SGE");
            }
        }        
    }
}
