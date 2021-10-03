using System.Collections.Generic;
using System.Linq;
using SGE.App.Dominio;

namespace SGE.App.Persistencia
{
    public class RepositorioUsuario:IRepositorioUsuario
    {
        
        ///<sumary>
        ///Referencia al contexto del Municipio
        ///</sumary>
        
        private readonly AppContext _appContext;
        
        ///<sumary>
        ///Metodo constructor utiliza
        ///Inyeccion de dependencias para garantizar el contexto
        ///</sumary>
        ///<param name="appContext"></param>//

        public RepositorioUsuario(AppContext appContext)
        {
            _appContext = appContext;
        }

        Usuario IRepositorioUsuario.AddUsuario(Usuario usuario)
        {
            var usuarioAdicionado =_appContext.Usuarios.Add(usuario);
            _appContext.SaveChanges();
            return usuarioAdicionado.Entity;
        }

        void IRepositorioUsuario.DeleteUsuario(int idUsuario)
        {
            var usuarioEncontrado = _appContext.Usuarios.FirstOrDefault(m => m.Id==idUsuario);
            if(usuarioEncontrado==null)
                return;
            _appContext.Usuarios.Remove(usuarioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Usuario> IRepositorioUsuario.GetAllUsuarios()
        {
            return _appContext.Usuarios;
        }

        Usuario IRepositorioUsuario.GetUsuario(int idUsuario)
        {
            return _appContext.Usuarios.FirstOrDefault(m => m.Id==idUsuario);
        }

        Usuario IRepositorioUsuario.UpdateUsuario(Usuario usuario)
        {
            var usuarioEncontrado =_appContext.Usuarios.FirstOrDefault(m => m.Id==usuario.Id);
            if(usuarioEncontrado!=null)
            {
                usuarioEncontrado.Cedula = usuario.Cedula;
                usuarioEncontrado.Contrasena = usuario.Contrasena;
                usuarioEncontrado.Nombre = usuario.Nombre;
                usuarioEncontrado.Apellidos = usuario.Apellidos;
                usuarioEncontrado.Correo = usuario.Correo;
                usuarioEncontrado.Celular = usuario.Celular;
                usuarioEncontrado.Telefono = usuario.Telefono;
                usuarioEncontrado.Direccion = usuario.Direccion;
                usuarioEncontrado.Municipio = usuario.Municipio;
                usuarioEncontrado.Rol = usuario.Rol;
                _appContext.SaveChanges();
            }
            return usuarioEncontrado;
        }
        
    }
}
