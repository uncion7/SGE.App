using System.Collections.Generic;
using System.Linq;
using SGE.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace SGE.App.Persistencia
{
    public class RepositorioNota:IRepositorioNota
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

        public RepositorioNota(AppContext appContext)
        {
            _appContext = appContext;
        }

        Nota IRepositorioNota.AddNota(Nota nota)
        {
            var notaAdicionada =_appContext.Notas.Add(nota);
            _appContext.SaveChanges();
            return notaAdicionada.Entity;
        }

        void IRepositorioNota.DeleteNota(int idNota)
        {
            var notaEncontrada = _appContext.Notas.FirstOrDefault(m => m.Id==idNota);
            if(notaEncontrada==null)
                return;
            _appContext.Notas.Remove(notaEncontrada);
            _appContext.SaveChanges();
        }

        IEnumerable<Nota> IRepositorioNota.GetAllNotas()
        {
            return _appContext.Notas.Include(m => m.Estudiante).Include(m => m.Calificacion);
        }

        Nota IRepositorioNota.GetNota(int idNota)
        {
            return _appContext.Notas
                .Include(m=>m.Estudiante)
                .Include(m=>m.Calificacion)
                .FirstOrDefault(m => m.Id==idNota);
        }

        Nota IRepositorioNota.UpdateNota(Nota nota)
        {
            var notaEncontrada =_appContext.Notas.FirstOrDefault(m => m.Id==nota.Id);
            if(notaEncontrada!=null)
            {
                notaEncontrada.Valor = nota.Valor;
                notaEncontrada.Calificacion = nota.Calificacion;
                notaEncontrada.Estudiante = nota.Estudiante;
                _appContext.SaveChanges();
            }
            return notaEncontrada;
        }
        
    }
}
