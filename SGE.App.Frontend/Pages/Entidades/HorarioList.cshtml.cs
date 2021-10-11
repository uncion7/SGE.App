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

    public class HorarioListModel : PageModel
    {
        private readonly IRepositorioHorario repositorioHorario;
        public IEnumerable<Horario> Horarios{get;set;}
        public HorarioListModel(IRepositorioHorario repositorioHorario)
        {
            this.repositorioHorario = repositorioHorario;
        }

        public void OnGet(int? horarioId)
        {
            if(horarioId>0)
            {
                repositorioHorario.DeleteHorario(horarioId.Value);
            }
            Horarios = repositorioHorario.GetAllHorarios();
        }
    }
}
