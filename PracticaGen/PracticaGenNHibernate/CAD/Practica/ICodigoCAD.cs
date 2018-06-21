
using System;
using PracticaGenNHibernate.EN.Practica;

namespace PracticaGenNHibernate.CAD.Practica
{
public partial interface ICodigoCAD
{
CodigoEN ReadOIDDefault (int id
                         );

void ModifyDefault (CodigoEN codigo);



int New_ (CodigoEN codigo);

void Modify (CodigoEN codigo);


void Destroy (int id
              );


CodigoEN ReadOID (int id
                  );


System.Collections.Generic.IList<CodigoEN> ReadAll (int first, int size);
}
}
