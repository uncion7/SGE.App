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
    public class DeptoEditModel : PageModel
    {
        private readonly IRepositorioDepartamento repositorioDepartamento;
        [BindProperty]
        public Departamento Departamento {get; set;}

        public DeptoEditModel(IRepositorioDepartamento repositorioDepartamento)
        {
            this.repositorioDepartamento = repositorioDepartamento;
        }

        public IActionResult OnGet(int? departamentoId)
        {
            if(departamentoId.HasValue)
            {
                Departamento = repositorioDepartamento.GetDepartamentoPorId(departamentoId.Value);
            }
            else
            {
                Departamento = new Departamento();
            }
            
            if(Departamento==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return RedirectToPage("./DepartamentoList");
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Departamento.Id > 0)
            {
                Departamento = repositorioDepartamento.UpdateDepartamento(Departamento);
            }
            else
            {
                Departamento = repositorioDepartamento.AddDepartamento(Departamento);
            }
            return Page();
        }
    }
}
