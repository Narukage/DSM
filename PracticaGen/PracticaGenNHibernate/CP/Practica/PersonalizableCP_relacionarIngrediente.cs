
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.CEN.Practica;



/*PROTECTED REGION ID(usingPracticaGenNHibernate.CP.Practica_Personalizable_relacionarIngrediente) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CP.Practica
{
public partial class PersonalizableCP : BasicCP
{
public void RelacionarIngrediente (int p_Personalizable_OID, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.IngredienteEN> p_ingrediente_OIDs)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CP.Practica_Personalizable_relacionarIngrediente) ENABLED START*/

        IPersonalizableCAD personalizableCAD = null;
        PersonalizableCEN personalizableCEN = null;



        try
        {
                SessionInitializeTransaction ();
                personalizableCAD = new PersonalizableCAD (session);
                personalizableCEN = new  PersonalizableCEN (personalizableCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method RelacionarIngrediente() not yet implemented.");



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
