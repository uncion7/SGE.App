using System;

namespace SGE.App.Dominio
{
    public class Calificacion
    {
        public int Id{get; set;}
        public string Nombre{get; set;}
        public float VrPonderado{get; set;}
        public Grupo Grupo{get; set;}
    }
}
