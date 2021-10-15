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
    public class MatriculaDetailModel : PageModel
    {
        private readonly IRepositorioMatricula repositorioMatricula;
        public Matricula Matricula {get;set;}
        public MatriculaDetailModel(IRepositorioMatricula repositorioMatricula)
        {
            this.repositorioMatricula = repositorioMatricula;
        }


        public IActionResult OnGet(int matriculaId)
        {
            Matricula = repositorioMatricula.GetMatricula(matriculaId);
            if(Matricula == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();

        }
    }
}
