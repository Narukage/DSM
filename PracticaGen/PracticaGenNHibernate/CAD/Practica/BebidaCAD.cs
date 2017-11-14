
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
 * Clase Bebida:
 *
 */

namespace PracticaGenNHibernate.CAD.Practica
{
public partial class BebidaCAD : BasicCAD, IBebidaCAD
{
public BebidaCAD() : base ()
{
}

public BebidaCAD(ISession sessionAux) : base (sessionAux)
{
}



public BebidaEN ReadOIDDefault (int id
                                )
{
        BebidaEN bebidaEN = null;

        try
        {
                SessionInitializeTransaction ();
                bebidaEN = (BebidaEN)session.Get (typeof(BebidaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in BebidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return bebidaEN;
}

public System.Collections.Generic.IList<BebidaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<BebidaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(BebidaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<BebidaEN>();
                        else
                                result = session.CreateCriteria (typeof(BebidaEN)).List<BebidaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in BebidaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (BebidaEN bebida)
{
        try
        {
                SessionInitializeTransaction ();
                BebidaEN bebidaEN = (BebidaEN)session.Load (typeof(BebidaEN), bebida.Id);
                session.Update (bebidaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in BebidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (BebidaEN bebida)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (bebida);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in BebidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return bebida.Id;
}

public void Modify (BebidaEN bebida)
{
        try
        {
                SessionInitializeTransaction ();
                BebidaEN bebidaEN = (BebidaEN)session.Load (typeof(BebidaEN), bebida.Id);

                bebidaEN.Precio = bebida.Precio;


                bebidaEN.Nombre = bebida.Nombre;


                bebidaEN.Foto = bebida.Foto;


                bebidaEN.NumVeces = bebida.NumVeces;

                session.Update (bebidaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in BebidaCAD.", ex);
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
                BebidaEN bebidaEN = (BebidaEN)session.Load (typeof(BebidaEN), id);
                session.Delete (bebidaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in BebidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: BebidaEN
public BebidaEN ReadOID (int id
                         )
{
        BebidaEN bebidaEN = null;

        try
        {
                SessionInitializeTransaction ();
                bebidaEN = (BebidaEN)session.Get (typeof(BebidaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in BebidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return bebidaEN;
}

public System.Collections.Generic.IList<BebidaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<BebidaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(BebidaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<BebidaEN>();
                else
                        result = session.CreateCriteria (typeof(BebidaEN)).List<BebidaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in BebidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
