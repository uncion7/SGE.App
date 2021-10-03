using System;
using System.Collections.Generic;

namespace SGE.App.Dominio
{
    public class Grupo
    {
        public int Id{get; set;}
        public string Nombre{get; set;}
        public string Codigo{get; set;}
        public Ciclo Ciclo{get; set;}
        public List<Horario> Horarios{get; set;}
        public Usuario Formador{get; set;}
        public Usuario Tutor{get; set;}
        public List<Usuario> Estudiantes{get; set;}
    }
}



