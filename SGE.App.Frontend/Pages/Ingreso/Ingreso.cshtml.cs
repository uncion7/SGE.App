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
    public class IngresoModel : PageModel
    {
        
        private SGE.App.Persistencia.AppContext _appContext;
        

        [BindProperty]
        public string Usuario {get;set;}
        
        [BindProperty]
        public string Password{get;set;}

        [BindProperty]
        public string MensajeUsuario{get;set;}
        
        [BindProperty]
        public string MensajePassword{get;set;}

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _appContext = new SGE.App.Persistencia.AppContext();

            var p = _appContext.Usuarios.Include(p => p.Rol).FirstOrDefault( p => p.User == Usuario);
            if(p == null)
            {
                MensajeUsuario = "Usuario no existe";
                //Console.WriteLine("User error");
            }
            
            else if (!p.Contrasena.Equals(Password))
            {
                //Console.WriteLine("Contraseña incorrecta");
                MensajePassword = "Contraseña incorrecta";
            }
            else if(p.Entro == false)
            {
                HttpContext.Session.SetString("MiUsuario", Usuario);
                return RedirectToPage("./CambioContrasena");
            }

            else
            {
                HttpContext.Session.SetString("MiNombre", p.Nombre);
                HttpContext.Session.SetString("MiUsuario", Usuario);
                HttpContext.Session.SetString("MiRol", p.Rol.Nombre);
                HttpContext.Session.SetString("MiId", p.Id.ToString());
                return RedirectToPage("../Index");

            }

            return Page();

        }

    }
}