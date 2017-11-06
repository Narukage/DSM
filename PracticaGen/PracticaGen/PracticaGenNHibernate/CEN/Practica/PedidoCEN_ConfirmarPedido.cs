
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


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_Pedido_confirmarPedido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class PedidoCEN
{
public void ConfirmarPedido (int p_oid)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_Pedido_confirmarPedido) ENABLED START*/

        // Write here your custom code...
        PedidoEN pedido = _IPedidoCAD.ReadOID (p_oid);

        pedido.Confirmado = true;
        _IPedidoCAD.ModifyDefault (pedido);

        /*PROTECTED REGION END*/
}
}
}
