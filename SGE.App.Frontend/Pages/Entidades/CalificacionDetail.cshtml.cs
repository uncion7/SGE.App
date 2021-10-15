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
    public class CalificacionDetailModel : PageModel
    {
        private readonly IRepositorioCalificacion repositorioCalificacion;
        public Calificacion Calificacion{get;set;}
        public CalificacionDetailModel(IRepositorioCalificacion repositorioCalificacion)
        {
            this.repositorioCalificacion = repositorioCalificacion;
        }
        public IActionResult OnGet(int calificacionId)
        {
            Calificacion = repositorioCalificacion.GetCalificacion(calificacionId);
            if(Calificacion == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    
    }   
}
