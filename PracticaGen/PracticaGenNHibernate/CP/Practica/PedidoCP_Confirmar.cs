
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.CEN.Practica;
using System.Collections.Generic;



/*PROTECTED REGION ID(usingPracticaGenNHibernate.CP.Practica_Pedido_confirmar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CP.Practica
{
public partial class PedidoCP : BasicCP
{
public void Confirmar (int p_oid)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CP.Practica_Pedido_confirmar) ENABLED START*/

        IPedidoCAD pedidoCAD = null;
        PedidoCEN pedidoCEN = null;
        PedidoEN pedidoEN = null;

        IProductoCAD productoCAD = null;
        ProductoCEN productoCEN = null;


        try
        {
                SessionInitializeTransaction ();

                pedidoCAD = new PedidoCAD (session);
                pedidoCEN = new  PedidoCEN (pedidoCAD);

                productoCAD = new ProductoCAD(session);
                productoCEN = new ProductoCEN(productoCAD);

                pedidoEN = pedidoCEN.ReadOID(p_oid);

                IList<LineaPedidoEN> lineas = pedidoEN.LineaPedido;

                foreach (LineaPedidoEN l in lineas)
                {
                    productoCEN.IncrementarNumVeces(l.Producto.Id, l.Cantidad);
                    int veces = l.Producto.NumVeces;
                }

                pedidoEN.Confirmado = true;




                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
