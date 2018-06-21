
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaGenNHibernate.Exceptions;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_Usuario_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class UsuarioCEN
{
public bool Login (string p_usuario, string p_contrasenya)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_Usuario_login) ENABLED START*/

        bool result = false;

        if (UsuarioPorEmail (p_usuario).Count != 0) {
                UsuarioEN en = _IUsuarioCAD.ReadOIDDefault (UsuarioPorEmail (p_usuario) [0].Id);

                if (en.Contrasenya.Equals (Utils.Util.GetEncondeMD5 (p_contrasenya)))
                        result = true;
        }

        return result;

        throw new NotImplementedException ("Method Login() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
