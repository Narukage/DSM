
using System;
// Definición clase RegistradoEN
namespace PracticaGenNHibernate.EN.Practica
{
public partial class RegistradoEN
{
/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo contrasenya
 */
private String contrasenya;



/**
 *	Atributo fecha_nac
 */
private Nullable<DateTime> fecha_nac;



/**
 *	Atributo telefono
 */
private int telefono;



/**
 *	Atributo fechaRegistro
 */
private Nullable<DateTime> fechaRegistro;






public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual String Contrasenya {
        get { return contrasenya; } set { contrasenya = value;  }
}



public virtual Nullable<DateTime> Fecha_nac {
        get { return fecha_nac; } set { fecha_nac = value;  }
}



public virtual int Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual Nullable<DateTime> FechaRegistro {
        get { return fechaRegistro; } set { fechaRegistro = value;  }
}





public RegistradoEN()
{
}



public RegistradoEN(string email, string nombre, String contrasenya, Nullable<DateTime> fecha_nac, int telefono, Nullable<DateTime> fechaRegistro
                    )
{
        this.init (Email, nombre, contrasenya, fecha_nac, telefono, fechaRegistro);
}


public RegistradoEN(RegistradoEN registrado)
{
        this.init (Email, registrado.Nombre, registrado.Contrasenya, registrado.Fecha_nac, registrado.Telefono, registrado.FechaRegistro);
}

private void init (string email
                   , string nombre, String contrasenya, Nullable<DateTime> fecha_nac, int telefono, Nullable<DateTime> fechaRegistro)
{
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
        RegistradoEN t = obj as RegistradoEN;
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
