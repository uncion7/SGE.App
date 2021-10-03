using System;

namespace SGE.App.Dominio
{
    public class Horario
    {
        public int Id{get; set;}
        public string DiaSemana{get; set;}
        public TimeSpan HoraInicial{get; set;}
        public TimeSpan HoraFinal{get; set;}
    }
}


