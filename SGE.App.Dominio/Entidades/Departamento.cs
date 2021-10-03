using System;
using System.Collections.Generic;

namespace SGE.App.Dominio
{
    public class Departamento
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        public List<Municipio> Municipios {get; set;}
    }
}



