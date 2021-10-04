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
    public class DeptoDetailModel : PageModel
    {
       private readonly IRepositorioDepartamento repositorioDepartamento;
        public Departamento Departamento {get; set;}

        public DeptoDetailModel(IRepositorioDepartamento repositorioDepartamento)
        {
            this.repositorioDepartamento = repositorioDepartamento;
        }

        public IActionResult OnGet(int departamentoId)
        {
            Departamento = repositorioDepartamento.GetDepartamentoPorId(departamentoId);
            if(Departamento==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
