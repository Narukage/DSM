
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


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_Admin_modificarPedido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class AdminCEN
{
public void ModificarPedido (int p_oid, double p_precio, PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum p_tipo_pago, Nullable<DateTime> p_fecha, PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum p_estado)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_Admin_modificarPedido) ENABLED START*/

        // Write here your custom code...
        PedidoCEN pedidoCEN = new PedidoCEN ();

        pedidoCEN.Modify (p_oid, p_estado, p_fecha, p_precio, p_tipo_pago);




        /*PROTECTED REGION END*/
}
}
}
