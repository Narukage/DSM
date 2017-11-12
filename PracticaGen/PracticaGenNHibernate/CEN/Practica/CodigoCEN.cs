

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
 *      Definition of the class CodigoCEN
 *
 */
public partial class CodigoCEN
{
private ICodigoCAD _ICodigoCAD;

public CodigoCEN()
{
        this._ICodigoCAD = new CodigoCAD ();
}

public CodigoCEN(ICodigoCAD _ICodigoCAD)
{
        this._ICodigoCAD = _ICodigoCAD;
}

public ICodigoCAD get_ICodigoCAD ()
{
        return this._ICodigoCAD;
}

public int New_ (int p_descuento, PracticaGenNHibernate.Enumerated.Practica.TipoCodigoEnum p_tipo)
{
        CodigoEN codigoEN = null;
        int oid;

        //Initialized CodigoEN
        codigoEN = new CodigoEN ();
        codigoEN.Descuento = p_descuento;

        codigoEN.Tipo = p_tipo;

        //Call to CodigoCAD

        oid = _ICodigoCAD.New_ (codigoEN);
        return oid;
}

public void Modify (int p_Codigo_OID, int p_descuento, PracticaGenNHibernate.Enumerated.Practica.TipoCodigoEnum p_tipo)
{
        CodigoEN codigoEN = null;

        //Initialized CodigoEN
        codigoEN = new CodigoEN ();
        codigoEN.Id = p_Codigo_OID;
        codigoEN.Descuento = p_descuento;
        codigoEN.Tipo = p_tipo;
        //Call to CodigoCAD

        _ICodigoCAD.Modify (codigoEN);
}

public void Destroy (int id
                     )
{
        _ICodigoCAD.Destroy (id);
}

public CodigoEN ReadOID (int id
                         )
{
        CodigoEN codigoEN = null;

        codigoEN = _ICodigoCAD.ReadOID (id);
        return codigoEN;
}

public System.Collections.Generic.IList<CodigoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CodigoEN> list = null;

        list = _ICodigoCAD.ReadAll (first, size);
        return list;
}
}
}
