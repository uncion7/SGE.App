using System.Collections.Generic;
using SGE.App.Dominio;

namespace SGE.App.Persistencia
{
    public interface IRepositorioMunicipio
    {
        IEnumerable<Municipio> GetAllMunicipios();
        Municipio AddMunicipio(Municipio municipio);
        Municipio UpdateMunicipio(Municipio municipio);
        void DeleteMunicipio(int idMunicipio);
        Municipio GetMunicipio(int idMunicipio); 
    }
}
