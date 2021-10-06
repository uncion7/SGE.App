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
    public class MunicipioDetailModel : PageModel
    {
        private readonly IRepositorioMunicipio repositorioMunicipio;
        public Municipio Municipio {get; set;}

        public MunicipioDetailModel(IRepositorioMunicipio repositorioMunicipio)
        {
            this.repositorioMunicipio = repositorioMunicipio;
        }

        public IActionResult OnGet(int municipioId)
        {
            Municipio = repositorioMunicipio.GetMunicipio(municipioId);
            if(Municipio==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
    
}
