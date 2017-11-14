
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
 * Clase Predefinida:
 *
 */

namespace PracticaGenNHibernate.CAD.Practica
{
public partial class PredefinidaCAD : BasicCAD, IPredefinidaCAD
{
public PredefinidaCAD() : base ()
{
}

public PredefinidaCAD(ISession sessionAux) : base (sessionAux)
{
}



public PredefinidaEN ReadOIDDefault (int id
                                     )
{
        PredefinidaEN predefinidaEN = null;

        try
        {
                SessionInitializeTransaction ();
                predefinidaEN = (PredefinidaEN)session.Get (typeof(PredefinidaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PredefinidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return predefinidaEN;
}

public System.Collections.Generic.IList<PredefinidaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PredefinidaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PredefinidaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PredefinidaEN>();
                        else
                                result = session.CreateCriteria (typeof(PredefinidaEN)).List<PredefinidaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PredefinidaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PredefinidaEN predefinida)
{
        try
        {
                SessionInitializeTransaction ();
                PredefinidaEN predefinidaEN = (PredefinidaEN)session.Load (typeof(PredefinidaEN), predefinida.Id);

                predefinidaEN.Descripcion = predefinida.Descripcion;

                session.Update (predefinidaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PredefinidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PredefinidaEN predefinida)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (predefinida);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PredefinidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return predefinida.Id;
}

public void Modify (PredefinidaEN predefinida)
{
        try
        {
                SessionInitializeTransaction ();
                PredefinidaEN predefinidaEN = (PredefinidaEN)session.Load (typeof(PredefinidaEN), predefinida.Id);

                predefinidaEN.Precio = predefinida.Precio;


                predefinidaEN.Nombre = predefinida.Nombre;


                predefinidaEN.Foto = predefinida.Foto;


                predefinidaEN.NumVeces = predefinida.NumVeces;


                predefinidaEN.Tamaño = predefinida.Tamaño;


                predefinidaEN.Masa = predefinida.Masa;


                predefinidaEN.Descripcion = predefinida.Descripcion;

                session.Update (predefinidaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PredefinidaCAD.", ex);
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
                PredefinidaEN predefinidaEN = (PredefinidaEN)session.Load (typeof(PredefinidaEN), id);
                session.Delete (predefinidaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PredefinidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PredefinidaEN
public PredefinidaEN ReadOID (int id
                              )
{
        PredefinidaEN predefinidaEN = null;

        try
        {
                SessionInitializeTransaction ();
                predefinidaEN = (PredefinidaEN)session.Get (typeof(PredefinidaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PredefinidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return predefinidaEN;
}

public System.Collections.Generic.IList<PredefinidaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PredefinidaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PredefinidaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PredefinidaEN>();
                else
                        result = session.CreateCriteria (typeof(PredefinidaEN)).List<PredefinidaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PredefinidaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
