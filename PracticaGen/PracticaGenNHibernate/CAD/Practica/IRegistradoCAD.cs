
using System;
using PracticaGenNHibernate.EN.Practica;

namespace PracticaGenNHibernate.CAD.Practica
{
public partial interface IRegistradoCAD
{
RegistradoEN ReadOIDDefault (int id
                             );

void ModifyDefault (RegistradoEN registrado);



int New_ (RegistradoEN registrado);

void Modify (RegistradoEN registrado);


void Destroy (int id
              );


RegistradoEN ReadOID (int id
                      );


System.Collections.Generic.IList<RegistradoEN> ReadAll (int first, int size);
}
}
