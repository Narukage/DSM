
using System;
using PracticaGenNHibernate.EN.Practica;

namespace PracticaGenNHibernate.CAD.Practica
{
public partial interface IPersonalizableCAD
{
PersonalizableEN ReadOIDDefault (int id
                                 );

void ModifyDefault (PersonalizableEN personalizable);



int New_ (PersonalizableEN personalizable);

void Modify (PersonalizableEN personalizable);


void Destroy (int id
              );



System.Collections.Generic.IList<PersonalizableEN> GetTodosProductos (int first, int size);
}
}
