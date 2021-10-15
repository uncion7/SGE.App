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
    public class CalificacionListModel : PageModel
    {
        private readonly IRepositorioCalificacion repositorioCalificacion;
        public IEnumerable<Calificacion> Calificaciones{get;set;}
        public CalificacionListModel(IRepositorioCalificacion repositorioCalificacion)
        {
            this.repositorioCalificacion = repositorioCalificacion;
        }
        public void OnGet(int? calificacionId)
        {
            if(calificacionId > 0)
            {
                repositorioCalificacion.DeleteCalificacion(calificacionId.Value);
            }
            Calificaciones = repositorioCalificacion.GetAllCalificaciones();
        }
    }
}
