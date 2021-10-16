using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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

        public string miCodigoGrupo(int valor)
        {
            var b = valor.ToString().Length;
            string ceros;
            if(b == 1)
            {
                ceros = "00";
            }
            else if(b == 2)
            {
                ceros = "0";
            }
            else
            {
                ceros = "";
            }
            var res = "G-" + ceros + valor;
            return res;
        }

        Grupo IRepositorioGrupo.AddGrupo(Grupo grupo)
        {
            var grupoAdicionado =_appContext.Grupos.Add(grupo);
            _appContext.SaveChanges();
            var miCodeG = miCodigoGrupo(grupoAdicionado.Entity.Id);
            grupoAdicionado.Entity.Codigo = miCodeG;
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
            return _appContext.Grupos
                .Include(m => m.Ciclo)
                .Include(m => m.Formador)
                .Include(m => m.Tutor);
        }

        Grupo IRepositorioGrupo.GetGrupo(int idGrupo)
        {
            return _appContext.Grupos
                .Include(m => m.Ciclo)
                .Include(m => m.Formador)
                .Include(m => m.Tutor)
                .FirstOrDefault(m => m.Id==idGrupo);
        }

        Grupo IRepositorioGrupo.UpdateGrupo(Grupo grupo)
        {
            var grupoEncontrado =_appContext.Grupos
                .Include(m => m.Ciclo)
                .Include(m => m.Formador)
                .Include(m => m.Tutor)
                .FirstOrDefault(m => m.Id==grupo.Id);
            
            if(grupoEncontrado!=null)
            {
                grupoEncontrado.Nombre = grupo.Nombre;
                grupoEncontrado.Ciclo = grupo.Ciclo;
                grupoEncontrado.Formador = grupo.Formador;
                grupoEncontrado.Tutor = grupo.Tutor;
                _appContext.SaveChanges();
            }
            return grupoEncontrado;
        }
        
    }
}
