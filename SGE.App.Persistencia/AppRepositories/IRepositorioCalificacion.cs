using System.Collections.Generic;
using SGE.App.Dominio;

namespace SGE.App.Persistencia
{
    public interface IRepositorioCalificacion
    {
        IEnumerable<Calificacion> GetAllCalificaciones();
        Calificacion AddCalificacion(Calificacion calificacion);
        Calificacion UpdateCalificacion(Calificacion calificacion);
        void DeleteCalificacion(int idCalificacion);
        Calificacion GetCalificacion(int idCalificacion); 
    }
}
