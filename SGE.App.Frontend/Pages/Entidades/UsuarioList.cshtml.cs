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
    public class UsuarioListModel : PageModel
    {
        
        //Declara la variable de la interfase
        private readonly IRepositorioUsuario repositorioUsuario;
        public IEnumerable<Usuario> Usuarios{get; set;}
        public UsuarioListModel(IRepositorioUsuario repositorioUsuario)
        {
            this.repositorioUsuario = repositorioUsuario;
        }
        
        public void OnGet(int? usuarioId)
        {
            if(usuarioId>0)
            {
                repositorioUsuario.DeleteUsuario(usuarioId.Value);
            }
            Usuarios = repositorioUsuario.GetAllUsuarios();
        }
    }
}
