
using System;
using PracticaGenNHibernate.EN.Practica;

namespace PracticaGenNHibernate.CAD.Practica
{
public partial interface IBebidaCAD
{
BebidaEN ReadOIDDefault (int id
                         );

void ModifyDefault (BebidaEN bebida);



int New_ (BebidaEN bebida);

void Modify (BebidaEN bebida);


void Destroy (int id
              );


System.Collections.Generic.IList<BebidaEN> GetTodosProductos (int first, int size);
}
}
