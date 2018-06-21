
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


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_Pedido_comprobarCodigo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class PedidoCEN
{
public bool ComprobarCodigo (int codigo)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_Pedido_comprobarCodigo) ENABLED START*/

        // Write here your custom code...


        bool activado = false;

        if (String.IsNullOrEmpty (codigo.ToString ())) {
                activado = true;
        }

        return activado;





        /*PROTECTED REGION END*/
}
}
}
