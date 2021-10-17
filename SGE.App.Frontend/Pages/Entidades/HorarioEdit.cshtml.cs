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

        public Usuario Formador {get; set;}
        
        [BindProperty]
        public string MsgIntervalo {get; set;}

        [BindProperty]
        public string MsgIntensidad {get; set;}

        [BindProperty]
        public string MsgDia {get; set;}

        [BindProperty]
        public string MsgFormador {get; set;}

        public HorarioEditModel(IRepositorioHorario repositorioHorario, SGE.App.Persistencia.AppContext appContext)
        {
            this.repositorioHorario = repositorioHorario;
            _appContext = appContext;
        }

        public bool validarIntervalo(Horario Horario)
        {
            bool intervaloValido;
            //Validar Horario
            TimeSpan t1 = new TimeSpan(2, 0, 0);
            TimeSpan t2 = new TimeSpan(3, 0, 0);
            TimeSpan h1 = Horario.HoraFinal - Horario.HoraInicial;

            if(h1 >= t1 && h1 <= t2)
            {
                intervaloValido = true;
            }
            else
            {
                intervaloValido = false;
            }
            return intervaloValido;
        }

        //Validar Grupo: 7 horas semanales de Lunes a Sábado.
        public bool validarIntensidad(Horario Horario)
        {
            //Intensidad Horaria: 7 horas semanales
            bool intensidadValida;
            var intensidadSemanalQuery = _appContext.Horarios.Where(p => p.Grupo == Horario.Grupo);
            TimeSpan intensidadLimite = new TimeSpan(7,0,0);
            TimeSpan intensidadSemanal = new TimeSpan(0,0,0);
            TimeSpan intensidadNueva = Horario.HoraFinal - Horario.HoraInicial;
            foreach (var item in intensidadSemanalQuery)
            {
                var intensidadDia = item.HoraFinal - item.HoraInicial;
                intensidadSemanal = intensidadSemanal + intensidadDia; 
            }
            var intensidadTotal = intensidadSemanal + intensidadNueva;
            
            //Validacion intensidad horaria
            if(intensidadTotal <= intensidadLimite)
            {
                intensidadValida = true;
            }
            else
            {
                intensidadValida = false;
            }
            return intensidadValida;
        }

        //El Grupo no se repite el mismo día
        public bool validarDia(Horario Horario)
        {
            //Grupo no repetido el mismo día
            bool diaValido;
            var diaNoExisteQuery = _appContext.Horarios
                .Where(p => p.Grupo == Horario.Grupo)
                .Where(p => p.DiaSemana == Horario.DiaSemana)
                .Count();
            
            if(diaNoExisteQuery == 0)
            {
                diaValido = true;
            }
            else
            {
                diaValido = false;
            }
            return diaValido;
        }

        public bool validarHorarioFormador(Horario Horario, Usuario Formador)
        {
            bool hfValido;

            var hfQuery = _appContext.Horarios
                .Include(p => p.Grupo)
                .ThenInclude(p => p.Formador)
                .Where(p => p.Grupo.Formador == Formador)
                .Where(p => p.DiaSemana == Horario.DiaSemana)
                .Where(p => p.HoraInicial == Horario.HoraInicial)
                .Where(p => p.HoraFinal == Horario.HoraFinal)
                .Count();
            
            if(hfQuery == 0)
            {
                hfValido = true;
            }
            else
            {
                hfValido = false;
            }
            return hfValido;
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
            Grupo grupo = _appContext.Grupos
                .Include(g => g.Formador)
                .FirstOrDefault(g => g.Id == GrupoID);
            Horario.Grupo = grupo;
            Horario.DiaSemana = DiaID;

            if(Horario.Id > 0)
            {
                Horario = repositorioHorario.UpdateHorario(Horario);
            }
            else
            {   
                //Validar Horario y Grupo
                var intervaloOk = validarIntervalo(Horario);
                var intensidadOk = validarIntensidad(Horario);
                var diaOk = validarDia(Horario);
                var formadorOk = validarHorarioFormador(Horario, grupo.Formador);
                string mensajeIntervalo = "El horario debe ser entre 2 y 3 horas";
                string mensajeIntensidad = "El Grupo sobrepasa la intensidad horaria de 7 semanales de Lunes a Sabado";
                string mensajeDia = "El Grupo ya tiene asignado este dia de la semana"; 
                string mensajeFormador = "El Formador ya tiene este horario ocupado";

                if(intervaloOk == true && intensidadOk == true && diaOk == true && formadorOk == true)
                {
                    Horario = repositorioHorario.AddHorario(Horario);    
                }
                else
                {
                    if(intervaloOk == false)
                    {
                        MsgIntervalo = mensajeIntervalo;
                    }

                    if(intensidadOk == false)
                    {
                        MsgIntensidad = mensajeIntensidad;
                    }
                    
                    if(diaOk == false)
                    {
                        MsgDia = mensajeDia;
                    }
                    if(formadorOk == false)
                    {
                        MsgFormador = mensajeFormador;
                    }
                    return Page();
                }
            }
            return RedirectToPage("./HorarioList");
        }
    }
}
