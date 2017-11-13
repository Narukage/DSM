
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


void AnyadirDireccion (string p_Usuario_OID, System.Collections.Generic.IList<int> p_direccion_OIDs);

void EliminarDireccion (string p_Usuario_OID, System.Collections.Generic.IList<int> p_direccion_OIDs);


System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.UsuarioEN> GetUsuario (string p_nombre);


UsuarioEN ReadOID (string email
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);


long UsuariosMes (Nullable<DateTime> p_fecha);


System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.UsuarioEN> BuscarUsuario (string p_nombre);
}
}
