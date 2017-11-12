
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


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_Admin_anyadirPedido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class AdminCEN
{
public void AnyadirPedido (double p_precio, PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum p_tipo_pago, Nullable<DateTime> p_fecha, PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum p_estado, string p_usuario)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_Admin_anyadirPedido) ENABLED START*/

        // Write here your custom code...

        PedidoCEN pedidoCEN = new PedidoCEN ();

        int id = pedidoCEN.New_ (p_estado, p_fecha, p_precio, p_tipo_pago, p_usuario);

        Console.WriteLine ("id: " + id);

        /*PROTECTED REGION END*/
}
}
}
