using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SGE.App.Dominio;

namespace SGE.App.Persistencia
{
    public class RepositorioMunicipio:IRepositorioMunicipio
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

        public RepositorioMunicipio(AppContext appContext)
        {
            _appContext = appContext;
        }

        Municipio IRepositorioMunicipio.AddMunicipio(Municipio municipio)
        {
            var municipioAdicionado =_appContext.Municipios.Add(municipio);
            _appContext.SaveChanges();
            return municipioAdicionado.Entity;
        }

        void IRepositorioMunicipio.DeleteMunicipio(int idMunicipio)
        {
            var municipioEncontrado = _appContext.Municipios.FirstOrDefault(m => m.Id==idMunicipio);
            if(municipioEncontrado==null)
                return;
            _appContext.Municipios.Remove(municipioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Municipio> IRepositorioMunicipio.GetAllMunicipios()
        {
            return _appContext.Municipios.Include(g=>g.Departamento);
        }

        Municipio IRepositorioMunicipio.GetMunicipio(int idMunicipio)
        {
            return _appContext.Municipios.Include(m => m.Departamento).FirstOrDefault(m => m.Id==idMunicipio);
        }

        Municipio IRepositorioMunicipio.UpdateMunicipio(Municipio municipio)
        {
            var municipioEncontrado =_appContext.Municipios.Include(m => m.Departamento).FirstOrDefault(m => m.Id==municipio.Id);
            if(municipioEncontrado!=null)
            {
                municipioEncontrado.Nombre = municipio.Nombre;
                municipioEncontrado.Departamento = municipio.Departamento;
                _appContext.SaveChanges();
            }
            return municipioEncontrado;
        }
        
    }
}
