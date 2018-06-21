
using System;
using PracticaGenNHibernate.EN.Practica;

namespace PracticaGenNHibernate.CAD.Practica
{
public partial interface IDireccionCAD
{
DireccionEN ReadOIDDefault (int id
                            );

void ModifyDefault (DireccionEN direccion);



int New_ (DireccionEN direccion);

void Modify (DireccionEN direccion);


void Destroy (int id
              );


DireccionEN ReadOID (int id
                     );


System.Collections.Generic.IList<DireccionEN> ReadAll (int first, int size);
}
}
