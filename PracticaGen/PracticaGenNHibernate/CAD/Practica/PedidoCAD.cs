
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
 * Clase Pedido:
 *
 */

namespace PracticaGenNHibernate.CAD.Practica
{
public partial class PedidoCAD : BasicCAD, IPedidoCAD
{
public PedidoCAD() : base ()
{
}

public PedidoCAD(ISession sessionAux) : base (sessionAux)
{
}



public PedidoEN ReadOIDDefault (int id
                                )
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PedidoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(PedidoEN)).List<PedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoEN pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), pedido.Id);

                pedidoEN.Estado = pedido.Estado;


                pedidoEN.Fecha = pedido.Fecha;


                pedidoEN.PrecioTotal = pedido.PrecioTotal;


                pedidoEN.TipoPago = pedido.TipoPago;





                pedidoEN.Confirmado = pedido.Confirmado;


                pedidoEN.Valoracion = pedido.Valoracion;


                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                if (pedido.Usuario != null) {
                        // Argumento OID y no colección.
                        pedido.Usuario = (PracticaGenNHibernate.EN.Practica.UsuarioEN)session.Load (typeof(PracticaGenNHibernate.EN.Practica.UsuarioEN), pedido.Usuario.Id);

                        pedido.Usuario.Pedido
                        .Add (pedido);
                }

                session.Save (pedido);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedido.Id;
}

public void Modify (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoEN pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), pedido.Id);

                pedidoEN.Estado = pedido.Estado;


                pedidoEN.Fecha = pedido.Fecha;


                pedidoEN.PrecioTotal = pedido.PrecioTotal;


                pedidoEN.TipoPago = pedido.TipoPago;


                pedidoEN.Confirmado = pedido.Confirmado;


                pedidoEN.Valoracion = pedido.Valoracion;

                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
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
                PedidoEN pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), id);
                session.Delete (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PedidoEN
public PedidoEN ReadOID (int id
                         )
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PedidoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PedidoEN>();
                else
                        result = session.CreateCriteria (typeof(PedidoEN)).List<PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AnyadirCodigo (int p_Pedido_OID, int p_codigo_OID)
{
        PracticaGenNHibernate.EN.Practica.PedidoEN pedidoEN = null;
        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), p_Pedido_OID);
                pedidoEN.Codigo = (PracticaGenNHibernate.EN.Practica.CodigoEN)session.Load (typeof(PracticaGenNHibernate.EN.Practica.CodigoEN), p_codigo_OID);

                pedidoEN.Codigo.Pedido.Add (pedidoEN);



                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void EliminarCodigo (int p_Pedido_OID, int p_codigo_OID)
{
        try
        {
                SessionInitializeTransaction ();
                PracticaGenNHibernate.EN.Practica.PedidoEN pedidoEN = null;
                pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), p_Pedido_OID);

                if (pedidoEN.Codigo.Id == p_codigo_OID) {
                        pedidoEN.Codigo = null;
                }
                else
                        throw new ModelException ("The identifier " + p_codigo_OID + " in p_codigo_OID you are trying to unrelationer, doesn't exist in PedidoEN");

                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public long PedidosMensuales (int ? p_mes)
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PedidoEN self where SELECT count(*) FROM PedidoEN as ped where Month(ped.Fecha) = :p_mes";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PedidoENpedidosMensualesHQL");
                query.SetParameter ("p_mes", p_mes);


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public long GetCodigosActivados ()
{
        long result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PedidoEN self where SELECT count(*) FROM PedidoEN as ped.Codigo.Numero !=null";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PedidoENgetCodigosActivadosHQL");


                result = query.UniqueResult<long>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> DevolverPedidosUsuario (string usuario)
{
        System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PedidoEN self where FROM PedidoEN as ped where ped.Usuario.Email = :usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PedidoENdevolverPedidosUsuarioHQL");
                query.SetParameter ("usuario", usuario);

                result = query.List<PracticaGenNHibernate.EN.Practica.PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AnyadirLineaPedido (int p_Pedido_OID, System.Collections.Generic.IList<int> p_lineaPedido_OIDs)
{
        PracticaGenNHibernate.EN.Practica.PedidoEN pedidoEN = null;
        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), p_Pedido_OID);
                PracticaGenNHibernate.EN.Practica.LineaPedidoEN lineaPedidoENAux = null;
                if (pedidoEN.LineaPedido == null) {
                        pedidoEN.LineaPedido = new System.Collections.Generic.List<PracticaGenNHibernate.EN.Practica.LineaPedidoEN>();
                }

                foreach (int item in p_lineaPedido_OIDs) {
                        lineaPedidoENAux = new PracticaGenNHibernate.EN.Practica.LineaPedidoEN ();
                        lineaPedidoENAux = (PracticaGenNHibernate.EN.Practica.LineaPedidoEN)session.Load (typeof(PracticaGenNHibernate.EN.Practica.LineaPedidoEN), item);
                        lineaPedidoENAux.Pedido = pedidoEN;

                        pedidoEN.LineaPedido.Add (lineaPedidoENAux);
                }


                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void EliminarLineaPedido (int p_Pedido_OID, System.Collections.Generic.IList<int> p_lineaPedido_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                PracticaGenNHibernate.EN.Practica.PedidoEN pedidoEN = null;
                pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), p_Pedido_OID);

                PracticaGenNHibernate.EN.Practica.LineaPedidoEN lineaPedidoENAux = null;
                if (pedidoEN.LineaPedido != null) {
                        foreach (int item in p_lineaPedido_OIDs) {
                                lineaPedidoENAux = (PracticaGenNHibernate.EN.Practica.LineaPedidoEN)session.Load (typeof(PracticaGenNHibernate.EN.Practica.LineaPedidoEN), item);
                                if (pedidoEN.LineaPedido.Contains (lineaPedidoENAux) == true) {
                                        pedidoEN.LineaPedido.Remove (lineaPedidoENAux);
                                        lineaPedidoENAux.Pedido = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_lineaPedido_OIDs you are trying to unrelationer, doesn't exist in PedidoEN");
                        }
                }

                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> BuscarPedido (int ? id)
{
        System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PedidoEN self where FROM PedidoEN as ped where ped.Id= :id";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PedidoENbuscarPedidoHQL");
                query.SetParameter ("id", id);

                result = query.List<PracticaGenNHibernate.EN.Practica.PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AnyadirDireccion (int p_Pedido_OID, int p_direccion_OID)
{
        PracticaGenNHibernate.EN.Practica.PedidoEN pedidoEN = null;
        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), p_Pedido_OID);
                pedidoEN.Direccion = (PracticaGenNHibernate.EN.Practica.DireccionEN)session.Load (typeof(PracticaGenNHibernate.EN.Practica.DireccionEN), p_direccion_OID);

                pedidoEN.Direccion.Pedido.Add (pedidoEN);



                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void EliminarDireccion (int p_Pedido_OID, int p_direccion_OID)
{
        try
        {
                SessionInitializeTransaction ();
                PracticaGenNHibernate.EN.Practica.PedidoEN pedidoEN = null;
                pedidoEN = (PedidoEN)session.Load (typeof(PedidoEN), p_Pedido_OID);

                if (pedidoEN.Direccion.Id == p_direccion_OID) {
                        pedidoEN.Direccion = null;
                }
                else
                        throw new ModelException ("The identifier " + p_direccion_OID + " in p_direccion_OID you are trying to unrelationer, doesn't exist in PedidoEN");

                session.Update (pedidoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PedidoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
