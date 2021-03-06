using System.Collections.Generic;
using System.Linq;
using SGE.App.Dominio;
using SGE.App.Persistencia;

namespace SGE.App.Persistencia
{
    public class RepositorioDepartamento:IRepositorioDepartamento
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

        public RepositorioDepartamento(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<Departamento> GetAllDepartamentos()
        {
            return _appContext.Departamentos;
        }

        public Departamento AddDepartamento(Departamento departamento)
        {
            var departamentoAdicionado =_appContext.Departamentos.Add(departamento);
            _appContext.SaveChanges();
            return departamentoAdicionado.Entity;
        }

        public Departamento GetDepartamentoPorId(int departamentoId)
        {
            return _appContext.Departamentos.SingleOrDefault(d => d.Id==departamentoId);
        }

        public Departamento UpdateDepartamento(Departamento departamentoActualizado)
        {
            var departamento = _appContext.Departamentos.SingleOrDefault(d => d.Id==departamentoActualizado.Id);
            if(departamento!=null)
            {
                departamento.Id = departamentoActualizado.Id;
                departamento.Nombre = departamentoActualizado.Nombre;

                _appContext.SaveChanges();
            }
            return departamento;
        }

        void IRepositorioDepartamento.DeleteDepartamento(int departamentoId)
        {
            var departamentoEncontrado = _appContext.Departamentos.FirstOrDefault(m => m.Id==departamentoId);
            if(departamentoEncontrado==null)
                return;
            _appContext.Departamentos.Remove(departamentoEncontrado);
            _appContext.SaveChanges();
        }


        /*
        //CRUD PARA APLICACION POR CONSOLA

        Departamento IRepositorioDepartamento.AddDepartamento(Departamento departamento)
        {
            var departamentoAdicionado =_appContext.Departamentos.Add(departamento);
            _appContext.SaveChanges();
            return departamentoAdicionado.Entity;
        }

        void IRepositorioDepartamento.DeleteDepartamento(int idDepartamento)
        {
            var departamentoEncontrado = _appContext.Departamentos.FirstOrDefault(m => m.Id==idDepartamento);
            if(departamentoEncontrado==null)
                return;
            _appContext.Departamentos.Remove(departamentoEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Departamento> IRepositorioDepartamento.GetAllDepartamentos()
        {
            return _appContext.Departamentos;
        }

        Departamento IRepositorioDepartamento.GetDepartamento(int idDepartamento)
        {
            return _appContext.Departamentos.FirstOrDefault(m => m.Id==idDepartamento);
        }

        Departamento IRepositorioDepartamento.UpdateDepartamento(Departamento departamento)
        {
            var departamentoEncontrado =_appContext.Departamentos.FirstOrDefault(m => m.Id==departamento.Id);
            if(departamentoEncontrado!=null)
            {
                departamentoEncontrado.Nombre = departamento.Nombre;
                //departamentoEncontrado.Municipios = departamento.Municipios;

                _appContext.SaveChanges();
            }
            return departamentoEncontrado;
        }
        */
        
    }
}
