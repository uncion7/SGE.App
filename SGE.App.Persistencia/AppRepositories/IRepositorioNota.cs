using System.Collections.Generic;
using SGE.App.Dominio;

namespace SGE.App.Persistencia
{
    public interface IRepositorioNota
    {
        IEnumerable<Nota> GetAllNotas();
        Nota AddNota(Nota nota);
        Nota UpdateNota(Nota nota);
        void DeleteNota(int idNota);
        Nota GetNota(int idNota); 
    }
}
