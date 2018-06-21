
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


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_LineaPedido_anyadirProducto) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class LineaPedidoCEN
{
public void AnyadirProducto (int p_LineaPedido_OID, int p_producto_OID)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_LineaPedido_anyadirProducto_customized) START*/

 
    LineaPedidoEN linped = new LineaPedidoEN();
    linped = _ILineaPedidoCAD.ReadOID(p_LineaPedido_OID);
    ProductoEN producto = new ProductoEN();
    producto = _IProductoCAD.ReadOID(p_producto_OID);
    linped.Producto.Id = p_producto_OID;
        //Call to LineaPedidoCAD

        _ILineaPedidoCAD.AnyadirProducto (p_LineaPedido_OID, p_producto_OID);

        /*PROTECTED REGION END*/
}
}
}
