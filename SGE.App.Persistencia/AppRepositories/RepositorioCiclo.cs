using System.Collections.Generic;
using System.Linq;
using SGE.App.Dominio;

namespace SGE.App.Persistencia
{
    public class RepositorioCiclo:IRepositorioCiclo
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

        public RepositorioCiclo(AppContext appContext)
        {
            _appContext = appContext;
        }

        Ciclo IRepositorioCiclo.AddCiclo(Ciclo ciclo)
        {
            var cicloAdicionado =_appContext.Ciclos.Add(ciclo);
            _appContext.SaveChanges();
            return cicloAdicionado.Entity;
        }

        void IRepositorioCiclo.DeleteCiclo(int idCiclo)
        {
            var cicloEncontrado = _appContext.Ciclos.FirstOrDefault(m => m.Id==idCiclo);
            if(cicloEncontrado==null)
                return;
            _appContext.Ciclos.Remove(cicloEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Ciclo> IRepositorioCiclo.GetAllCiclos()
        {
            return _appContext.Ciclos;
        }

        Ciclo IRepositorioCiclo.GetCiclo(int idCiclo)
        {
            return _appContext.Ciclos.FirstOrDefault(m => m.Id==idCiclo);
        }

        Ciclo IRepositorioCiclo.UpdateCiclo(Ciclo ciclo)
        {
            var cicloEncontrado =_appContext.Ciclos.FirstOrDefault(m => m.Id==ciclo.Id);
            if(cicloEncontrado!=null)
            {
                cicloEncontrado.Nombre = ciclo.Nombre;
                cicloEncontrado.Codigo = ciclo.Codigo;
                _appContext.SaveChanges();
            }
            return cicloEncontrado;
        }
        
    }
}
