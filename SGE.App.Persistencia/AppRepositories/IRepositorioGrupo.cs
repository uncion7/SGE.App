using System.Collections.Generic;
using SGE.App.Dominio;

namespace SGE.App.Persistencia
{
    public interface IRepositorioGrupo
    {
        IEnumerable<Grupo> GetAllGrupos();
        Grupo AddGrupo(Grupo grupo);
        Grupo UpdateGrupo(Grupo grupo);
        void DeleteGrupo(int idGrupo);
        Grupo GetGrupo(int idGrupo); 
    }
}
