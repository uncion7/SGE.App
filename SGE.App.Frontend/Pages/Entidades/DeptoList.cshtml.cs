using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGE.App.Persistencia;
using SGE.App.Dominio;

namespace SGE.App.Frontend.Pages
{
    public class DeptoListModel : PageModel
    {
        //Declara la variable de la interfase
        private readonly IRepositorioDepartamento repositorioDepartamento;
        public IEnumerable<Departamento> Departamentos{get; set;}
        public DeptoListModel(IRepositorioDepartamento repositorioDepartamento)
        {
            this.repositorioDepartamento = repositorioDepartamento;
        }
        
        public void OnGet(int? departamentoId)
        {
            if(departamentoId>0)
            {
                repositorioDepartamento.DeleteDepartamento(departamentoId.Value);
            }
            Departamentos = repositorioDepartamento.GetAllDepartamentos();
        }
    }
}
