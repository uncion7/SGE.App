using System;

namespace SGE.App.Dominio
{
    public class Nota
    {
        public int Id{get; set;}
        
        public Usuario Estudiante{get; set;}
        public Grupo Grupo {get; set;}
        public float Nota1{get; set;}
        public float Nota2{get; set;}
        public float Nota3{get; set;}
        public float Nota4{get; set;}
        public float Nota5{get; set;}

        public float NotaDef{get; set;}
    }
}
