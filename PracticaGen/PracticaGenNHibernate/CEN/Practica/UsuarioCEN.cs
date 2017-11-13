

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
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public string New_ (string p_email, string p_nombre, String p_contrasenya, Nullable<DateTime> p_fecha_nac, int p_telefono, Nullable<DateTime> p_fechaRegistro)
{
        UsuarioEN usuarioEN = null;
        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_email;

        usuarioEN.Nombre = p_nombre;

        usuarioEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        usuarioEN.Fecha_nac = p_fecha_nac;

        usuarioEN.Telefono = p_telefono;

        usuarioEN.FechaRegistro = p_fechaRegistro;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.New_ (usuarioEN);
        return oid;
}

public void Modify (string p_Usuario_OID, string p_nombre, String p_contrasenya, Nullable<DateTime> p_fecha_nac, int p_telefono, Nullable<DateTime> p_fechaRegistro)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_Usuario_OID;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        usuarioEN.Fecha_nac = p_fecha_nac;
        usuarioEN.Telefono = p_telefono;
        usuarioEN.FechaRegistro = p_fechaRegistro;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Destroy (string email
                     )
{
        _IUsuarioCAD.Destroy (email);
}

public void AnyadirDireccion (string p_Usuario_OID, System.Collections.Generic.IList<int> p_direccion_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.AnyadirDireccion (p_Usuario_OID, p_direccion_OIDs);
}
public void EliminarDireccion (string p_Usuario_OID, System.Collections.Generic.IList<int> p_direccion_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.EliminarDireccion (p_Usuario_OID, p_direccion_OIDs);
}
public System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.UsuarioEN> GetUsuario (string p_nombre)
{
        return _IUsuarioCAD.GetUsuario (p_nombre);
}
public UsuarioEN ReadOID (string email
                          )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.ReadOID (email);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioCAD.ReadAll (first, size);
        return list;
}
public long UsuariosMes (Nullable<DateTime> p_fecha)
{
        return _IUsuarioCAD.UsuariosMes (p_fecha);
}
}
}
