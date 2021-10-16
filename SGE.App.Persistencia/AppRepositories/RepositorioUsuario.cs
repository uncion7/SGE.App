using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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

        public String miCodigo(string codigo, int valor)
        {
            var b = valor.ToString().Length;
            string ceros;
            if(b == 1)
            {
                ceros = "000";
            }
            else if(b == 2)
            {
                ceros = "00";
            }
            else if(b == 1)
            {
                ceros = "0";
            }
            else
            {
                ceros = "";
            }
            var res = codigo + "-" + ceros + valor;
            return res;
        }

        Usuario IRepositorioUsuario.AddUsuario(Usuario usuario)
        {
            var usuarioAdicionado =_appContext.Usuarios.Add(usuario);
            _appContext.SaveChanges();
            try{
                var miCode = miCodigo(usuarioAdicionado.Entity.Rol.Codigo, usuarioAdicionado.Entity.Id);
                //usuarioAdicionado.Entity.Codigo = miCode;
                //_appContext.SaveChanges();
            }
            catch
            {
                //p
            }
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
            return _appContext.Usuarios.Include(g => g.Municipio).Include(g=>g.Rol);;
        }

        Usuario IRepositorioUsuario.GetUsuario(int idUsuario)
        {
            var miUsuario = _appContext.Usuarios.Include(m => m.Municipio).Include(m => m.Rol).FirstOrDefault(m => m.Id==idUsuario);
            return miUsuario;
        }

        Usuario IRepositorioUsuario.UpdateUsuario(Usuario usuario)
        {
            var usuarioEncontrado =_appContext.Usuarios.Include(m => m.Municipio).Include(m => m.Rol).FirstOrDefault(m => m.Id==usuario.Id);
            if(usuarioEncontrado!=null)
            {
                usuarioEncontrado.User = usuario.User;
                usuarioEncontrado.Cedula = usuario.Cedula;
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
