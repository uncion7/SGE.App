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
    public class GrupoEditModel : PageModel
    {
        private readonly SGE.App.Persistencia.AppContext _appContext;
        private readonly IRepositorioGrupo repositorioGrupo;

        public SelectList listaCiclos{get; set;}
        
        [BindProperty]
        public int CicloID {get; set;}

        [BindProperty]
        public Grupo Grupo {get; set;}

        public GrupoEditModel(IRepositorioGrupo repositorioGrupo, SGE.App.Persistencia.AppContext appContext)
        {
            this.repositorioGrupo = repositorioGrupo;
            _appContext = appContext;
        }

        public IActionResult OnGet(int? grupoId)
        {
            var listaCiclosDB = _appContext.Ciclos;
            listaCiclos = new SelectList(listaCiclosDB, nameof(Ciclo.Id), nameof(Ciclo.Nombre)); 

            if(grupoId.HasValue)
            {
                var grupoQuery = _appContext.Grupos.Include(m => m.Ciclo).FirstOrDefault(m => m.Id==grupoId);
                CicloID = grupoQuery.Ciclo.Id;
                Grupo = repositorioGrupo.GetGrupo(grupoId.Value);
            }
            else
            {
                Grupo = new Grupo();
            }
            
            if(Grupo==null)
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
            
            var listaCiclosDB = _appContext.Ciclos;
            listaCiclos = new SelectList(listaCiclosDB, nameof(Ciclo.Id), nameof(Ciclo.Nombre));
            Ciclo ciclo = _appContext.Ciclos.FirstOrDefault(d => d.Id == CicloID);
            Grupo.Ciclo = ciclo; 
            
            if(Grupo.Id > 0)
            {
                Grupo = repositorioGrupo.UpdateGrupo(Grupo);
            }
            else
            {
                Grupo = repositorioGrupo.AddGrupo(Grupo);
            }
            return RedirectToPage("./GrupoList");
        }
    }
}
