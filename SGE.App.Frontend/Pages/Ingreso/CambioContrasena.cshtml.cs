using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
=======
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using SGE.App.Persistencia;
using SGE.App.Dominio;


>>>>>>> d132e3cf13758448eb7336aad21feeb1745546cb

namespace SGE.App.Frontend.Pages
{
    public class CambioContrasenaModel : PageModel
    {
        private SGE.App.Persistencia.AppContext _appContext;
        
<<<<<<< HEAD

        [BindProperty]
        public string Usuario {get;set;}

        [BindProperty]
        public string Mail {get;set;}
        
=======
                
>>>>>>> d132e3cf13758448eb7336aad21feeb1745546cb
        [BindProperty]
        public string NewPassword{get;set;}

        [BindProperty]
<<<<<<< HEAD
        public string MensajeUsuario{get;set;}
        
        [BindProperty]
        public string MensajeCorreo{get;set;}

        [BindProperty]
        public string MensajeExito{get;set;}
=======
        public string NewPasswordConfirm {get;set;}

        [BindProperty]
        public string Mensaje{get;set;}
        
>>>>>>> d132e3cf13758448eb7336aad21feeb1745546cb

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
             _appContext = new SGE.App.Persistencia.AppContext();

<<<<<<< HEAD
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
=======
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
>>>>>>> d132e3cf13758448eb7336aad21feeb1745546cb
                return RedirectToPage("../Index");
            }

            return Page();
        }

    }
}
