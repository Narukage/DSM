
using System;
using PracticaGenNHibernate.EN.Practica;

namespace PracticaGenNHibernate.CAD.Practica
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (int id
                          );

void ModifyDefault (UsuarioEN usuario);



int New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (int id
              );


void AnyadirDireccion (int p_Usuario_OID, System.Collections.Generic.IList<int> p_direccion_OIDs);

void EliminarDireccion (int p_Usuario_OID, System.Collections.Generic.IList<int> p_direccion_OIDs);


System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.UsuarioEN> GetUsuario (string p_nombre);


UsuarioEN ReadOID (int id
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);


long UsuariosMes (Nullable<DateTime> p_fecha);


System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.UsuarioEN> BuscarUsuario (string p_nombre);


System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.UsuarioEN> UsuarioPorEmail (string p_email);
}
}
