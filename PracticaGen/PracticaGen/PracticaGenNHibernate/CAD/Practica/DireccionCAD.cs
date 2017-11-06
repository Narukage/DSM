
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
 * Clase Direccion:
 *
 */

namespace PracticaGenNHibernate.CAD.Practica
{
public partial class DireccionCAD : BasicCAD, IDireccionCAD
{
public DireccionCAD() : base ()
{
}

public DireccionCAD(ISession sessionAux) : base (sessionAux)
{
}



public DireccionEN ReadOIDDefault (int id
                                   )
{
        DireccionEN direccionEN = null;

        try
        {
                SessionInitializeTransaction ();
                direccionEN = (DireccionEN)session.Get (typeof(DireccionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in DireccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return direccionEN;
}

public System.Collections.Generic.IList<DireccionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<DireccionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(DireccionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<DireccionEN>();
                        else
                                result = session.CreateCriteria (typeof(DireccionEN)).List<DireccionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in DireccionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (DireccionEN direccion)
{
        try
        {
                SessionInitializeTransaction ();
                DireccionEN direccionEN = (DireccionEN)session.Load (typeof(DireccionEN), direccion.Id);

                direccionEN.Localidad = direccion.Localidad;


                direccionEN.Provincia = direccion.Provincia;


                direccionEN.Calle = direccion.Calle;


                direccionEN.Codp = direccion.Codp;



                direccionEN.Numero = direccion.Numero;

                session.Update (direccionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in DireccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (DireccionEN direccion)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (direccion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in DireccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return direccion.Id;
}

public void Modify (DireccionEN direccion)
{
        try
        {
                SessionInitializeTransaction ();
                DireccionEN direccionEN = (DireccionEN)session.Load (typeof(DireccionEN), direccion.Id);

                direccionEN.Localidad = direccion.Localidad;


                direccionEN.Provincia = direccion.Provincia;


                direccionEN.Calle = direccion.Calle;


                direccionEN.Codp = direccion.Codp;


                direccionEN.Numero = direccion.Numero;

                session.Update (direccionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in DireccionCAD.", ex);
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
                DireccionEN direccionEN = (DireccionEN)session.Load (typeof(DireccionEN), id);
                session.Delete (direccionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in DireccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: DireccionEN
public DireccionEN ReadOID (int id
                            )
{
        DireccionEN direccionEN = null;

        try
        {
                SessionInitializeTransaction ();
                direccionEN = (DireccionEN)session.Get (typeof(DireccionEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in DireccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return direccionEN;
}

public System.Collections.Generic.IList<DireccionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<DireccionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(DireccionEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<DireccionEN>();
                else
                        result = session.CreateCriteria (typeof(DireccionEN)).List<DireccionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in DireccionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
