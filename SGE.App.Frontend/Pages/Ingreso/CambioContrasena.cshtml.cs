using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using SGE.App.Persistencia;
using SGE.App.Dominio;



namespace SGE.App.Frontend.Pages
{
    public class CambioContrasenaModel : PageModel
    {
        private SGE.App.Persistencia.AppContext _appContext;
        
                
        [BindProperty]
        public string NewPassword{get;set;}

        [BindProperty]
        public string NewPasswordConfirm {get;set;}

        [BindProperty]
        public string Mensaje{get;set;}
        

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
             _appContext = new SGE.App.Persistencia.AppContext();

            var Usuario = HttpContext.Session.GetString("MiUsuario");
            var p = _appContext.Usuarios.Include(p => p.Rol).FirstOrDefault( p => p.User == Usuario);
            if (!NewPassword.Equals(NewPasswordConfirm))
            {
                //Console.WriteLine("Contraseña incorrecta");
                 Mensaje = "Contraseñas no coinciden";
            }
            else
            {
                HttpContext.Session.SetString("MiRol", p.Rol.Nombre);
                p.Entro = true;
                p.Contrasena = NewPassword;
                _appContext.SaveChanges();
                return RedirectToPage("../Index");
            }

            return Page();
        }

    }
}
