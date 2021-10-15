using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SGE.App.Persistencia;
using SGE.App.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SGE.App.Frontend.Pages
{
    public class CalificacionEditModel : PageModel
    {
        private readonly SGE.App.Persistencia.AppContext _appContext;
        private readonly IRepositorioCalificacion repositorioCalificacion;
        public SelectList listaGrupos {get; set;}

        [BindProperty]
        public int GrupoId {get; set;}

        [BindProperty]
        public Calificacion Calificacion {get;set;}
        
        public CalificacionEditModel(IRepositorioCalificacion repositorioCalificacion, SGE.App.Persistencia.AppContext appContext)
        {
            this.repositorioCalificacion = repositorioCalificacion;
            _appContext = appContext;
        }

        public IActionResult OnGet(int? calificacionId)
        {
            var listaGruposDb = _appContext.Grupos;
            listaGrupos = new SelectList(listaGruposDb, nameof(Grupo.Id), nameof(Grupo.Nombre));
            
            if(calificacionId.HasValue)
            {
                var grupoQuery = _appContext.Calificaciones.Include(g => g.Grupo).FirstOrDefault(g => g.Id==calificacionId);
                GrupoId = grupoQuery.Grupo.Id;
                Calificacion = repositorioCalificacion.GetCalificacion(calificacionId.Value);
            }
            else
            {
                Calificacion = new Calificacion();
            }
            if(Calificacion == null)
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
            
            var listaGruposDb = _appContext.Grupos;
            listaGrupos = new SelectList(listaGruposDb, nameof(Grupo.Id), nameof(Grupo.Nombre));
            Grupo grupo = _appContext.Grupos.FirstOrDefault(g => g.Id == GrupoId);
            Calificacion.Grupo = grupo;

            if(Calificacion.Id > 0)
            {
                Calificacion = repositorioCalificacion.UpdateCalificacion(Calificacion);
            }
            else
            {
                Calificacion = repositorioCalificacion.AddCalificacion(Calificacion);
            }
            return RedirectToPage("./CalificacionList");
        }

    }
}
