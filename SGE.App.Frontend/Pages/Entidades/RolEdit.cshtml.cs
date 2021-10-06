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
    public class RolEditModel : PageModel
    {
        private readonly IRepositorioRol repositorioRol;

        [BindProperty]
        public Rol Rol {get; set;}

        public RolEditModel(IRepositorioRol repositorioRol)
        {
            this.repositorioRol = repositorioRol;
        }

        public IActionResult OnGet(int? rolId)
        {
            if(rolId.HasValue)
            {
                Rol = repositorioRol.GetRol(rolId.Value);
            }
            else
            {
                Rol = new Rol();
            }
            
            if(Rol==null)
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

            if(Rol.Id > 0)
            {
                Rol = repositorioRol.UpdateRol(Rol);
            }
            else
            {
                Rol = repositorioRol.AddRol(Rol);
            }
            return RedirectToPage("./RolList");
        }
    }
}
