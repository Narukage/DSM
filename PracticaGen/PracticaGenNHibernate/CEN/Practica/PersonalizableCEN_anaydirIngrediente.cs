
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


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_Personalizable_anaydirIngrediente) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class PersonalizableCEN
{
public void AnaydirIngrediente (int p_Personalizable_OID, System.Collections.Generic.IList<int> p_ingrediente_OID)
{
            /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_Personalizable_anaydirIngrediente_customized)ENABLE START*/
            PersonalizableEN per = _IPersonalizableCAD.ReadOID(p_Personalizable_OID);
            per.Precio += new IngredienteCAD().ReadOIDDefault(p_ingrediente_OID[0]).Precio;
            _IPersonalizableCAD.Modify(per);
            _IPersonalizableCAD.AnaydirIngrediente(p_Personalizable_OID, p_ingrediente_OID);

            //Call to PersonalizableCAD

            _IPersonalizableCAD.AnaydirIngrediente (p_Personalizable_OID, p_ingrediente_OID);

        /*PROTECTED REGION END*/
}
}
}
