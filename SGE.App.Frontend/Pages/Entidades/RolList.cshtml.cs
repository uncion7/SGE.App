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
    public class RolListModel : PageModel
    {
        
        //Declara la variable de la interfase
        private readonly IRepositorioRol repositorioRol;
        public IEnumerable<Rol> Roles{get; set;}
        public RolListModel(IRepositorioRol repositorioRol)
        {
            this.repositorioRol = repositorioRol;
        }
        
        public void OnGet(int? rolId)
        {
            if(rolId>0)
            {
                repositorioRol.DeleteRol(rolId.Value);
            }
            Roles = repositorioRol.GetAllRoles();
        }
    }
}
