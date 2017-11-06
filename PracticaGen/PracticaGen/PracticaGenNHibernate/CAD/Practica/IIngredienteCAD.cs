
using System;
using PracticaGenNHibernate.EN.Practica;

namespace PracticaGenNHibernate.CAD.Practica
{
public partial interface IIngredienteCAD
{
IngredienteEN ReadOIDDefault (int id
                              );

void ModifyDefault (IngredienteEN ingrediente);



int New_ (IngredienteEN ingrediente);

void Modify (IngredienteEN ingrediente);


void Destroy (int id
              );


System.Collections.Generic.IList<IngredienteEN> GetTodosProductos (int first, int size);


IngredienteEN ReadOID (int id
                       );


System.Collections.Generic.IList<IngredienteEN> ReadAll (int first, int size);
}
}
