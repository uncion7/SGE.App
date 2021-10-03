using System.Collections.Generic;
using System.Linq;
using SGE.App.Dominio;

namespace SGE.App.Persistencia
{
    public class RepositorioRol:IRepositorioRol
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

        public RepositorioRol(AppContext appContext)
        {
            _appContext = appContext;
        }

        Rol IRepositorioRol.AddRol(Rol rol)
        {
            var rolAdicionado =_appContext.Roles.Add(rol);
            _appContext.SaveChanges();
            return rolAdicionado.Entity;
        }

        void IRepositorioRol.DeleteRol(int idRol)
        {
            var rolEncontrado = _appContext.Roles.FirstOrDefault(m => m.Id==idRol);
            if(rolEncontrado==null)
                return;
            _appContext.Roles.Remove(rolEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Rol> IRepositorioRol.GetAllRoles()
        {
            return _appContext.Roles;
        }

        Rol IRepositorioRol.GetRol(int idRol)
        {
            return _appContext.Roles.FirstOrDefault(m => m.Id==idRol);
        }

        Rol IRepositorioRol.UpdateRol(Rol rol)
        {
            var rolEncontrado =_appContext.Roles.FirstOrDefault(m => m.Id==rol.Id);
            if(rolEncontrado!=null)
            {
                rolEncontrado.Nombre = rol.Nombre;
                rolEncontrado.Codigo = rol.Codigo;
                _appContext.SaveChanges();
            }
            return rolEncontrado;
        }
        
    }
}
