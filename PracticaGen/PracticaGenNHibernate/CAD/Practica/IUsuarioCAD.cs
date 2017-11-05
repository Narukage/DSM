
using System;
using PracticaGenNHibernate.EN.Practica;

namespace PracticaGenNHibernate.CAD.Practica
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string email
                          );

void ModifyDefault (UsuarioEN usuario);



string New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (string email
              );







System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.UsuarioEN> GetUsuario (string p_nombre);
}
}
