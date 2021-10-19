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

        /*
        IEnumerable<Horario> IRepositorioHorario.GetAllMisHorarios(int usuarioId)
        {   

            
            //Rol del Usuario
            usuario = _appContext.Usuarios
                .Include(g=>g.Rol)
                .FirstOrDefault(g=>g.Id == usuarioId);

            
            if(usuario.Rol.Nombre == "Formador")
            {
                //Busca los Grupos del Formador
                var misGrupos = _appContext.Grupos
                    .Include(g=>g.Grupo)
                        .ThenInclude(g=>g.Ciclo)
                    .Where(g => g.Grupo.Formador.Id == usuarioId);

                //Busca los Horarios de los Grupos del Formador
                return _appContext.Horarios
                    .Include(g=>g.Grupo)
                        .ThenInclude(g=>g.Ciclo);
                    //.Where(g => g.Grupo.Formador.Id ==  );

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
        */
        
    }
}
