
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


System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.ProductoEN> GetProductosNombre (string p_nombre);


System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.ProductoEN> BuscarProducto (string nombre);


System.Collections.Generic.IList<ProductoEN> ReadAll (int first, int size);
}
}
