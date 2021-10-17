using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGE.App.Persistencia;
using SGE.App.Dominio;

namespace SGE.App.Frontend.Pages
{
    public class HorarioEditModel : PageModel
    {
        private readonly SGE.App.Persistencia.AppContext _appContext;
        private readonly IRepositorioHorario repositorioHorario;
        public SelectList listaGrupos{get;set;}
        
        [BindProperty]
        public int GrupoID {get;set;}

        [BindProperty]
        public string DiaID {get; set;}

        [BindProperty]
        public Horario Horario {get;set;}

        [BindProperty]
        public string MsgHorarioLimite {get; set;}

        [BindProperty]
        public string MsgGrupoLimite {get; set;}


        public HorarioEditModel(IRepositorioHorario repositorioHorario, SGE.App.Persistencia.AppContext appContext)
        {
            this.repositorioHorario = repositorioHorario;
            _appContext = appContext;
        }

        public bool validarHorario(TimeSpan hInicial, TimeSpan hFinal)
        {
            //Validar Horario
            TimeSpan t1 = new TimeSpan(2, 0, 0);
            TimeSpan t2 = new TimeSpan(3, 0, 0);
            TimeSpan h1 = hFinal - hInicial;

            if(h1 >= t1 && h1 <= t2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Validar Grupo: 7 horas semanales de Lunes a Sábado
        public bool validarGrupo(Grupo Grupo)
        {
            return true;
        }

        public IActionResult OnGet(int? horarioId)
        {
            var listaGruposDb = _appContext.Grupos;
            listaGrupos = new SelectList(listaGruposDb, nameof(Grupo.Id), nameof(Grupo.Nombre));

            if(horarioId.HasValue)
            {
                var horarioQuery =_appContext.Horarios.Include(m => m.Grupo).FirstOrDefault(m => m.Id == horarioId);
                GrupoID = horarioQuery.Grupo.Id;
                Horario = repositorioHorario.GetHorario(horarioId.Value);
                DiaID = horarioQuery.DiaSemana;
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

            var listaGruposDb = _appContext.Grupos;
            listaGrupos = new SelectList(listaGruposDb, nameof(Grupo.Id), nameof(Grupo.Nombre));
            Grupo grupo = _appContext.Grupos.FirstOrDefault(g => g.Id == GrupoID);
            Horario.Grupo = grupo;
            Horario.DiaSemana = DiaID;

            if(Horario.Id > 0)
            {
                Horario = repositorioHorario.UpdateHorario(Horario);
            }
            else
            {   
                //Validar Horario y Grupo
                var hValido = validarHorario(Horario.HoraInicial, Horario.HoraFinal);
                var gValido = validarGrupo(Horario.Grupo);

                if(hValido == true && gValido == true)
                {
                    Horario = repositorioHorario.AddHorario(Horario);    
                }
                else if(hValido == false && gValido == false)
                {
                    MsgHorarioLimite = "El horario debe ser entre 2 y 3 horas";
                    MsgGrupoLimite = "El Grupo ya tiene 7 horas semanales de Lunes a Sábado";
                    return Page();
                }
                else if(hValido == false && gValido == true)
                {
                    MsgHorarioLimite = "El horario debe ser entre 2 y 3 horas";
                    return Page();
                }
                else if(hValido == true && gValido == false)
                {
                    MsgGrupoLimite = "El Grupo ya tiene 7 horas semanales de Lunes a Sábado";
                    return Page();
                }
                
            }
            return RedirectToPage("./HorarioList");
        }
    }
}
