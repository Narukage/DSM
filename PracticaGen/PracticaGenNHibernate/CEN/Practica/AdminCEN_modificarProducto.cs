
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


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_Admin_modificarProducto) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class AdminCEN
{
public void ModificarProducto (int p_oid, double p_precio, string p_nombre, string p_foto)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_Admin_modificarProducto) ENABLED START*/

        // Write here your custom code...

        ProductoCEN productoCEN = new ProductoCEN ();

        productoCEN.Modify (p_oid, p_precio, p_nombre, p_foto);


        /*PROTECTED REGION END*/
}
}
}
