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
    public class CicloDetailModel : PageModel
    {
        private readonly IRepositorioCiclo repositorioCiclo;
        public Ciclo Ciclo {get;set;}
        public CicloDetailModel(IRepositorioCiclo repositorioCiclo)
        {
            this.repositorioCiclo  = repositorioCiclo;
        }
        public IActionResult OnGet( int cicloId)
        {
            Ciclo = repositorioCiclo.GetCiclo(cicloId);
            if(Ciclo == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
