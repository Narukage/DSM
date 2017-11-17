
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.CEN.Practica;



/*PROTECTED REGION ID(usingPracticaGenNHibernate.CP.Practica_Pedido_calcularPrecio) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CP.Practica
{
public partial class PedidoCP : BasicCP
{
public double CalcularPrecio (int p_oid)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CP.Practica_Pedido_calcularPrecio) ENABLED START*/

        IPedidoCAD pedidoCAD = null;
        PedidoCEN pedidoCEN = null;

        int cantidad = 0;
        double preciototal = 0;


        try
        {
                SessionInitializeTransaction ();
                pedidoCAD = new PedidoCAD (session);
                pedidoCEN = new  PedidoCEN (pedidoCAD);

                PedidoEN pedidoEN = pedidoCAD.ReadOIDDefault (p_oid);

                foreach (LineaPedidoEN lineaped in pedidoEN.LineaPedido) {
                        cantidad = lineaped.Cantidad;
                        preciototal += lineaped.Producto.Precio * cantidad;
                }
                pedidoEN.PrecioTotal = preciototal;

                pedidoCAD.ModifyDefault (pedidoEN);

                // Write here your custom transaction ...





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
        return preciototal;


        /*PROTECTED REGION END*/
}
}
}
