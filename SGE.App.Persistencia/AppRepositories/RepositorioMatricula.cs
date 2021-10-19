using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using SGE.App.Dominio;

namespace SGE.App.Persistencia
{
    public class RepositorioMatricula:IRepositorioMatricula
    {
        
        ///<sumary>
        ///Referencia al contexto de Matricula
        ///</sumary>
        
        private readonly AppContext _appContext;
        
        ///<sumary>
        ///Metodo constructor utiliza
        ///Inyeccion de dependencias para garantizar el contexto
        ///</sumary>
        ///<param name="appContext"></param>//

        public RepositorioMatricula(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Usuario usuario {get; set;}

        Matricula IRepositorioMatricula.AddMatricula(Matricula matricula)
        {
            var matriculaAdicionado =_appContext.Matricula.Add(matricula);
            _appContext.SaveChanges();
            return matriculaAdicionado.Entity;
        }

        void IRepositorioMatricula.DeleteMatricula(int idMatricula)
        {
            var matriculaEncontrado = _appContext.Matricula.FirstOrDefault(m => m.Id==idMatricula);
            if(matriculaEncontrado==null)
                return;
            _appContext.Matricula.Remove(matriculaEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Matricula> IRepositorioMatricula.GetAllMatriculas()
        {
            return _appContext.Matricula
            .Include(g=>g.Grupo)
                .ThenInclude(g=>g.Ciclo)
            .Include(g=>g.Grupo)    
                .ThenInclude(g=>g.Formador)
            .Include(g=>g.Grupo)
                .ThenInclude(g=>g.Tutor)    
            .Include(g=>g.Estudiante);
        }

        Matricula IRepositorioMatricula.GetMatricula(int idMatricula)
        {
            return _appContext.Matricula
                .Include(g=>g.Grupo)
                    .ThenInclude(g=>g.Ciclo)
                .Include(g=>g.Grupo)    
                    .ThenInclude(g=>g.Formador)
                .Include(g=>g.Grupo)
                    .ThenInclude(g=>g.Tutor)    
                .Include(g=>g.Estudiante)    
                .FirstOrDefault(m => m.Id==idMatricula);
        }

        Matricula IRepositorioMatricula.UpdateMatricula(Matricula matricula)
        {
            var matriculaEncontrado =_appContext.Matricula
                .Include(g=>g.Grupo)
                .Include(g=>g.Estudiante)
                .FirstOrDefault(m => m.Id==matricula.Id);
            
            if(matriculaEncontrado!=null)
            {
                matriculaEncontrado.Grupo = matricula.Grupo;
                matriculaEncontrado.Estudiante = matricula.Estudiante;
                _appContext.SaveChanges();
            }
            return matriculaEncontrado;
        }

        IEnumerable<Matricula> IRepositorioMatricula.GetAllMisGrupos(int usuarioId)
        {   

            //Rol del Usuario
            usuario = _appContext.Usuarios
                .Include(g=>g.Rol)
                .FirstOrDefault(g=>g.Id == usuarioId);

            
            if(usuario.Rol.Nombre == "Formador")
            {
                //Si el usuario es: Formador
                return _appContext.Matricula
                    .Include(g=>g.Grupo)
                        .ThenInclude(g=>g.Ciclo)
                    .Include(g=>g.Grupo)    
                        .ThenInclude(g=>g.Tutor)
                    .Include(g=>g.Estudiante)
                    .Where(g => g.Grupo.Formador.Id == usuarioId);
            }
            if(usuario.Rol.Nombre =="Tutor")
            {
                //Si el usuario es: Formador
                return _appContext.Matricula
                    .Include(g=>g.Grupo)
                        .ThenInclude(g=>g.Ciclo)
                    .Include(g=>g.Grupo)    
                        .ThenInclude(g=>g.Formador)
                    .Include(g=>g.Estudiante)
                    .Where(g => g.Grupo.Tutor.Id == usuarioId);
            }
            if(usuario.Rol.Nombre == "Estudiante")
            {
                //Si el usuario es: Formador
                return _appContext.Matricula
                    .Include(g=>g.Grupo)
                        .ThenInclude(g=>g.Ciclo)
                    .Include(g=>g.Grupo)    
                        .ThenInclude(g=>g.Formador)
                    .Include(g=>g.Grupo)    
                        .ThenInclude(g=>g.Tutor)    
                    .Include(g=>g.Estudiante)
                    .Where(g => g.Estudiante.Id == usuarioId);
            }
            else
            {
                return _appContext.Matricula
                    .Include(g=>g.Grupo)
                        .ThenInclude(g=>g.Ciclo)
                    .Include(g=>g.Grupo)    
                        .ThenInclude(g=>g.Formador)    
                    .Include(g=>g.Grupo)    
                        .ThenInclude(g=>g.Tutor)
                    .Include(g=>g.Estudiante);
            }        
            
        }
        
        
    }
}
