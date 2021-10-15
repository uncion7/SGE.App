using System.Collections.Generic;
using System.Linq;
using SGE.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace SGE.App.Persistencia
{
    public class RepositorioHorario:IRepositorioHorario
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

        public RepositorioHorario(AppContext appContext)
        {
            _appContext = appContext;
        }

        Horario IRepositorioHorario.AddHorario(Horario horario)
        {
            var horarioAdicionado =_appContext.Horarios.Add(horario);
            _appContext.SaveChanges();
            return horarioAdicionado.Entity;
        }

        void IRepositorioHorario.DeleteHorario(int idHorario)
        {
            var horarioEncontrado = _appContext.Horarios.FirstOrDefault(m => m.Id==idHorario);
            if(horarioEncontrado==null)
                return;
            _appContext.Horarios.Remove(horarioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Horario> IRepositorioHorario.GetAllHorarios()
        {
            return _appContext.Horarios.Include(a => a.Grupo);
        }

        Horario IRepositorioHorario.GetHorario(int idHorario)
        {
            return _appContext.Horarios.Include(a => a.Grupo).FirstOrDefault(m => m.Id==idHorario);
        }

        Horario IRepositorioHorario.UpdateHorario(Horario horario)
        {
            var horarioEncontrado =_appContext.Horarios.Include(a => a.Grupo).FirstOrDefault(m => m.Id==horario.Id);
            if(horarioEncontrado!=null)
            {
                horarioEncontrado.Grupo = horario.Grupo;
                horarioEncontrado.DiaSemana = horario.DiaSemana;
                horarioEncontrado.HoraInicial = horario.HoraInicial;
                horarioEncontrado.HoraFinal = horario.HoraFinal;
                _appContext.SaveChanges();
            }
            return horarioEncontrado;
        }
        
    }
}
