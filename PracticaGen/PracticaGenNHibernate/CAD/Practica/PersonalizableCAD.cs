
using System;
using System.Text;
using PracticaGenNHibernate.CEN.Practica;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.Exceptions;


/*
 * Clase Personalizable:
 *
 */

namespace PracticaGenNHibernate.CAD.Practica
{
public partial class PersonalizableCAD : BasicCAD, IPersonalizableCAD
{
public PersonalizableCAD() : base ()
{
}

public PersonalizableCAD(ISession sessionAux) : base (sessionAux)
{
}



public PersonalizableEN ReadOIDDefault (int id
                                        )
{
        PersonalizableEN personalizableEN = null;

        try
        {
                SessionInitializeTransaction ();
                personalizableEN = (PersonalizableEN)session.Get (typeof(PersonalizableEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PersonalizableCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return personalizableEN;
}

public System.Collections.Generic.IList<PersonalizableEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PersonalizableEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PersonalizableEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PersonalizableEN>();
                        else
                                result = session.CreateCriteria (typeof(PersonalizableEN)).List<PersonalizableEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PersonalizableCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PersonalizableEN personalizable)
{
        try
        {
                SessionInitializeTransaction ();
                PersonalizableEN personalizableEN = (PersonalizableEN)session.Load (typeof(PersonalizableEN), personalizable.Id);

                session.Update (personalizableEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PersonalizableCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PersonalizableEN personalizable)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (personalizable);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PersonalizableCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return personalizable.Id;
}

public void Modify (PersonalizableEN personalizable)
{
        try
        {
                SessionInitializeTransaction ();
                PersonalizableEN personalizableEN = (PersonalizableEN)session.Load (typeof(PersonalizableEN), personalizable.Id);

                personalizableEN.Precio = personalizable.Precio;


                personalizableEN.Nombre = personalizable.Nombre;


                personalizableEN.Foto = personalizable.Foto;


                personalizableEN.Tamaño = personalizable.Tamaño;


                personalizableEN.Masa = personalizable.Masa;

                session.Update (personalizableEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PersonalizableCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                PersonalizableEN personalizableEN = (PersonalizableEN)session.Load (typeof(PersonalizableEN), id);
                session.Delete (personalizableEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PersonalizableCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AnaydirIngrediente (int p_Personalizable_OID, System.Collections.Generic.IList<int> p_ingrediente_OID)
{
        PracticaGenNHibernate.EN.Practica.PersonalizableEN personalizableEN = null;
        try
        {
                SessionInitializeTransaction ();
                personalizableEN = (PersonalizableEN)session.Load (typeof(PersonalizableEN), p_Personalizable_OID);
                PracticaGenNHibernate.EN.Practica.IngredienteEN ingredienteENAux = null;
                if (personalizableEN.Ingrediente == null) {
                        personalizableEN.Ingrediente = new System.Collections.Generic.List<PracticaGenNHibernate.EN.Practica.IngredienteEN>();
                }

                foreach (int item in p_ingrediente_OID) {
                        ingredienteENAux = new PracticaGenNHibernate.EN.Practica.IngredienteEN ();
                        ingredienteENAux = (PracticaGenNHibernate.EN.Practica.IngredienteEN)session.Load (typeof(PracticaGenNHibernate.EN.Practica.IngredienteEN), item);
                        ingredienteENAux.Personalizable.Add (personalizableEN);

                        personalizableEN.Ingrediente.Add (ingredienteENAux);
                }


                session.Update (personalizableEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PersonalizableCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<PersonalizableEN> GetTodosProductos (int first, int size)
{
        System.Collections.Generic.IList<PersonalizableEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PersonalizableEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PersonalizableEN>();
                else
                        result = session.CreateCriteria (typeof(PersonalizableEN)).List<PersonalizableEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PersonalizableCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: ReadOID
//Con e: PersonalizableEN
public PersonalizableEN ReadOID (int id
                                 )
{
        PersonalizableEN personalizableEN = null;

        try
        {
                SessionInitializeTransaction ();
                personalizableEN = (PersonalizableEN)session.Get (typeof(PersonalizableEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PersonalizableCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return personalizableEN;
}

public System.Collections.Generic.IList<PersonalizableEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PersonalizableEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PersonalizableEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PersonalizableEN>();
                else
                        result = session.CreateCriteria (typeof(PersonalizableEN)).List<PersonalizableEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PersonalizableCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
