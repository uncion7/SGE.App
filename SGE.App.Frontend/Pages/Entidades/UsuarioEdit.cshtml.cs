using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGE.App.Persistencia;
using SGE.App.Dominio;

namespace SGE.App.Frontend.Pages
{
    public class UsuarioEditModel : PageModel
    {
        private readonly SGE.App.Persistencia.AppContext _appContext;
        private readonly IRepositorioUsuario repositorioUsuario;

        public SelectList listaMunicipios {get; set;}
        public SelectList listaRoles {get; set;}
        
        [BindProperty]
        public int MunicipioID {get; set;}

        [BindProperty]
        public int RolID {get; set;}

        [BindProperty]
        public Usuario Usuario {get; set;}
        
        public UsuarioEditModel(IRepositorioUsuario repositorioUsuario, SGE.App.Persistencia.AppContext appContext)
        {
            this.repositorioUsuario = repositorioUsuario;
            _appContext = appContext;
        }

        public IActionResult OnGet(int? usuarioId)
        {
            var listaMunicipiosDB = _appContext.Municipios;
            listaMunicipios = new SelectList(listaMunicipiosDB, nameof(Municipio.Id), nameof(Municipio.Nombre));
            
            var listaRolesDB = _appContext.Roles;
            listaRoles = new SelectList(listaRolesDB, nameof(Rol.Id), nameof(Rol.Nombre)); 

            if(usuarioId.HasValue)
            {
                var rolQuery = _appContext.Usuarios.Include(m => m.Municipio).Include(m => m.Rol).FirstOrDefault(m => m.Id==usuarioId);
                MunicipioID = rolQuery.Municipio.Id;
                RolID = rolQuery.Rol.Id;
                Usuario = repositorioUsuario.GetUsuario(usuarioId.Value);
            }
            else
            {
                Usuario = new Usuario();
            }
            
            if(Usuario==null)
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
            
            var listaMunicipiosDB = _appContext.Municipios;
            listaMunicipios = new SelectList(listaMunicipiosDB, nameof(Municipio.Id), nameof(Municipio.Nombre));
            Municipio municipioQuery = _appContext.Municipios.FirstOrDefault(d => d.Id == MunicipioID);
            Usuario.Municipio = municipioQuery;

            var listaRolesDB = _appContext.Roles;
            listaRoles = new SelectList(listaRolesDB, nameof(Rol.Id), nameof(Rol.Nombre));
            Rol rolQuery = _appContext.Roles.FirstOrDefault(d => d.Id == RolID);
            Usuario.Rol = rolQuery; 
            
            //Asignar la Contraseña inicial al Usuario
            Usuario.Contrasena = Usuario.Cedula;

            if(Usuario.Id > 0)
            {
                Usuario = repositorioUsuario.UpdateUsuario(Usuario);
            }
            else
            {
                Usuario = repositorioUsuario.AddUsuario(Usuario);
            }
            return RedirectToPage("./UsuarioList");
        }
    }
}
