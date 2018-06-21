
using System;
using PracticaGenNHibernate.EN.Practica;

namespace PracticaGenNHibernate.CAD.Practica
{
public partial interface IPizzaCAD
{
PizzaEN ReadOIDDefault (int id
                        );

void ModifyDefault (PizzaEN pizza);



int New_ (PizzaEN pizza);

void Modify (PizzaEN pizza);


void Destroy (int id
              );


PizzaEN ReadOID (int id
                 );


System.Collections.Generic.IList<PizzaEN> ReadAll (int first, int size);
}
}
