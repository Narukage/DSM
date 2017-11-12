
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


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_Pedido_cambiarEstado) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class PedidoCEN
{
public void CambiarEstado (int p_oid, PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum estado)
{
            /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_Pedido_cambiarEstado) ENABLED START*/

            // Write here your custom code...

            PedidoEN pedidoEN = _IPedidoCAD.ReadOID(p_oid);

            pedidoEN.Estado = estado;
            _IPedidoCAD.Modify(pedidoEN);

        /*PROTECTED REGION END*/
}
}
}
