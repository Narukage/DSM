
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


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_LineaPedido_valorarLinea) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class LineaPedidoCEN
{
public void ValorarLinea (int p_oid, PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum valoracion_linea)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_LineaPedido_valorarLinea) ENABLED START*/

        // Write here your custom code...
        LineaPedidoEN lpedidoEN = new LineaPedidoEN ();

        lpedidoEN = _ILineaPedidoCAD.ReadOIDDefault (p_oid);
        lpedidoEN.Valoracion = valoracion_linea;
        _ILineaPedidoCAD.ModifyDefault (lpedidoEN);
        //throw new NotImplementedException ("Method ValorarLinea() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
