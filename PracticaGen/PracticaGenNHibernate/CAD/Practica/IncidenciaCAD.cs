
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
 * Clase Incidencia:
 *
 */

namespace PracticaGenNHibernate.CAD.Practica
{
public partial class IncidenciaCAD : BasicCAD, IIncidenciaCAD
{
public IncidenciaCAD() : base ()
{
}

public IncidenciaCAD(ISession sessionAux) : base (sessionAux)
{
}



public IncidenciaEN ReadOIDDefault (int id
                                    )
{
        IncidenciaEN incidenciaEN = null;

        try
        {
                SessionInitializeTransaction ();
                incidenciaEN = (IncidenciaEN)session.Get (typeof(IncidenciaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in IncidenciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return incidenciaEN;
}

public System.Collections.Generic.IList<IncidenciaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<IncidenciaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(IncidenciaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<IncidenciaEN>();
                        else
                                result = session.CreateCriteria (typeof(IncidenciaEN)).List<IncidenciaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in IncidenciaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (IncidenciaEN incidencia)
{
        try
        {
                SessionInitializeTransaction ();
                IncidenciaEN incidenciaEN = (IncidenciaEN)session.Load (typeof(IncidenciaEN), incidencia.Id);

                incidenciaEN.Descripcion = incidencia.Descripcion;


                incidenciaEN.Estado = incidencia.Estado;



                incidenciaEN.Fecha = incidencia.Fecha;

                session.Update (incidenciaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in IncidenciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (IncidenciaEN incidencia)
{
        try
        {
                SessionInitializeTransaction ();
                if (incidencia.Usuario != null) {
                        // Argumento OID y no colección.
                        incidencia.Usuario = (PracticaGenNHibernate.EN.Practica.UsuarioEN)session.Load (typeof(PracticaGenNHibernate.EN.Practica.UsuarioEN), incidencia.Usuario.Email);

                        incidencia.Usuario.Incidencia
                        .Add (incidencia);
                }

                session.Save (incidencia);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in IncidenciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return incidencia.Id;
}

public void Modify (IncidenciaEN incidencia)
{
        try
        {
                SessionInitializeTransaction ();
                IncidenciaEN incidenciaEN = (IncidenciaEN)session.Load (typeof(IncidenciaEN), incidencia.Id);

                incidenciaEN.Descripcion = incidencia.Descripcion;


                incidenciaEN.Estado = incidencia.Estado;


                incidenciaEN.Fecha = incidencia.Fecha;

                session.Update (incidenciaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in IncidenciaCAD.", ex);
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
                IncidenciaEN incidenciaEN = (IncidenciaEN)session.Load (typeof(IncidenciaEN), id);
                session.Delete (incidenciaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in IncidenciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: IncidenciaEN
public IncidenciaEN ReadOID (int id
                             )
{
        IncidenciaEN incidenciaEN = null;

        try
        {
                SessionInitializeTransaction ();
                incidenciaEN = (IncidenciaEN)session.Get (typeof(IncidenciaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in IncidenciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return incidenciaEN;
}

public System.Collections.Generic.IList<IncidenciaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<IncidenciaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(IncidenciaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<IncidenciaEN>();
                else
                        result = session.CreateCriteria (typeof(IncidenciaEN)).List<IncidenciaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in IncidenciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public long IncidenciasMes (Nullable<DateTime> p_fecha)
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM IncidenciaEN self where SELECT count(*) FROM IncidenciaEN as inc where inc.Fecha >= :p_fecha";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("IncidenciaENIncidenciasMesHQL");
                query.SetParameter ("p_fecha", p_fecha);


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in IncidenciaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
