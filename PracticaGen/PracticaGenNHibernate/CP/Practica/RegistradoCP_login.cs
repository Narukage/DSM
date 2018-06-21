
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.CEN.Practica;



/*PROTECTED REGION ID(usingPracticaGenNHibernate.CP.Practica_Registrado_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CP.Practica
{
public partial class RegistradoCP : BasicCP
{
public bool Login (int correo, String pass)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CP.Practica_Registrado_login) ENABLED START*/

        IRegistradoCAD registradoCAD = null;
        RegistradoCEN registradoCEN = null;

        bool result = false;


        try
        {
                SessionInitializeTransaction ();
                registradoCAD = new RegistradoCAD (session);
                registradoCEN = new  RegistradoCEN (registradoCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method Login() not yet implemented.");



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
        return result;


        /*PROTECTED REGION END*/
}
}
}
