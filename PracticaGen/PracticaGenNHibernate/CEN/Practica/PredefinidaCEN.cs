

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

public int New_ (double p_precio, string p_nombre, string p_foto, int p_numVeces, PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum p_tamaño, PracticaGenNHibernate.Enumerated.Practica.TipoMasaEnum p_masa, string p_descripcion)
{
        PredefinidaEN predefinidaEN = null;
        int oid;

        //Initialized PredefinidaEN
        predefinidaEN = new PredefinidaEN ();
        predefinidaEN.Precio = p_precio;

        predefinidaEN.Nombre = p_nombre;

        predefinidaEN.Foto = p_foto;

        predefinidaEN.NumVeces = p_numVeces;

        predefinidaEN.Tamaño = p_tamaño;

        predefinidaEN.Masa = p_masa;

        predefinidaEN.Descripcion = p_descripcion;

        //Call to PredefinidaCAD

        oid = _IPredefinidaCAD.New_ (predefinidaEN);
        return oid;
}

public void Modify (int p_Predefinida_OID, double p_precio, string p_nombre, string p_foto, int p_numVeces, PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum p_tamaño, PracticaGenNHibernate.Enumerated.Practica.TipoMasaEnum p_masa, string p_descripcion)
{
        PredefinidaEN predefinidaEN = null;

        //Initialized PredefinidaEN
        predefinidaEN = new PredefinidaEN ();
        predefinidaEN.Id = p_Predefinida_OID;
        predefinidaEN.Precio = p_precio;
        predefinidaEN.Nombre = p_nombre;
        predefinidaEN.Foto = p_foto;
        predefinidaEN.NumVeces = p_numVeces;
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

public PredefinidaEN ReadOID (int id
                              )
{
        PredefinidaEN predefinidaEN = null;

        predefinidaEN = _IPredefinidaCAD.ReadOID (id);
        return predefinidaEN;
}

public System.Collections.Generic.IList<PredefinidaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PredefinidaEN> list = null;

        list = _IPredefinidaCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PredefinidaEN> TopVentas ()
{
        return _IPredefinidaCAD.TopVentas ();
}
}
}
