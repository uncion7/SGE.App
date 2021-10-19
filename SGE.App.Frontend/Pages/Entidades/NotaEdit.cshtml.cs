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
        public SelectList listaGrupos{get;set;}

        [BindProperty]
        public int EstudianteId {get;set;}

        [BindProperty]
        public int GrupoId {get;set;}

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
            
            var listaGruposDb = _appContext.Grupos;
            listaGrupos = new SelectList(listaGruposDb, nameof(Grupo.Id), nameof(Grupo.Nombre));

            if(notaId.HasValue)
            {
                var notaQuery = _appContext.Notas
                    .Include(m => m.Estudiante)
                    .Include(m => m.Grupo)
                    .FirstOrDefault(m => m.Id == notaId.Value);
                    
                //Asignar Instancia al Select Estudiante
                EstudianteId = notaQuery.Estudiante.Id;
                // Asignar Instancia al Select Calificaciones
                GrupoId = notaQuery.Grupo.Id;
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
            
            var listaGruposDb = _appContext.Grupos;
            listaGrupos = new SelectList(listaGruposDb, nameof(Grupo.Id),  nameof(Grupo.Nombre));
            Grupo grupo = _appContext.Grupos.FirstOrDefault(m => m.Id == GrupoId);
            Nota.Grupo = grupo;

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
