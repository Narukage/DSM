
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
 * Clase Pizza:
 *
 */

namespace PracticaGenNHibernate.CAD.Practica
{
public partial class PizzaCAD : BasicCAD, IPizzaCAD
{
public PizzaCAD() : base ()
{
}

public PizzaCAD(ISession sessionAux) : base (sessionAux)
{
}



public PizzaEN ReadOIDDefault (int id
                               )
{
        PizzaEN pizzaEN = null;

        try
        {
                SessionInitializeTransaction ();
                pizzaEN = (PizzaEN)session.Get (typeof(PizzaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PizzaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pizzaEN;
}

public System.Collections.Generic.IList<PizzaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PizzaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PizzaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PizzaEN>();
                        else
                                result = session.CreateCriteria (typeof(PizzaEN)).List<PizzaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PizzaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PizzaEN pizza)
{
        try
        {
                SessionInitializeTransaction ();
                PizzaEN pizzaEN = (PizzaEN)session.Load (typeof(PizzaEN), pizza.Id);

                pizzaEN.Tamaño = pizza.Tamaño;


                pizzaEN.Masa = pizza.Masa;

                session.Update (pizzaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PizzaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PizzaEN pizza)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (pizza);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PizzaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pizza.Id;
}

public void Modify (PizzaEN pizza)
{
        try
        {
                SessionInitializeTransaction ();
                PizzaEN pizzaEN = (PizzaEN)session.Load (typeof(PizzaEN), pizza.Id);

                pizzaEN.Precio = pizza.Precio;


                pizzaEN.Nombre = pizza.Nombre;


                pizzaEN.Foto = pizza.Foto;


                pizzaEN.Tamaño = pizza.Tamaño;


                pizzaEN.Masa = pizza.Masa;

                session.Update (pizzaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PizzaCAD.", ex);
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
                PizzaEN pizzaEN = (PizzaEN)session.Load (typeof(PizzaEN), id);
                session.Delete (pizzaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PizzaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<PizzaEN> GetTodosProductos (int first, int size)
{
        System.Collections.Generic.IList<PizzaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PizzaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PizzaEN>();
                else
                        result = session.CreateCriteria (typeof(PizzaEN)).List<PizzaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PizzaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: ReadOID
//Con e: PizzaEN
public PizzaEN ReadOID (int id
                        )
{
        PizzaEN pizzaEN = null;

        try
        {
                SessionInitializeTransaction ();
                pizzaEN = (PizzaEN)session.Get (typeof(PizzaEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PizzaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pizzaEN;
}

public System.Collections.Generic.IList<PizzaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PizzaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PizzaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PizzaEN>();
                else
                        result = session.CreateCriteria (typeof(PizzaEN)).List<PizzaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in PizzaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
