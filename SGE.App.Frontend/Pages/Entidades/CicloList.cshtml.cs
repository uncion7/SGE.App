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
    public class CicloListModel : PageModel
    {
        //Conectar repositorio con frontend
        private readonly IRepositorioCiclo repositorioCiclo;
        //Traer lista de ciclos
        public IEnumerable<Ciclo> Ciclos {get;set;}
        public CicloListModel(IRepositorioCiclo repositorioCiclo)
        {
            this.repositorioCiclo = repositorioCiclo;
        }
        public void OnGet()
        {
            Ciclos = repositorioCiclo.GetAllCiclos();
        }
    }
}
