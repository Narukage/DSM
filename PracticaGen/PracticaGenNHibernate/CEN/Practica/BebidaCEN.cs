

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
 *      Definition of the class BebidaCEN
 *
 */
public partial class BebidaCEN
{
private IBebidaCAD _IBebidaCAD;

public BebidaCEN()
{
        this._IBebidaCAD = new BebidaCAD ();
}

public BebidaCEN(IBebidaCAD _IBebidaCAD)
{
        this._IBebidaCAD = _IBebidaCAD;
}

public IBebidaCAD get_IBebidaCAD ()
{
        return this._IBebidaCAD;
}

public int New_ (double p_precio, string p_nombre, string p_foto, int p_numVeces)
{
        BebidaEN bebidaEN = null;
        int oid;

        //Initialized BebidaEN
        bebidaEN = new BebidaEN ();
        bebidaEN.Precio = p_precio;

        bebidaEN.Nombre = p_nombre;

        bebidaEN.Foto = p_foto;

        bebidaEN.NumVeces = p_numVeces;

        //Call to BebidaCAD

        oid = _IBebidaCAD.New_ (bebidaEN);
        return oid;
}

public void Modify (int p_Bebida_OID, double p_precio, string p_nombre, string p_foto, int p_numVeces)
{
        BebidaEN bebidaEN = null;

        //Initialized BebidaEN
        bebidaEN = new BebidaEN ();
        bebidaEN.Id = p_Bebida_OID;
        bebidaEN.Precio = p_precio;
        bebidaEN.Nombre = p_nombre;
        bebidaEN.Foto = p_foto;
        bebidaEN.NumVeces = p_numVeces;
        //Call to BebidaCAD

        _IBebidaCAD.Modify (bebidaEN);
}

public void Destroy (int id
                     )
{
        _IBebidaCAD.Destroy (id);
}

public BebidaEN ReadOID (int id
                         )
{
        BebidaEN bebidaEN = null;

        bebidaEN = _IBebidaCAD.ReadOID (id);
        return bebidaEN;
}

public System.Collections.Generic.IList<BebidaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<BebidaEN> list = null;

        list = _IBebidaCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.BebidaEN> TopVentas ()
{
        return _IBebidaCAD.TopVentas ();
}
}
}
