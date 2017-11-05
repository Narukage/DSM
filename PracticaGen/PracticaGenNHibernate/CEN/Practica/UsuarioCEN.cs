

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

public string New_ (string p_email, string p_nombre, String p_contrasenya, Nullable<DateTime> p_fecha_nac, int p_telefono, string p_admin, System.Collections.Generic.IList<int> p_direccion)
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


        if (p_admin != null) {
                // El argumento p_admin -> Property admin es oid = false
                // Lista de oids email
                usuarioEN.Admin = new PracticaGenNHibernate.EN.Practica.AdminEN ();
                usuarioEN.Admin.Email = p_admin;
        }


        usuarioEN.Direccion = new System.Collections.Generic.List<PracticaGenNHibernate.EN.Practica.DireccionEN>();
        if (p_direccion != null) {
                foreach (int item in p_direccion) {
                        PracticaGenNHibernate.EN.Practica.DireccionEN en = new PracticaGenNHibernate.EN.Practica.DireccionEN ();
                        en.Id = item;
                        usuarioEN.Direccion.Add (en);
                }
        }

        else{
                usuarioEN.Direccion = new System.Collections.Generic.List<PracticaGenNHibernate.EN.Practica.DireccionEN>();
        }

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.New_ (usuarioEN);
        return oid;
}

public void Modify (string p_Usuario_OID, string p_nombre, String p_contrasenya, Nullable<DateTime> p_fecha_nac, int p_telefono)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Email = p_Usuario_OID;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        usuarioEN.Fecha_nac = p_fecha_nac;
        usuarioEN.Telefono = p_telefono;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Destroy (string email
                     )
{
        _IUsuarioCAD.Destroy (email);
}

public System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.UsuarioEN> GetUsuario (string p_nombre)
{
        return _IUsuarioCAD.GetUsuario (p_nombre);
}
}
}
