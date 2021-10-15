using System.Collections.Generic;
using System.Linq;
using SGE.App.Dominio;

namespace SGE.App.Persistencia
{
    public class RepositorioGrupo:IRepositorioGrupo
    {
        
        ///<sumary>
        ///Referencia al contexto
        ///</sumary>
        
        private readonly AppContext _appContext;
        
        ///<sumary>
        ///Metodo constructor utiliza
        ///Inyeccion de dependencias para garantizar el contexto
        ///</sumary>
        ///<param name="appContext"></param>//

        public RepositorioGrupo(AppContext appContext)
        {
            _appContext = appContext;
        }

        Grupo IRepositorioGrupo.AddGrupo(Grupo grupo)
        {
            var grupoAdicionado =_appContext.Grupos.Add(grupo);
            _appContext.SaveChanges();
            return grupoAdicionado.Entity;
        }

        void IRepositorioGrupo.DeleteGrupo(int idGrupo)
        {
            var grupoEncontrado = _appContext.Grupos.FirstOrDefault(m => m.Id==idGrupo);
            if(grupoEncontrado==null)
                return;
            _appContext.Grupos.Remove(grupoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Grupo> IRepositorioGrupo.GetAllGrupos()
        {
            return _appContext.Grupos;
        }

        Grupo IRepositorioGrupo.GetGrupo(int idGrupo)
        {
            return _appContext.Grupos.FirstOrDefault(m => m.Id==idGrupo);
        }

        Grupo IRepositorioGrupo.UpdateGrupo(Grupo grupo)
        {
            var grupoEncontrado =_appContext.Grupos.FirstOrDefault(m => m.Id==grupo.Id);
            if(grupoEncontrado!=null)
            {
                grupoEncontrado.Nombre = grupo.Nombre;
                grupoEncontrado.Codigo = grupo.Codigo;
                grupoEncontrado.Ciclo = grupo.Ciclo;
                grupoEncontrado.Formador = grupo.Formador;
                grupoEncontrado.Tutor = grupo.Tutor;
                _appContext.SaveChanges();
            }
            return grupoEncontrado;
        }
        
    }
}
