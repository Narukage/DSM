
using System;
// Definición clase UsuarioEN
namespace PracticaGenNHibernate.EN.Practica
{
public partial class UsuarioEN                                                                      : PracticaGenNHibernate.EN.Practica.RegistradoEN


{
/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> pedido;



/**
 *	Atributo direccion
 */
private System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.DireccionEN> direccion;



/**
 *	Atributo incidencia
 */
private System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.IncidenciaEN> incidencia;






public virtual System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.DireccionEN> Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.IncidenciaEN> Incidencia {
        get { return incidencia; } set { incidencia = value;  }
}





public UsuarioEN() : base ()
{
        pedido = new System.Collections.Generic.List<PracticaGenNHibernate.EN.Practica.PedidoEN>();
        direccion = new System.Collections.Generic.List<PracticaGenNHibernate.EN.Practica.DireccionEN>();
        incidencia = new System.Collections.Generic.List<PracticaGenNHibernate.EN.Practica.IncidenciaEN>();
}



public UsuarioEN(string email, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> pedido, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.DireccionEN> direccion, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.IncidenciaEN> incidencia
                 , string nombre, String contrasenya, Nullable<DateTime> fecha_nac, int telefono, Nullable<DateTime> fechaRegistro
                 )
{
        this.init (Email, pedido, direccion, incidencia, nombre, contrasenya, fecha_nac, telefono, fechaRegistro);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Email, usuario.Pedido, usuario.Direccion, usuario.Incidencia, usuario.Nombre, usuario.Contrasenya, usuario.Fecha_nac, usuario.Telefono, usuario.FechaRegistro);
}

private void init (string email
                   , System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> pedido, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.DireccionEN> direccion, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.IncidenciaEN> incidencia, string nombre, String contrasenya, Nullable<DateTime> fecha_nac, int telefono, Nullable<DateTime> fechaRegistro)
{
        this.Email = email;


        this.Pedido = pedido;

        this.Direccion = direccion;

        this.Incidencia = incidencia;

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
        UsuarioEN t = obj as UsuarioEN;
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
