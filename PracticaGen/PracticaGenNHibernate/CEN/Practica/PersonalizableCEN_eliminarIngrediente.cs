
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


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_Personalizable_eliminarIngrediente) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class PersonalizableCEN
{
public void EliminarIngrediente (int p_Personalizable_OID, System.Collections.Generic.IList<int> p_ingrediente_OIDs)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_Personalizable_eliminarIngrediente_customized) START*/


        //Call to PersonalizableCAD
    PersonalizableEN per = _IPersonalizableCAD.ReadOIDDefault(p_Personalizable_OID);
    IngredienteCEN ing = new IngredienteCEN();

    per.Precio -= ing.ReadOID(p_ingrediente_OIDs[0]).Precio;
    _IPersonalizableCAD.Modify(per);

    _IPersonalizableCAD.EliminarIngrediente (p_Personalizable_OID, p_ingrediente_OIDs);

        /*PROTECTED REGION END*/
}
}
}
