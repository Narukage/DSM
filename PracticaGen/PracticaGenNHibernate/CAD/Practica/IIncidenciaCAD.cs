
using System;
using PracticaGenNHibernate.EN.Practica;

namespace PracticaGenNHibernate.CAD.Practica
{
public partial interface IIncidenciaCAD
{
IncidenciaEN ReadOIDDefault (int id
                             );

void ModifyDefault (IncidenciaEN incidencia);



int New_ (IncidenciaEN incidencia);

void Modify (IncidenciaEN incidencia);


void Destroy (int id
              );


IncidenciaEN ReadOID (int id
                      );


System.Collections.Generic.IList<IncidenciaEN> ReadAll (int first, int size);



long IncidenciasMes (int ? p_mes);
}
}
