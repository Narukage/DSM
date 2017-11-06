
using System;
using PracticaGenNHibernate.EN.Practica;

namespace PracticaGenNHibernate.CAD.Practica
{
public partial interface IRegistradoCAD
{
RegistradoEN ReadOIDDefault (string email
                             );

void ModifyDefault (RegistradoEN registrado);



string New_ (RegistradoEN registrado);

void Modify (RegistradoEN registrado);


void Destroy (string email
              );


RegistradoEN ReadOID (string email
                      );


System.Collections.Generic.IList<RegistradoEN> ReadAll (int first, int size);
}
}
