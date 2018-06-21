
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
 * Clase Registrado:
 *
 */

namespace PracticaGenNHibernate.CAD.Practica
{
public partial class RegistradoCAD : BasicCAD, IRegistradoCAD
{
public RegistradoCAD() : base ()
{
}

public RegistradoCAD(ISession sessionAux) : base (sessionAux)
{
}



public RegistradoEN ReadOIDDefault (int id
                                    )
{
        RegistradoEN registradoEN = null;

        try
        {
                SessionInitializeTransaction ();
                registradoEN = (RegistradoEN)session.Get (typeof(RegistradoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return registradoEN;
}

public System.Collections.Generic.IList<RegistradoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RegistradoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RegistradoEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RegistradoEN>();
                        else
                                result = session.CreateCriteria (typeof(RegistradoEN)).List<RegistradoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RegistradoEN registrado)
{
        try
        {
                SessionInitializeTransaction ();
                RegistradoEN registradoEN = (RegistradoEN)session.Load (typeof(RegistradoEN), registrado.Id);

                registradoEN.Email = registrado.Email;


                registradoEN.Nombre = registrado.Nombre;


                registradoEN.Contrasenya = registrado.Contrasenya;


                registradoEN.Fecha_nac = registrado.Fecha_nac;


                registradoEN.Telefono = registrado.Telefono;


                registradoEN.FechaRegistro = registrado.FechaRegistro;

                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (RegistradoEN registrado)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (registrado);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return registrado.Id;
}

public void Modify (RegistradoEN registrado)
{
        try
        {
                SessionInitializeTransaction ();
                RegistradoEN registradoEN = (RegistradoEN)session.Load (typeof(RegistradoEN), registrado.Id);

                registradoEN.Email = registrado.Email;


                registradoEN.Nombre = registrado.Nombre;


                registradoEN.Contrasenya = registrado.Contrasenya;


                registradoEN.Fecha_nac = registrado.Fecha_nac;


                registradoEN.Telefono = registrado.Telefono;


                registradoEN.FechaRegistro = registrado.FechaRegistro;

                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
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
                RegistradoEN registradoEN = (RegistradoEN)session.Load (typeof(RegistradoEN), id);
                session.Delete (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: RegistradoEN
public RegistradoEN ReadOID (int id
                             )
{
        RegistradoEN registradoEN = null;

        try
        {
                SessionInitializeTransaction ();
                registradoEN = (RegistradoEN)session.Get (typeof(RegistradoEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return registradoEN;
}

public System.Collections.Generic.IList<RegistradoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RegistradoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(RegistradoEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<RegistradoEN>();
                else
                        result = session.CreateCriteria (typeof(RegistradoEN)).List<RegistradoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PracticaGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PracticaGenNHibernate.Exceptions.DataLayerException ("Error in RegistradoCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
