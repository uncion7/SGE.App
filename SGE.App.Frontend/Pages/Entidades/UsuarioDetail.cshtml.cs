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
    public class UsuarioDetailModel : PageModel
    {
        private readonly IRepositorioUsuario repositorioUsuario;
        public Usuario Usuario {get; set;}

        public UsuarioDetailModel(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }

        public IActionResult OnGet(int usuarioId)
        {
            Usuario = repositorioUsuario.GetUsuario(usuarioId);
            if(Usuario==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
