

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
 *      Definition of the class AdminCEN
 *
 */
public partial class AdminCEN
{
private IAdminCAD _IAdminCAD;

public AdminCEN()
{
        this._IAdminCAD = new AdminCAD ();
}

public AdminCEN(IAdminCAD _IAdminCAD)
{
        this._IAdminCAD = _IAdminCAD;
}

public IAdminCAD get_IAdminCAD ()
{
        return this._IAdminCAD;
}

public string New_ (string p_email, string p_nombre, String p_contrasenya, Nullable<DateTime> p_fecha_nac, int p_telefono)
{
        AdminEN adminEN = null;
        string oid;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Email = p_email;

        adminEN.Nombre = p_nombre;

        adminEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

        adminEN.Fecha_nac = p_fecha_nac;

        adminEN.Telefono = p_telefono;

        //Call to AdminCAD

        oid = _IAdminCAD.New_ (adminEN);
        return oid;
}

public void Modify (string p_Admin_OID, string p_nombre, String p_contrasenya, Nullable<DateTime> p_fecha_nac, int p_telefono)
{
        AdminEN adminEN = null;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Email = p_Admin_OID;
        adminEN.Nombre = p_nombre;
        adminEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        adminEN.Fecha_nac = p_fecha_nac;
        adminEN.Telefono = p_telefono;
        //Call to AdminCAD

        _IAdminCAD.Modify (adminEN);
}

public void Destroy (string email
                     )
{
        _IAdminCAD.Destroy (email);
}
}
}
