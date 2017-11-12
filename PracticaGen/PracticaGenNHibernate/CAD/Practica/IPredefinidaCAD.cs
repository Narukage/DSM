
using System;
using PracticaGenNHibernate.EN.Practica;

namespace PracticaGenNHibernate.CAD.Practica
{
public partial interface IPredefinidaCAD
{
PredefinidaEN ReadOIDDefault (int id
                              );

void ModifyDefault (PredefinidaEN predefinida);



int New_ (PredefinidaEN predefinida);

void Modify (PredefinidaEN predefinida);


void Destroy (int id
              );


PredefinidaEN ReadOID (int id
                       );


System.Collections.Generic.IList<PredefinidaEN> ReadAll (int first, int size);
}
}
