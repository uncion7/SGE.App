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
    public class HorarioDetailModel : PageModel
    {
        private readonly IRepositorioHorario repositorioHorario;
        public Horario Horario{get;set;}
        public HorarioDetailModel(IRepositorioHorario repositorioHorario)
        {
            this.repositorioHorario = repositorioHorario;
        }
        public IActionResult OnGet(int horarioId)
        {
            Horario = repositorioHorario.GetHorario(horarioId);
            if(Horario==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
