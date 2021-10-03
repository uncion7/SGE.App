using System;
using SGE.App.Dominio;
using SGE.App.Persistencia;

namespace SGE.App.Consola
{
    class Program
    {
        // Conexión con Interfaz y Base de datos
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio(new Persistencia.AppContext());
        private static IRepositorioRol _repoRol = new RepositorioRol(new Persistencia.AppContext());
        private static IRepositorioUsuario _repoUsuario = new RepositorioUsuario(new Persistencia.AppContext());
        
        // Clase principal donde se ejecutan los metodos (funciones)
        static void Main(string[] args)
        { 
            Console.WriteLine("Bienvenido al Sistema de Gestión Educativo - SGE");
            
            //MUNICIPIO
            //CrearMunicipio();
            EditarMunicipio(4);
            //EliminarMunicipio(3);
            BuscarMunicipio(1);
            BuscarTodosMunicipios();
            
            //ROL
            //CrearRol();
            //BuscarRol();
            //BuscarTodosRol();
            //EditarRol();
            //EliminarRol();

            //USUARIO
            //CrearUsuario(1, 1);
            //BuscarUsuario();
            //BuscarTodosUsuario();
            //EditarUsuario();
            //EliminarUsuario();
        }

        //Funciones por consola

        //CRUD Municipio
        //Municipio Crear
        private static void CrearMunicipio()
        {
            var municipio = new Municipio
            {
                Nombre = "Medellín"
            };
            _repoMunicipio.AddMunicipio(municipio);
            Console.WriteLine("Municipio creado: " + municipio.Nombre);
        }

        //Municipio Buscar
        private static void BuscarMunicipio(int idMunicipio)
        {
            var municipio = _repoMunicipio.GetMunicipio(idMunicipio);
            Console.WriteLine("Municipio Encontrado: " + municipio.Nombre);
        }

        private static void BuscarTodosMunicipios()
        {
            var todosMunicipios = _repoMunicipio.GetAllMunicipios();
            foreach (var item in todosMunicipios)
            {
               Console.WriteLine("Municipio: " + item.Id + " - " + item.Nombre);
            };
        }

        //Municipio Editar
        private static void EditarMunicipio(int idMunicipio)
        {
            var municipioEncontrado = _repoMunicipio.GetMunicipio(idMunicipio);
            municipioEncontrado.Nombre = "Cartagena";
            var municipio = _repoMunicipio.UpdateMunicipio(municipioEncontrado);
            Console.WriteLine("Municipio Editado: " + municipio.Nombre);
        }
        
        //Municipio Eliminar  
        private static void EliminarMunicipio(int idMunicipio)
        {
            _repoMunicipio.DeleteMunicipio(idMunicipio);
            Console.WriteLine("Municipio Borrado");
        }

        //CRUD Rol
        //Rol Crear
        private static void CrearRol()
        {   
            Rol rol = new Rol()
            {
                Nombre = "Estudiante",
                Codigo = "E-"
            };
            _repoRol.AddRol(rol);
            Console.WriteLine("Rol creado: " + rol.Nombre);
        }

        //Rol Buscar
        private static void BuscarRol(int idRol)
        {
            var rol = _repoRol.GetRol(idRol);
            Console.WriteLine("Rol Encontrado: " + rol.Nombre);
        }

        private static void BuscarTodosRol()
        {
            var todosRoles = _repoRol.GetAllRoles();
            foreach (var item in todosRoles)
            {
               Console.WriteLine("Rol: " + item.Id + " - " + item.Nombre);
            };
        }

        //Rol Editar
        private static void EditarRol(int idRol)
        {
            var rolEncontrado = _repoRol.GetRol(idRol);
            rolEncontrado.Nombre = "Otro";
            var rol = _repoRol.UpdateRol(rolEncontrado);
            Console.WriteLine("Rol Editado: " + rol.Nombre);
        }
              
        //Rol Eliminar  
        private static void EliminarRol(int idRol)
        {
            _repoRol.DeleteRol(idRol);
            Console.WriteLine("Rol Borrado");
        }

        //CRUD Usuario
        //Usuario Crear
        private static void CrearUsuario(int idMunicipio, int idRol)
        {   
            //Obtener Municipio
            Municipio municipio = _repoMunicipio.GetMunicipio(idMunicipio);
            Console.WriteLine("municipio: " + municipio.Nombre);
            //Obtener Rol
            Rol rol = _repoRol.GetRol(idRol);
            Console.WriteLine("rol: " + rol.Nombre);
            //Crear Usuario
            Usuario usuario = new Usuario()
            {
                Cedula = "18004392",
                Contrasena = "123456",
                Nombre = "Martin",
                Apellidos = "Cordoba",
                Correo = "uncion7@gmail.com",
                Celular = "3017869342",
                Telefono = "5130801",
                Direccion = "Bight M1-C5",
                Municipio = municipio,
                Rol = rol
            };
            _repoUsuario.AddUsuario(usuario);
            Console.WriteLine("Usuario creado: " + usuario.Nombre);
        }

        //Usuario Buscar
        private static void BuscarUsuario(int idUsuario)
        {
            var usuario = _repoUsuario.GetUsuario(idUsuario);
            Console.WriteLine("Usuario Encontrado: " + usuario.Nombre);
        }

        private static void BuscarTodosUsuario()
        {
            var todosUsuarios = _repoUsuario.GetAllUsuarios();
            foreach (var item in todosUsuarios)
            {
               Console.WriteLine("Usuario: " + item.Id + " - " + item.Nombre);
            };
        }

        //Usuario Editar
        private static void EditarUsuario(int idUsuario)
        {
            var usuarioEncontrado = _repoUsuario.GetUsuario(idUsuario);
            usuarioEncontrado.Nombre = "Ana";
            var usuario = _repoUsuario.UpdateUsuario(usuarioEncontrado);
            Console.WriteLine("Usuario Editado: " + usuario.Nombre);
        }
              
        //Usuario Eliminar  
        private static void EliminarUsuario(int idUsuario)
        {
            _repoUsuario.DeleteUsuario(idUsuario);
            Console.WriteLine("Usuario Borrado");
        }
        
    }
}

