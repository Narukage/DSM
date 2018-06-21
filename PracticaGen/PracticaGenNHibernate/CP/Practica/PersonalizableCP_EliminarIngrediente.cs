
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.CEN.Practica;



/*PROTECTED REGION ID(usingPracticaGenNHibernate.CP.Practica_Personalizable_eliminarIngrediente) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CP.Practica
{
public partial class PersonalizableCP : BasicCP
{
public void EliminarIngrediente (int p_Personalizable_OID, System.Collections.Generic.IList<int> p_ingrediente_OIDs)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CP.Practica_Personalizable_eliminarIngrediente) ENABLED START*/

        IPersonalizableCAD personalizableCAD = null;
        PersonalizableCEN personalizableCEN = null;



        try
        {
                SessionInitializeTransaction ();
                personalizableCAD = new PersonalizableCAD (session);
                personalizableCEN = new  PersonalizableCEN (personalizableCAD);

                PersonalizableEN per = personalizableCAD.ReadOIDDefault (p_Personalizable_OID);
                IngredienteCEN ing = new IngredienteCEN ();

                per.Precio -= ing.ReadOID (p_ingrediente_OIDs [0]).Precio;
                personalizableCAD.Modify (per);


                //Call to PersonalizableCAD

                personalizableCAD.EliminarIngrediente (p_Personalizable_OID, p_ingrediente_OIDs);



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
