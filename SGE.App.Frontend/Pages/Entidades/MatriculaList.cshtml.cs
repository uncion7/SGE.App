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
    public class MatriculaListModel : PageModel
    {
        private readonly IRepositorioMatricula repositorioMatricula;
        public IEnumerable<Matricula> Matriculas{get;set;}
        
        public MatriculaListModel(IRepositorioMatricula repositorioMatricula)
        {
            this.repositorioMatricula = repositorioMatricula;
        }
        public void OnGet(int? matriculaId, int? usuarioId)
        {
            if(matriculaId>0)
            {
                repositorioMatricula.DeleteMatricula(matriculaId.Value);
            }
            //Matriculas = repositorioMatricula.GetAllMatriculas();
            Matriculas = repositorioMatricula.GetAllMisGrupos(usuarioId.Value);
        }
    }
}
