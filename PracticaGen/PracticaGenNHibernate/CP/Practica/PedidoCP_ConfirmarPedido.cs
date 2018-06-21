
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.CEN.Practica;



/*PROTECTED REGION ID(usingPracticaGenNHibernate.CP.Practica_Pedido_confirmarPedido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CP.Practica
{
public partial class PedidoCP : BasicCP
{
public void ConfirmarPedido (int p_oid)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CP.Practica_Pedido_confirmarPedido) ENABLED START*/

        IPedidoCAD pedidoCAD = null;
        PedidoCEN pedidoCEN = null;



        try
        {
                SessionInitializeTransaction ();
                pedidoCAD = new PedidoCAD (session);
                pedidoCEN = new  PedidoCEN (pedidoCAD);

                

                // Write here your custom transaction ...
                PedidoEN pedidoEN = pedidoCEN.ReadOID(p_oid);
                pedidoEN.Confirmado = true;

                foreach (LineaPedidoEN linea in pedidoEN.LineaPedido)
                {
                    linea.Producto.NumVeces += linea.Cantidad;
                }
                pedidoCAD.ModifyDefault(pedidoEN);
            

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
