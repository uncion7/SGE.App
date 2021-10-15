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
    public class HorarioEditModel : PageModel
    {
        private readonly SGE.App.Persistencia.AppContext _appContext;
        private readonly IRepositorioHorario repositorioHorario;
        public SelectList listaGrupos{get;set;}
        
        [BindProperty]
        public int GrupoID {get;set;}

        [BindProperty]
        public Horario Horario {get;set;}
        public HorarioEditModel(IRepositorioHorario repositorioHorario, SGE.App.Persistencia.AppContext appContext)
        {
            this.repositorioHorario = repositorioHorario;
            _appContext = appContext;
        }

        public IActionResult OnGet(int? horarioId)
        {
            var listaGruposDb = _appContext.Grupos;
            listaGrupos = new SelectList(listaGruposDb, nameof(Grupo.Id), nameof(Grupo.Nombre));

            if(horarioId.HasValue)
            {
                var horarioQuery =_appContext.Horarios.Include(m => m.Grupo).FirstOrDefault(m => m.Id == horarioId);
                GrupoID = horarioQuery.Grupo.Id;
                Horario = repositorioHorario.GetHorario(horarioId.Value);
            }
            else
            {
                Horario = new Horario();
            }

            if(Horario == null)
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
            Grupo grupo = _appContext.Grupos.FirstOrDefault(g => g.Id == GrupoID);
            Horario.Grupo = grupo;

            if(Horario.Id > 0)
            {
                Horario = repositorioHorario.UpdateHorario(Horario);
            }
            else
            {
                Horario = repositorioHorario.AddHorario(Horario);
            }
            return RedirectToPage("./HorarioList");
        }
    }
}
