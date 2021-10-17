using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SGE.App.Frontend.Pages
{
    public class CambioContrasenaModel : PageModel
    {
        private SGE.App.Persistencia.AppContext _appContext;
        

        [BindProperty]
        public string Usuario {get;set;}

        [BindProperty]
        public string Mail {get;set;}
        
        [BindProperty]
        public string NewPassword{get;set;}

        [BindProperty]
        public string MensajeUsuario{get;set;}
        
        [BindProperty]
        public string MensajeCorreo{get;set;}

        [BindProperty]
        public string MensajeExito{get;set;}

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
             _appContext = new SGE.App.Persistencia.AppContext();

            var p = _appContext.Usuarios.FirstOrDefault( p => p.User == Usuario);
            if(p == null)
            {
                MensajeUsuario = "Usuario no existe.";
                //Console.WriteLine("User error");
            }
            
            else if (!p.Correo.Equals(Mail))
            {
                //Console.WriteLine("Contraseña incorrecta");
                MensajeCorreo = "Correo incorrecto.";
            }
            else
            {
                p.Entro = true;
                p.Contrasena = NewPassword;
                _appContext.SaveChanges();
                MensajeExito = "Su contrasena fue cambiada con exito.";
                return RedirectToPage("../Index");
            }

            return Page();
        }

    }
}
