
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


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_Personalizable_relacionarIngrediente) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class PersonalizableCEN
{
public void RelacionarIngrediente (int p_Personalizable_OID, double p_precio, string p_nombre, string p_foto, PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum p_tamaño, PracticaGenNHibernate.Enumerated.Practica.TipomasaEnum p_masa)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_Personalizable_relacionarIngrediente_customized) START*/

        PersonalizableEN personalizableEN = null;

        //Initialized PersonalizableEN
        personalizableEN = new PersonalizableEN ();
        personalizableEN.Id = p_Personalizable_OID;
        personalizableEN.Precio = p_precio;
        personalizableEN.Nombre = p_nombre;
        personalizableEN.Foto = p_foto;
        personalizableEN.Tamaño = p_tamaño;
        personalizableEN.Masa = p_masa;
        //Call to PersonalizableCAD

        _IPersonalizableCAD.RelacionarIngrediente (personalizableEN);

        /*PROTECTED REGION END*/
}
}
}
