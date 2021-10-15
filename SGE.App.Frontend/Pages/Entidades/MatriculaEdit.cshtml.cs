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
    public class MatriculaEditModel : PageModel
    {
        private readonly SGE.App.Persistencia.AppContext _appContext;
        private readonly IRepositorioMatricula repositorioMatricula;

        public SelectList listaGrupos {get;set;}

        public SelectList listaEstudiantes {get;set;}

        [BindProperty]
        public int GrupoId {get;set;}

        [BindProperty]
        public int EstudianteId {get;set;}

        [BindProperty]
        public Matricula Matricula {get;set;}

        public MatriculaEditModel(IRepositorioMatricula repositorioMatricula, SGE.App.Persistencia.AppContext appContext)
        {
            this.repositorioMatricula = repositorioMatricula;
            _appContext = appContext;
        }

        public IActionResult OnGet(int? matriculaId)
        {

             var listaGruposDb = _appContext.Grupos;
            listaGrupos = new SelectList(listaGruposDb, nameof(Grupo.Id), nameof(Grupo.Nombre));

             var listaEstudiantesDb = _appContext.Usuarios;
            listaEstudiantes = new SelectList(listaEstudiantesDb, nameof(Usuario.Id), nameof(Usuario.Nombre), nameof(Usuario.Apellidos));

            if(matriculaId.HasValue)
            {
                var matriculaQuery = _appContext.Matricula.Include(m => m.Grupo).Include(m => m.Estudiante).FirstOrDefault(m => m.Id == matriculaId);
                EstudianteId = matriculaQuery.Estudiante.Id;
                GrupoId = matriculaQuery.Grupo.Id;
                Matricula = repositorioMatricula.GetMatricula(matriculaId.Value);
            }

            else
            {
                Matricula = new Matricula();
            }

            if (Matricula == null)
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
            Matricula.Grupo = grupo;

            var listaEstudiantesDb = _appContext.Usuarios;
            listaEstudiantes = new SelectList(listaEstudiantesDb, nameof(Usuario.Id), nameof(Usuario.Nombre), nameof(Usuario.Apellidos));
            Usuario estudiante = _appContext.Usuarios.FirstOrDefault(g => g.Id == EstudianteId);
            Matricula.Estudiante = estudiante;

            if(Matricula.Id > 0)
            {
                Matricula = repositorioMatricula.UpdateMatricula(Matricula);
            }
            else
            {
                Matricula = repositorioMatricula.AddMatricula(Matricula);
            }

            return RedirectToPage("./MatriculaList");

        }

    }
}
