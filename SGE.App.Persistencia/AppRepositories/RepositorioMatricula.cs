using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            .Include(g=>g.Estudiante);
        }

        Matricula IRepositorioMatricula.GetMatricula(int idMatricula)
        {
            return _appContext.Matricula.Include(g=>g.Grupo).Include(g=>g.Estudiante).FirstOrDefault(m => m.Id==idMatricula);
        }

        Matricula IRepositorioMatricula.UpdateMatricula(Matricula matricula)
        {
            var matriculaEncontrado =_appContext.Matricula.Include(g=>g.Grupo).Include(g=>g.Estudiante).FirstOrDefault(m => m.Id==matricula.Id);
            if(matriculaEncontrado!=null)
            {
                matriculaEncontrado.Grupo = matricula.Grupo;
                matriculaEncontrado.Estudiante = matricula.Estudiante;
                _appContext.SaveChanges();
            }
            return matriculaEncontrado;
        }
        
    }
}
