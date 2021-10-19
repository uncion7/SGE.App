using System.Collections.Generic;
using SGE.App.Dominio;

namespace SGE.App.Persistencia
{
    public interface IRepositorioMatricula
    {
        IEnumerable<Matricula> GetAllMatriculas();
        Matricula AddMatricula(Matricula matricula);
        Matricula UpdateMatricula(Matricula matricula);
        void DeleteMatricula(int idMatricula);
        Matricula GetMatricula(int idMatricula);
        IEnumerable<Matricula> GetAllMisGrupos();
        
    }
}
