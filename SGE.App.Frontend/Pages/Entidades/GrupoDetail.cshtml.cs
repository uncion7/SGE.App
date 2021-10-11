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
    public class GrupoDetailModel : PageModel
    {
        private readonly IRepositorioGrupo repositorioGrupo;
        public Grupo Grupo {get; set;}

        public GrupoDetailModel(IRepositorioGrupo repositorioGrupo)
        {
            this.repositorioGrupo = repositorioGrupo;
        }

        public IActionResult OnGet(int grupoId)
        {
            Grupo = repositorioGrupo.GetGrupo(grupoId);
            if(Grupo==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
