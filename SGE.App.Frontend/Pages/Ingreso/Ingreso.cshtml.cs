using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGE.App.Persistencia;

namespace SGE.App.Frontend.Pages
{
    public class IngresoModel : PageModel
    {
        private readonly SGE.App.Persistencia.AppContext _appContext;

        [BindProperty]
        public string Usuario {get;set;}
        
        [BindProperty]
        public string Password{get;set;}

        [BindProperty]
        public string Mensaje{get;set;}
        
        public void OnGet()
        {
        }

        public void OnPost()
        {
            var p = _appContext.Usuario.Where( p => p.Usuario == Usuario);
            if(p != null && p.password == Password )
            {
                return RedirectToPage("./Index");
            }
            
            else
            {
                Mensaje = "La contraseña no es valida."
            }

        }

    }
}
