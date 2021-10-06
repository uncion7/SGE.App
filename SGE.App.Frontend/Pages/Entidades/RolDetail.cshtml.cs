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
    public class RolDetailModel : PageModel
    {
        private readonly IRepositorioRol repositorioRol;
        public Rol Rol {get; set;}

        public RolDetailModel(IRepositorioRol repositorioRol)
        {
            this.repositorioRol = repositorioRol;
        }

        public IActionResult OnGet(int rolId)
        {
            Rol = repositorioRol.GetRol(rolId);
            if(Rol==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
