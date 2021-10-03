using System;

namespace SGE.App.Dominio
{
    public class Nota
    {
        public int Id{get; set;}
        public float Valor{get; set;}
        public Calificacion Calificacion{get; set;}
        public Usuario Estudiante{get; set;}
    }
}
