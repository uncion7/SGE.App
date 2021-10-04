using System.Collections.Generic;
using SGE.App.Dominio;

namespace SGE.App.Persistencia
{
    public interface IRepositorioDepartamento
    {
        IEnumerable<Departamento> GetAllDepartamentos();
        Departamento GetDepartamentoPorId(int departamentoId);
        Departamento UpdateDepartamento(Departamento departamentoActualizado);
        Departamento AddDepartamento(Departamento departamento);
        //Departamento UpdateDepartamento(Departamento departamento);
        //void DeleteDepartamento(int idDepartamento);
        //Departamento GetDepartamento(int idDepartamento); 
    }
}
