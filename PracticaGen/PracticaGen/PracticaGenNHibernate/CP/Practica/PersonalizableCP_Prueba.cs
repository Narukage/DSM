
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.CEN.Practica;



/*PROTECTED REGION ID(usingPracticaGenNHibernate.CP.Practica_Personalizable_prueba) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CP.Practica
{
public partial class PersonalizableCP : BasicCP
{
public void Prueba (int p_oid, int p_ingrediente_OID)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CP.Practica_Personalizable_prueba) ENABLED START*/

        IPersonalizableCAD personalizableCAD = null;
        PersonalizableCEN personalizableCEN = null;



        try
        {
                SessionInitializeTransaction ();
                personalizableCAD = new PersonalizableCAD (session);
                personalizableCEN = new  PersonalizableCEN (personalizableCAD);



                // Write here your custom transaction ...
                personalizableCEN = personalizableCAD.ReadOIDDefault(p_oid);
                IngredienteEN ing = new IngredienteCEN().ReadOIDDefault(p_ingrediente);
                personalizableCEN.Ingrediente.Add(ing);
                _IPersonalizableCAD.ModifyDefault(pizza);
                throw new NotImplementedException ("Method Prueba() not yet implemented.");



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
