

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
 *      Definition of the class RegistradoCEN
 *
 */
public partial class RegistradoCEN
{
private IRegistradoCAD _IRegistradoCAD;

public RegistradoCEN()
{
        this._IRegistradoCAD = new RegistradoCAD ();
}

public RegistradoCEN(IRegistradoCAD _IRegistradoCAD)
{
        this._IRegistradoCAD = _IRegistradoCAD;
}

public IRegistradoCAD get_IRegistradoCAD ()
{
        return this._IRegistradoCAD;
}

public int New_ (string p_email, string p_nombre, String p_contrasenya, Nullable<DateTime> p_fecha_nac, int p_telefono, Nullable<DateTime> p_fechaRegistro)
{
        RegistradoEN registradoEN = null;
        int oid;

        //Initialized RegistradoEN
        registradoEN = new RegistradoEN ();
        registradoEN.Email = p_email;

        registradoEN.Nombre = p_nombre;

        registradoEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        registradoEN.Fecha_nac = p_fecha_nac;

        registradoEN.Telefono = p_telefono;

        registradoEN.FechaRegistro = p_fechaRegistro;

        //Call to RegistradoCAD

        oid = _IRegistradoCAD.New_ (registradoEN);
        return oid;
}

public void Modify (int p_Registrado_OID, string p_email, string p_nombre, String p_contrasenya, Nullable<DateTime> p_fecha_nac, int p_telefono, Nullable<DateTime> p_fechaRegistro)
{
        RegistradoEN registradoEN = null;

        //Initialized RegistradoEN
        registradoEN = new RegistradoEN ();
        registradoEN.Id = p_Registrado_OID;
        registradoEN.Email = p_email;
        registradoEN.Nombre = p_nombre;
        registradoEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        registradoEN.Fecha_nac = p_fecha_nac;
        registradoEN.Telefono = p_telefono;
        registradoEN.FechaRegistro = p_fechaRegistro;
        //Call to RegistradoCAD

        _IRegistradoCAD.Modify (registradoEN);
}

public void Destroy (int id
                     )
{
        _IRegistradoCAD.Destroy (id);
}

public RegistradoEN ReadOID (int id
                             )
{
        RegistradoEN registradoEN = null;

        registradoEN = _IRegistradoCAD.ReadOID (id);
        return registradoEN;
}

public System.Collections.Generic.IList<RegistradoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RegistradoEN> list = null;

        list = _IRegistradoCAD.ReadAll (first, size);
        return list;
}
}
}
