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
            var listaEstudiantesDb = _appContext.Matricula;
            listaEstudiantes = new SelectList(listaEstudiantesDb, nameof(Matricula.Id), nameof(Matricula.Estudiante));

            //var listaEstudiantesDb = _appContext.Usuarios;
            //listaEstudiantes = new SelectList(listaEstudiantesDb, nameof(Usuario.Id), nameof(Usuario.Cedula));

            var listaCalificacionesDb = _appContext.Calificaciones;
            listaCalificaciones = new SelectList(listaCalificacionesDb, nameof(Calificacion.Id), nameof(Calificacion.Nombre));

            if(notaId.HasValue)
            {
                var notaQuery = _appContext.Notas.Include(m => m.Estudiante).Include(m => m.Calificacion).FirstOrDefault(m => m.Id == notaId);
                EstudianteId = notaQuery.Estudiante.Id;
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

            var listaEstudiantesDb = _appContext.Matricula;
            listaEstudiantes = new SelectList(listaEstudiantesDb, nameof(Matricula.Id), nameof (Matricula.Estudiante.Nombre), nameof(Matricula.Estudiante.Apellidos));
            Matricula estudiante = _appContext.Matricula.FirstOrDefault(m => m.Id == EstudianteId);
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
