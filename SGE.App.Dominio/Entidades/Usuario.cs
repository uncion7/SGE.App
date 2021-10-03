using System;
using System.Collections.Generic;

namespace SGE.App.Dominio
{
    public class Usuario
    {
        public int Id {get; set;}
        public string Cedula {get; set;}
        public string Contrasena {get; set;}
        public string Nombre {get; set;}
        public string Apellidos {get; set;}
        public string Correo {get; set;}
        public string Celular {get; set;}
        public string Telefono {get; set;} 
        public string Direccion {get; set;}
        public Municipio Municipio {get; set;}
        public Rol Rol {get; set;}
    }
}


