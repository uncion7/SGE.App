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
    public class MunicipioEditModel : PageModel
    {
        private readonly IRepositorioMunicipio repositorioMunicipio;
        [BindProperty]
        public Municipio Municipio {get; set;}

        public MunicipioEditModel(IRepositorioMunicipio repositorioMunicipio)
        {
            this.repositorioMunicipio = repositorioMunicipio;
        }

        public IActionResult OnGet(int? municipioId)
        {
            if(municipioId.HasValue)
            {
                Municipio = repositorioMunicipio.GetMunicipio(municipioId.Value);
            }
            else
            {
                Municipio = new Municipio();
            }
            
            if(Municipio==null)
            {
                return RedirectToPage("./NotFound");
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
            if(Municipio.Id > 0)
            {
                Municipio = repositorioMunicipio.UpdateMunicipio(Municipio);
            }
            else
            {
                Municipio = repositorioMunicipio.AddMunicipio(Municipio);
            }
            return Page();
        }
    }
}
