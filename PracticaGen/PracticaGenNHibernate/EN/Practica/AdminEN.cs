
using System;
// Definición clase AdminEN
namespace PracticaGenNHibernate.EN.Practica
{
public partial class AdminEN                                                                        : PracticaGenNHibernate.EN.Practica.RegistradoEN


{
public AdminEN() : base ()
{
}



public AdminEN(string email,
               string nombre, String contrasenya, Nullable<DateTime> fecha_nac, int telefono
               )
{
        this.init (Email, nombre, contrasenya, fecha_nac, telefono);
}


public AdminEN(AdminEN admin)
{
        this.init (Email, admin.Nombre, admin.Contrasenya, admin.Fecha_nac, admin.Telefono);
}

private void init (string email
                   , string nombre, String contrasenya, Nullable<DateTime> fecha_nac, int telefono)
{
        this.Email = email;


        this.Nombre = nombre;

        this.Contrasenya = contrasenya;

        this.Fecha_nac = fecha_nac;

        this.Telefono = telefono;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdminEN t = obj as AdminEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
