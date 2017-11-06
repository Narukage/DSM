
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


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_Usuario_confirmarPedido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class UsuarioCEN
{
public void ConfirmarPedido (int p_oid)
{
            /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_Usuario_confirmarPedido) ENABLED START*/
            
            PedidoEN pedido = pedidoCEN.ReadOID(p_oid);
            pedido.Confirmado = true;
                        

        throw new NotImplementedException ("Method ConfirmarPedido() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
