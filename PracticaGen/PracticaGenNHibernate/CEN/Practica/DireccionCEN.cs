

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
 *      Definition of the class DireccionCEN
 *
 */
public partial class DireccionCEN
{
private IDireccionCAD _IDireccionCAD;

public DireccionCEN()
{
        this._IDireccionCAD = new DireccionCAD ();
}

public DireccionCEN(IDireccionCAD _IDireccionCAD)
{
        this._IDireccionCAD = _IDireccionCAD;
}

public IDireccionCAD get_IDireccionCAD ()
{
        return this._IDireccionCAD;
}

public int New_ (string p_localidad, string p_provincia, string p_calle, int p_codp, int p_numero)
{
        DireccionEN direccionEN = null;
        int oid;

        //Initialized DireccionEN
        direccionEN = new DireccionEN ();
        direccionEN.Localidad = p_localidad;

        direccionEN.Provincia = p_provincia;

        direccionEN.Calle = p_calle;

        direccionEN.Codp = p_codp;

        direccionEN.Numero = p_numero;

        //Call to DireccionCAD

        oid = _IDireccionCAD.New_ (direccionEN);
        return oid;
}

public void Modify (int p_Direccion_OID, string p_localidad, string p_provincia, string p_calle, int p_codp, int p_numero)
{
        DireccionEN direccionEN = null;

        //Initialized DireccionEN
        direccionEN = new DireccionEN ();
        direccionEN.Id = p_Direccion_OID;
        direccionEN.Localidad = p_localidad;
        direccionEN.Provincia = p_provincia;
        direccionEN.Calle = p_calle;
        direccionEN.Codp = p_codp;
        direccionEN.Numero = p_numero;
        //Call to DireccionCAD

        _IDireccionCAD.Modify (direccionEN);
}

public void Destroy (int id
                     )
{
        _IDireccionCAD.Destroy (id);
}

public DireccionEN ReadOID (int id
                            )
{
        DireccionEN direccionEN = null;

        direccionEN = _IDireccionCAD.ReadOID (id);
        return direccionEN;
}

public System.Collections.Generic.IList<DireccionEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<DireccionEN> list = null;

        list = _IDireccionCAD.ReadAll (first, size);
        return list;
}
}
}
