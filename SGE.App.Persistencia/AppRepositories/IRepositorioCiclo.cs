using System.Collections.Generic;
using SGE.App.Dominio;

namespace SGE.App.Persistencia
{
    public interface IRepositorioCiclo
    {
        IEnumerable<Ciclo> GetAllCiclos();
        Ciclo AddCiclo(Ciclo ciclo);
        Ciclo UpdateCiclo(Ciclo ciclo);
        void DeleteCiclo(int idCiclo);
        Ciclo GetCiclo(int idCiclo); 
    }
}
