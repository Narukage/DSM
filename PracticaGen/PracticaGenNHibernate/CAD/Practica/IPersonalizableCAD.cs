
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


void AnaydirIngrediente (int p_Personalizable_OID, System.Collections.Generic.IList<int> p_ingrediente_OIDs);

PersonalizableEN ReadOID (int id
                          );


System.Collections.Generic.IList<PersonalizableEN> ReadAll (int first, int size);


void EliminarIngrediente (int p_Personalizable_OID, System.Collections.Generic.IList<int> p_ingrediente_OIDs);

System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PersonalizableEN> TopVentas ();
}
}
