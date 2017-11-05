
using System;
using PracticaGenNHibernate.EN.Practica;

namespace PracticaGenNHibernate.CAD.Practica
{
public partial interface IComplementoCAD
{
ComplementoEN ReadOIDDefault (int id
                              );

void ModifyDefault (ComplementoEN complemento);



int New_ (ComplementoEN complemento);

void Modify (ComplementoEN complemento);


void Destroy (int id
              );


System.Collections.Generic.IList<ComplementoEN> GetTodosProductos (int first, int size);
}
}
