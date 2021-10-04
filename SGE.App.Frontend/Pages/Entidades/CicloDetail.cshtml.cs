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
        //Conectar repositorio con frontend
        private readonly IRepositorioCiclo repositorioCiclo;

        //Modelo de Repositorio
        public Ciclo Ciclo {get;set;}

        //Modelo de Repositorio Ciclo
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
