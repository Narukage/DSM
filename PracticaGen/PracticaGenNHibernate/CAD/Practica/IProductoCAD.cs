
using System;
using PracticaGenNHibernate.EN.Practica;

namespace PracticaGenNHibernate.CAD.Practica
{
public partial interface IProductoCAD
{
ProductoEN ReadOIDDefault (int id
                           );

void ModifyDefault (ProductoEN producto);



int New_ (ProductoEN producto);

void Modify (ProductoEN producto);


void Destroy (int id
              );


ProductoEN ReadOID (int id
                    );


System.Collections.Generic.IList<ProductoEN> GetTodosProductos (int first, int size);


System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.ProductoEN> GetProductosNombre (string p_nombre);
}
}
