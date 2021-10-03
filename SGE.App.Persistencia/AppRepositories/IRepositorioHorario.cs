using System.Collections.Generic;
using SGE.App.Dominio;

namespace SGE.App.Persistencia
{
    public interface IRepositorioHorario
    {
        IEnumerable<Horario> GetAllHorarios();
        Horario AddHorario(Horario horario);
        Horario UpdateHorario(Horario horario);
        void DeleteHorario(int idHorario);
        Horario GetHorario(int idHorario); 
    }
}
