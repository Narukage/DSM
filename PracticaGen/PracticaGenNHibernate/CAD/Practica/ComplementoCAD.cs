
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
 * Clase Complemento:
 *
 */

namespace PracticaGenNHibernate.CAD.Practica
{
public partial class ComplementoCAD : BasicCAD, IComplementoCAD
{
public ComplementoCAD() : base ()
{
}

public ComplementoCAD(ISession sessionAux) : base (sessionAux)
{
}



public ComplementoEN ReadOIDDefault (int id
                                     )
{
        ComplementoEN complementoEN = null;

        try
        {
                SessionInitializeTransaction ();
                complementoEN = (ComplementoEN)session.Get (typeof(ComplementoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in ComplementoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return complementoEN;
}

public System.Collections.Generic.IList<ComplementoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComplementoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComplementoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComplementoEN>();
                        else
                                result = session.CreateCriteria (typeof(ComplementoEN)).List<ComplementoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in ComplementoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComplementoEN complemento)
{
        try
        {
                SessionInitializeTransaction ();
                ComplementoEN complementoEN = (ComplementoEN)session.Load (typeof(ComplementoEN), complemento.Id);
                session.Update (complementoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in ComplementoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ComplementoEN complemento)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (complemento);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in ComplementoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return complemento.Id;
}

public void Modify (ComplementoEN complemento)
{
        try
        {
                SessionInitializeTransaction ();
                ComplementoEN complementoEN = (ComplementoEN)session.Load (typeof(ComplementoEN), complemento.Id);

                complementoEN.Precio = complemento.Precio;


                complementoEN.Nombre = complemento.Nombre;


                complementoEN.Foto = complemento.Foto;

                session.Update (complementoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in ComplementoCAD.", ex);
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
                ComplementoEN complementoEN = (ComplementoEN)session.Load (typeof(ComplementoEN), id);
                session.Delete (complementoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in ComplementoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ComplementoEN
public ComplementoEN ReadOID (int id
                              )
{
        ComplementoEN complementoEN = null;

        try
        {
                SessionInitializeTransaction ();
                complementoEN = (ComplementoEN)session.Get (typeof(ComplementoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in ComplementoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return complementoEN;
}

public System.Collections.Generic.IList<ComplementoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComplementoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComplementoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComplementoEN>();
                else
                        result = session.CreateCriteria (typeof(ComplementoEN)).List<ComplementoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in ComplementoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
