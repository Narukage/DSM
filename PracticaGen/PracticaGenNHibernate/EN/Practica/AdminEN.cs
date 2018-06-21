
using System;
// Definición clase AdminEN
namespace PracticaGenNHibernate.EN.Practica
{
public partial class AdminEN                                                                        : PracticaGenNHibernate.EN.Practica.RegistradoEN


{
public AdminEN() : base ()
{
}



public AdminEN(int id,
               string email, string nombre, String contrasenya, Nullable<DateTime> fecha_nac, int telefono, Nullable<DateTime> fechaRegistro
               )
{
        this.init (Id, email, nombre, contrasenya, fecha_nac, telefono, fechaRegistro);
}


public AdminEN(AdminEN admin)
{
        this.init (Id, admin.Email, admin.Nombre, admin.Contrasenya, admin.Fecha_nac, admin.Telefono, admin.FechaRegistro);
}

private void init (int id
                   , string email, string nombre, String contrasenya, Nullable<DateTime> fecha_nac, int telefono, Nullable<DateTime> fechaRegistro)
{
        this.Id = id;


        this.Email = email;

        this.Nombre = nombre;

        this.Contrasenya = contrasenya;

        this.Fecha_nac = fecha_nac;

        this.Telefono = telefono;

        this.FechaRegistro = fechaRegistro;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdminEN t = obj as AdminEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
