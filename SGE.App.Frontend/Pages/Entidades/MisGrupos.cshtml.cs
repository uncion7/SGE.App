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
    public class MisGruposModel : PageModel
    {
        private readonly IRepositorioMatricula repositorioMatricula;
        public IEnumerable<Matricula> MisGrupos{get;set;}
        public MisGruposModel(IRepositorioMatricula repositorioMatricula)
        {
            this.repositorioMatricula = repositorioMatricula;
        }
        public void OnGet(int usuarioId)
        {
            MisGrupos = repositorioMatricula.GetAllMisGrupos(usuarioId);
        }
    }
}
