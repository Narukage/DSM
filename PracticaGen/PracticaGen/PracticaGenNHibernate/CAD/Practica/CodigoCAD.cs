
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
 * Clase Codigo:
 *
 */

namespace PracticaGenNHibernate.CAD.Practica
{
public partial class CodigoCAD : BasicCAD, ICodigoCAD
{
public CodigoCAD() : base ()
{
}

public CodigoCAD(ISession sessionAux) : base (sessionAux)
{
}



public CodigoEN ReadOIDDefault (int id
                                )
{
        CodigoEN codigoEN = null;

        try
        {
                SessionInitializeTransaction ();
                codigoEN = (CodigoEN)session.Get (typeof(CodigoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in CodigoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return codigoEN;
}

public System.Collections.Generic.IList<CodigoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CodigoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CodigoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CodigoEN>();
                        else
                                result = session.CreateCriteria (typeof(CodigoEN)).List<CodigoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in CodigoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CodigoEN codigo)
{
        try
        {
                SessionInitializeTransaction ();
                CodigoEN codigoEN = (CodigoEN)session.Load (typeof(CodigoEN), codigo.Id);

                codigoEN.Descuento = codigo.Descuento;


                codigoEN.Tipo = codigo.Tipo;



                session.Update (codigoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in CodigoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CodigoEN codigo)
{
        try
        {
                SessionInitializeTransaction ();
                if (codigo.Admin != null) {
                        // Argumento OID y no colección.
                        codigo.Admin = (PracticaGenNHibernate.EN.Practica.AdminEN)session.Load (typeof(PracticaGenNHibernate.EN.Practica.AdminEN), codigo.Admin.Email);

                        codigo.Admin.Codigo
                        .Add (codigo);
                }

                session.Save (codigo);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in CodigoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return codigo.Id;
}

public void Modify (CodigoEN codigo)
{
        try
        {
                SessionInitializeTransaction ();
                CodigoEN codigoEN = (CodigoEN)session.Load (typeof(CodigoEN), codigo.Id);

                codigoEN.Descuento = codigo.Descuento;


                codigoEN.Tipo = codigo.Tipo;

                session.Update (codigoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in CodigoCAD.", ex);
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
                CodigoEN codigoEN = (CodigoEN)session.Load (typeof(CodigoEN), id);
                session.Delete (codigoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in CodigoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: CodigoEN
public CodigoEN ReadOID (int id
                         )
{
        CodigoEN codigoEN = null;

        try
        {
                SessionInitializeTransaction ();
                codigoEN = (CodigoEN)session.Get (typeof(CodigoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in CodigoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return codigoEN;
}

public System.Collections.Generic.IList<CodigoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CodigoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CodigoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CodigoEN>();
                else
                        result = session.CreateCriteria (typeof(CodigoEN)).List<CodigoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in CodigoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
