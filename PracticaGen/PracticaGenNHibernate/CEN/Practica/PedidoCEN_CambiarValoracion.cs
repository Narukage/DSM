
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


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_Pedido_CambiarValoracion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class PedidoCEN
{
public void CambiarValoracion (int p_oid, double media)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_Pedido_CambiarValoracion) ENABLED START*/

        // Write here your custom code...

        PedidoEN pedidoEN = new PedidoEN ();

        pedidoEN = _IPedidoCAD.ReadOIDDefault (p_oid);
        pedidoEN.Valoracion = media;
        _IPedidoCAD.ModifyDefault (pedidoEN);



        /*PROTECTED REGION END*/
}
}
}
