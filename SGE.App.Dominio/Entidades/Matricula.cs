using System;

namespace SGE.App.Dominio
{
    public class Matricula
    {
        public int Id{get; set;}
        public Grupo Grupo{get; set;}

        public Usuario Estudiante{get; set;}
    }
}
