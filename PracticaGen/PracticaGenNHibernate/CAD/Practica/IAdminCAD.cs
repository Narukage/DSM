
using System;
using PracticaGenNHibernate.EN.Practica;

namespace PracticaGenNHibernate.CAD.Practica
{
public partial interface IAdminCAD
{
AdminEN ReadOIDDefault (int id
                        );

void ModifyDefault (AdminEN admin);



int New_ (AdminEN admin);

void Modify (AdminEN admin);


void Destroy (int id
              );


AdminEN ReadOID (int id
                 );


System.Collections.Generic.IList<AdminEN> ReadAll (int first, int size);
}
}
