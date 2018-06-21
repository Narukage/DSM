
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


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_Producto_vincularLineaPedido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class ProductoCEN
{
public void VincularLineaPedido (int p_Producto_OID, int p_lineaPedido_OID)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_Producto_vincularLineaPedido) ENABLED START*/

        // Write here your custom code...

        ProductoEN prodcutoEN = _IProductoCAD.ReadOID(p_Producto_OID);

        prodcutoEN.LineaPedido
        _IPedidoCAD.Modify(pedidoEN);
        throw new NotImplementedException ("Method VincularLineaPedido() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
