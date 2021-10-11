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
    public class HorarioEditModel : PageModel
    {
        private readonly IRepositorioHorario repositorioHorario;
        [BindProperty]
        public Horario Horario {get;set;}
        public HorarioEditModel(IRepositorioHorario repositorioHorario)
        {
            this.repositorioHorario = repositorioHorario;
        }

        public IActionResult OnGet(int? horarioId)
        {
            if(horarioId.HasValue)
            {
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
            if(Horario.Id > 0)
            {
                Horario = repositorioHorario.UpdateHorario(Horario);
            }
            else
            {
                Horario = repositorioHorario.AddHorario(Horario);
            }
            return Page();
        }

    }
}
