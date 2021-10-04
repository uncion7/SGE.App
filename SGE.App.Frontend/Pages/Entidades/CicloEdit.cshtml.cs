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
    public class CicloEditModel : PageModel
    {
        //Conectar repositorio con frontend
        private readonly IRepositorioCiclo repositorioCiclo;
        [BindProperty]
        
        //Atributo de Clase Ciclo
        public Ciclo Ciclo {get;set;}

        //Modelo de Repositorio Ciclo
        public CicloEditModel(IRepositorioCiclo repositorioCiclo)
        {
            this.repositorioCiclo = repositorioCiclo;
        }

        public IActionResult OnGet(int? cicloId)
        {
            if(cicloId.HasValue)
            {
                Ciclo = repositorioCiclo.GetCiclo(cicloId.Value);
            }
            
            else
            {
                Ciclo = new Ciclo();
            }
            if(Ciclo==null)
            {
                return RedirectToPage("./NotFoud");
            }

            else
            return Page();
        }
    
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            
            if(Ciclo.Id > 0)
            {
                Ciclo = repositorioCiclo.UpdateCiclo(Ciclo);
            }

            else
            {
                Ciclo = repositorioCiclo.AddCiclo(Ciclo);
            }
            return Page();
        }

    }
}
