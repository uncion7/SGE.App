using System.Collections.Generic;
using System.Linq;
using SGE.App.Dominio;

namespace SGE.App.Persistencia
{
    public class RepositorioCalificacion:IRepositorioCalificacion
    {
        
        ///<sumary>
        ///Referencia al contexto del Municipio
        ///</sumary>
        
        private readonly AppContext _appContext;
        
        ///<sumary>
        ///Metodo constructor utiliza
        ///Inyeccion de dependencias para garantizar el contexto
        ///</sumary>
        ///<param name="appContext"></param>//

        public RepositorioCalificacion(AppContext appContext)
        {
            _appContext = appContext;
        }

        Calificacion IRepositorioCalificacion.AddCalificacion(Calificacion calificacion)
        {
            var calificacionAdicionada =_appContext.Calificaciones.Add(calificacion);
            _appContext.SaveChanges();
            return calificacionAdicionada.Entity;
        }

        void IRepositorioCalificacion.DeleteCalificacion(int idCalificacion)
        {
            var calificacionEncontrada = _appContext.Calificaciones.FirstOrDefault(m => m.Id==idCalificacion);
            if(calificacionEncontrada==null)
                return;
            _appContext.Calificaciones.Remove(calificacionEncontrada);
            _appContext.SaveChanges();
        }

        IEnumerable<Calificacion> IRepositorioCalificacion.GetAllCalificaciones()
        {
            return _appContext.Calificaciones;
        }

        Calificacion IRepositorioCalificacion.GetCalificacion(int idCalificacion)
        {
            return _appContext.Calificaciones.FirstOrDefault(m => m.Id==idCalificacion);
        }

        Calificacion IRepositorioCalificacion.UpdateCalificacion(Calificacion calificacion)
        {
            var calificacionEncontrada =_appContext.Calificaciones.FirstOrDefault(m => m.Id==calificacion.Id);
            if(calificacionEncontrada!=null)
            {
                calificacionEncontrada.Nombre = calificacion.Nombre;
                calificacionEncontrada.VrPonderado = calificacion.VrPonderado;
                calificacionEncontrada.Grupo = calificacion.Grupo;
                _appContext.SaveChanges();
            }
            return calificacionEncontrada;
        }
        
    }
}
