
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaGenNHibernate.Exceptions;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_Producto_incrementarNumVeces) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class ProductoCEN
{
public void IncrementarNumVeces (int p_oid, int cantidad)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_Producto_incrementarNumVeces) ENABLED START*/

        // Write here your custom code...
        ProductoEN proEN = new ProductoEN ();

        proEN = _IProductoCAD.ReadOIDDefault (p_oid);
        proEN.NumVeces += cantidad;
        _IProductoCAD.ModifyDefault (proEN);

        /*PROTECTED REGION END*/
}
}
}
