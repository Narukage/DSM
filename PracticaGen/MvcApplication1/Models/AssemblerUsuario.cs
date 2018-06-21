using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class AssemblerUsuario
    {
        public Usuario ConvertENToModelUI(UsuarioEN en, NHibernate.ISession session)
        {
            Usuario inc = new Usuario();

            inc.email = en.Email;
            inc.nombre = en.Nombre;
            inc.telefono = en.Telefono;
            inc.contrasenya = en.Contrasenya;
            inc.fecha_nac = en.Fecha_nac;
            inc.fecha_reg = en.FechaRegistro;
            inc.id = en.Id;
            inc.direccion = new AssemblerDireccion().ConvertListENToModel(en.Direccion,session);

            return (inc);
        }

        public IList<Usuario> ConvertListENToModel(IList<UsuarioEN> ens, NHibernate.ISession session)
        {
            IList<Usuario> inc = new List<Usuario>();

            foreach (UsuarioEN i in ens)
            {
                inc.Add(ConvertENToModelUI(i,session));
            }
            return inc;
        }
    }
}