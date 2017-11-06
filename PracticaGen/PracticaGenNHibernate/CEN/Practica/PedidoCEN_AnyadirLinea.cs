
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


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_Pedido_anyadirLinea) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class PedidoCEN
{
public void AnyadirLinea (int p_oid)
{
            /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_Pedido_anyadirLinea) ENABLED START*/

            // Write here your custom code...
            PedidoEN pedidoEN = null;
            pedidoEN= new PedidoEN();
            LineaPedidoEN linea_nueva = new LineaPedidoEN();
            linea_nueva.Id = p_oid;

            pedidoEN.LineaPedido.Add(linea_nueva);

            _IPedidoCAD.Modify(pedidoEN); //se manda al CAD

        throw new NotImplementedException ("Method AnyadirLinea() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
