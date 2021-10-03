using System.Collections.Generic;
using SGE.App.Dominio;

namespace SGE.App.Persistencia
{
    public interface IRepositorioRol
    {
        IEnumerable<Rol> GetAllRoles();
        Rol AddRol(Rol rol);
        Rol UpdateRol(Rol rol);
        void DeleteRol(int idRol);
        Rol GetRol(int idRol); 
    }
}
