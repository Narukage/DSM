

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
 *      Definition of the class ComplementoCEN
 *
 */
public partial class ComplementoCEN
{
private IComplementoCAD _IComplementoCAD;

public ComplementoCEN()
{
        this._IComplementoCAD = new ComplementoCAD ();
}

public ComplementoCEN(IComplementoCAD _IComplementoCAD)
{
        this._IComplementoCAD = _IComplementoCAD;
}

public IComplementoCAD get_IComplementoCAD ()
{
        return this._IComplementoCAD;
}

public int New_ (double p_precio, string p_nombre, string p_foto, int p_numVeces)
{
        ComplementoEN complementoEN = null;
        int oid;

        //Initialized ComplementoEN
        complementoEN = new ComplementoEN ();
        complementoEN.Precio = p_precio;

        complementoEN.Nombre = p_nombre;

        complementoEN.Foto = p_foto;

        complementoEN.NumVeces = p_numVeces;

        //Call to ComplementoCAD

        oid = _IComplementoCAD.New_ (complementoEN);
        return oid;
}

public void Modify (int p_Complemento_OID, double p_precio, string p_nombre, string p_foto, int p_numVeces)
{
        ComplementoEN complementoEN = null;

        //Initialized ComplementoEN
        complementoEN = new ComplementoEN ();
        complementoEN.Id = p_Complemento_OID;
        complementoEN.Precio = p_precio;
        complementoEN.Nombre = p_nombre;
        complementoEN.Foto = p_foto;
        complementoEN.NumVeces = p_numVeces;
        //Call to ComplementoCAD

        _IComplementoCAD.Modify (complementoEN);
}

public void Destroy (int id
                     )
{
        _IComplementoCAD.Destroy (id);
}

public ComplementoEN ReadOID (int id
                              )
{
        ComplementoEN complementoEN = null;

        complementoEN = _IComplementoCAD.ReadOID (id);
        return complementoEN;
}

public System.Collections.Generic.IList<ComplementoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComplementoEN> list = null;

        list = _IComplementoCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.ComplementoEN> TopVentas ()
{
        return _IComplementoCAD.TopVentas ();
}
}
}
