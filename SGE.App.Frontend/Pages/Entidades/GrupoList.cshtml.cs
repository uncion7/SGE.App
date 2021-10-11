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
    public class GrupoListModel : PageModel
    {
        
        //Declara la variable de la interfase
        private readonly IRepositorioGrupo repositorioGrupo;
        public IEnumerable<Grupo> Grupos{get; set;}
        public GrupoListModel(IRepositorioGrupo repositorioGrupo)
        {
            this.repositorioGrupo = repositorioGrupo;
        }
        
        public void OnGet(int? grupoId)
        {
            if(grupoId>0)
            {
                repositorioGrupo.DeleteGrupo(grupoId.Value);
            }
            Grupos = repositorioGrupo.GetAllGrupos();
        }
    }
}
