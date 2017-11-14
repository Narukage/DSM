
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
 * Clase LineaPedido:
 *
 */

namespace PracticaGenNHibernate.CAD.Practica
{
public partial class LineaPedidoCAD : BasicCAD, ILineaPedidoCAD
{
public LineaPedidoCAD() : base ()
{
}

public LineaPedidoCAD(ISession sessionAux) : base (sessionAux)
{
}



public LineaPedidoEN ReadOIDDefault (int id
                                     )
{
        LineaPedidoEN lineaPedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaPedidoEN = (LineaPedidoEN)session.Get (typeof(LineaPedidoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedidoEN;
}

public System.Collections.Generic.IList<LineaPedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LineaPedidoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<LineaPedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(LineaPedidoEN)).List<LineaPedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LineaPedidoEN lineaPedido)
{
        try
        {
                SessionInitializeTransaction ();
                LineaPedidoEN lineaPedidoEN = (LineaPedidoEN)session.Load (typeof(LineaPedidoEN), lineaPedido.Id);



                lineaPedidoEN.Cantidad = lineaPedido.Cantidad;


                lineaPedidoEN.Valoracion = lineaPedido.Valoracion;

                session.Update (lineaPedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (LineaPedidoEN lineaPedido)
{
        try
        {
                SessionInitializeTransaction ();
                if (lineaPedido.Producto != null) {
                        // Argumento OID y no colección.
                        lineaPedido.Producto = (PracticaGenNHibernate.EN.Practica.ProductoEN)session.Load (typeof(PracticaGenNHibernate.EN.Practica.ProductoEN), lineaPedido.Producto.Id);

                        lineaPedido.Producto.LineaPedido
                        .Add (lineaPedido);
                }
                if (lineaPedido.Pedido != null) {
                        // Argumento OID y no colección.
                        lineaPedido.Pedido = (PracticaGenNHibernate.EN.Practica.PedidoEN)session.Load (typeof(PracticaGenNHibernate.EN.Practica.PedidoEN), lineaPedido.Pedido.Id);

                        lineaPedido.Pedido.LineaPedido
                        .Add (lineaPedido);
                }

                session.Save (lineaPedido);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedido.Id;
}

public void Modify (LineaPedidoEN lineaPedido)
{
        try
        {
                SessionInitializeTransaction ();
                LineaPedidoEN lineaPedidoEN = (LineaPedidoEN)session.Load (typeof(LineaPedidoEN), lineaPedido.Id);

                lineaPedidoEN.Cantidad = lineaPedido.Cantidad;


                lineaPedidoEN.Valoracion = lineaPedido.Valoracion;

                session.Update (lineaPedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
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
                LineaPedidoEN lineaPedidoEN = (LineaPedidoEN)session.Load (typeof(LineaPedidoEN), id);
                session.Delete (lineaPedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: LineaPedidoEN
public LineaPedidoEN ReadOID (int id
                              )
{
        LineaPedidoEN lineaPedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                lineaPedidoEN = (LineaPedidoEN)session.Get (typeof(LineaPedidoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return lineaPedidoEN;
}

public System.Collections.Generic.IList<LineaPedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<LineaPedidoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LineaPedidoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<LineaPedidoEN>();
                else
                        result = session.CreateCriteria (typeof(LineaPedidoEN)).List<LineaPedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> TopVentas ()
{
        System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM LineaPedidoEN self where SELECT Producto, count(*) FROM LineaPedidoEN ";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("LineaPedidoENtopVentasHQL");

                result = query.List<PracticaGenNHibernate.EN.Practica.LineaPedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in LineaPedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
