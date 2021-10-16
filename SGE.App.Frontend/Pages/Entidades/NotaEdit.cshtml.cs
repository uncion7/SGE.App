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
    public class NotaEditModel : PageModel
    {
        private readonly SGE.App.Persistencia.AppContext _appContext;
        private readonly IRepositorioNota repositorioNota;

        public IEnumerable<Nota> listaEstudiantes2 {get; set;}
        public SelectList listaEstudiantes{get;set;}
        public SelectList listaCalificaciones{get;set;}

        [BindProperty]
        public int EstudianteId {get;set;}

        [BindProperty]
        public int CalificacionId {get;set;}

        [BindProperty]
        public Nota Nota {get;set;}

        public NotaEditModel(IRepositorioNota repositorioNota, SGE.App.Persistencia.AppContext appContext)
        {
            this.repositorioNota =repositorioNota;
            _appContext = appContext;
        }

        public IActionResult OnGet(int? notaId)
        {

            //listaEstudiantes2 = _appContext.Notas;
            
            /*
            var listaEstudiantesDb = _appContext.Notas
                .Include(p => p.Estudiante)
                .ThenInclude(e => e.Estudiante);
            
            listaEstudiantes = new SelectList(listaEstudiantesDb, nameof(Nota.Id), nameof(Nota.Estudiante.Estudiante));
            */

            var listaEstudiantesDb = _appContext.Usuarios.Where(p => p.Rol.Nombre=="Estudiante");
            listaEstudiantes = new SelectList(listaEstudiantesDb, nameof(Usuario.Id), nameof(Usuario.Nombre));
            
            var listaCalificacionesDb = _appContext.Calificaciones;
            listaCalificaciones = new SelectList(listaCalificacionesDb, nameof(Calificacion.Id), nameof(Calificacion.Nombre));

            if(notaId.HasValue)
            {
                var notaQuery = _appContext.Notas
                    .Include(m => m.Estudiante)
                    .Include(m => m.Calificacion)
                    .FirstOrDefault(m => m.Id == notaId.Value);
                    
                //Asignar Instancia al Select Estudiante
                EstudianteId = notaQuery.Estudiante.Id;
                // Asignar Instancia al Select Calificaciones
                CalificacionId = notaQuery.Calificacion.Id;
                Nota = repositorioNota.GetNota(notaId.Value);
            }

            else
            {
                Nota = new Nota();
            }

            if(Nota == null)
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

            var listaEstudiantesDb = _appContext.Usuarios.Where(p => p.Rol.Nombre=="Estudiante");
            listaEstudiantes = new SelectList(listaEstudiantesDb, nameof(Usuario.Id), nameof (Usuario.Nombre));
            Usuario estudiante =  _appContext.Usuarios.FirstOrDefault(m => m.Id == EstudianteId);
            Nota.Estudiante = estudiante;
            
            var listaCalificacionesDb = _appContext.Calificaciones;
            listaCalificaciones = new SelectList(listaCalificacionesDb, nameof(Calificacion.Id),  nameof(Calificacion.Nombre), nameof(Calificacion.VrPonderado), nameof(Calificacion.Grupo));
            Calificacion calificacion = _appContext.Calificaciones.FirstOrDefault(m => m.Id == CalificacionId);
            Nota.Calificacion = calificacion;

            if(Nota.Id > 0)
            {
                Nota = repositorioNota.UpdateNota(Nota);
            }
            else
            {
                Nota = repositorioNota.AddNota(Nota);
            }
            return RedirectToPage("./NotaList");

        }
    }
}
