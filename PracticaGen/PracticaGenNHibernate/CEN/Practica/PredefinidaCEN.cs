

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaGenNHibernate.Exceptions;

using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;


namespace PracticaGenNHibernate.CEN.Practica
{
/*
 *      Definition of the class PredefinidaCEN
 *
 */
public partial class PredefinidaCEN
{
private IPredefinidaCAD _IPredefinidaCAD;

public PredefinidaCEN()
{
        this._IPredefinidaCAD = new PredefinidaCAD ();
}

public PredefinidaCEN(IPredefinidaCAD _IPredefinidaCAD)
{
        this._IPredefinidaCAD = _IPredefinidaCAD;
}

public IPredefinidaCAD get_IPredefinidaCAD ()
{
        return this._IPredefinidaCAD;
}

public int New_ (float p_precio, string p_nombre, string p_foto, int p_tamaño, int p_masa, string p_descripcion)
{
        PredefinidaEN predefinidaEN = null;
        int oid;

        //Initialized PredefinidaEN
        predefinidaEN = new PredefinidaEN ();
        predefinidaEN.Precio = p_precio;

        predefinidaEN.Nombre = p_nombre;

        predefinidaEN.Foto = p_foto;

        predefinidaEN.Tamaño = p_tamaño;

        predefinidaEN.Masa = p_masa;

        predefinidaEN.Descripcion = p_descripcion;

        //Call to PredefinidaCAD

        oid = _IPredefinidaCAD.New_ (predefinidaEN);
        return oid;
}

public void Modify (int p_Predefinida_OID, float p_precio, string p_nombre, string p_foto, int p_tamaño, int p_masa, string p_descripcion)
{
        PredefinidaEN predefinidaEN = null;

        //Initialized PredefinidaEN
        predefinidaEN = new PredefinidaEN ();
        predefinidaEN.Id = p_Predefinida_OID;
        predefinidaEN.Precio = p_precio;
        predefinidaEN.Nombre = p_nombre;
        predefinidaEN.Foto = p_foto;
        predefinidaEN.Tamaño = p_tamaño;
        predefinidaEN.Masa = p_masa;
        predefinidaEN.Descripcion = p_descripcion;
        //Call to PredefinidaCAD

        _IPredefinidaCAD.Modify (predefinidaEN);
}

public void Destroy (int id
                     )
{
        _IPredefinidaCAD.Destroy (id);
}

public System.Collections.Generic.IList<PredefinidaEN> GetTodosProductos (int first, int size)
{
        System.Collections.Generic.IList<PredefinidaEN> list = null;

        list = _IPredefinidaCAD.GetTodosProductos (first, size);
        return list;
}
}
}
