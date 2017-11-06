
using System;
// Definición clase AdminEN
namespace PracticaGenNHibernate.EN.Practica
{
public partial class AdminEN                                                                        : PracticaGenNHibernate.EN.Practica.RegistradoEN


{
/**
 *	Atributo codigo
 */
private System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.CodigoEN> codigo;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> pedido;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.UsuarioEN> usuario;



/**
 *	Atributo incidencia
 */
private System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.IncidenciaEN> incidencia;






public virtual System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.CodigoEN> Codigo {
        get { return codigo; } set { codigo = value;  }
}



public virtual System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.IncidenciaEN> Incidencia {
        get { return incidencia; } set { incidencia = value;  }
}





public AdminEN() : base ()
{
        codigo = new System.Collections.Generic.List<PracticaGenNHibernate.EN.Practica.CodigoEN>();
        pedido = new System.Collections.Generic.List<PracticaGenNHibernate.EN.Practica.PedidoEN>();
        usuario = new System.Collections.Generic.List<PracticaGenNHibernate.EN.Practica.UsuarioEN>();
        incidencia = new System.Collections.Generic.List<PracticaGenNHibernate.EN.Practica.IncidenciaEN>();
}



public AdminEN(string email, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.CodigoEN> codigo, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> pedido, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.UsuarioEN> usuario, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.IncidenciaEN> incidencia
               , string nombre, String contrasenya, Nullable<DateTime> fecha_nac, int telefono
               )
{
        this.init (Email, codigo, pedido, usuario, incidencia, nombre, contrasenya, fecha_nac, telefono);
}


public AdminEN(AdminEN admin)
{
        this.init (Email, admin.Codigo, admin.Pedido, admin.Usuario, admin.Incidencia, admin.Nombre, admin.Contrasenya, admin.Fecha_nac, admin.Telefono);
}

private void init (string email
                   , System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.CodigoEN> codigo, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> pedido, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.UsuarioEN> usuario, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.IncidenciaEN> incidencia, string nombre, String contrasenya, Nullable<DateTime> fecha_nac, int telefono)
{
        this.Email = email;


        this.Codigo = codigo;

        this.Pedido = pedido;

        this.Usuario = usuario;

        this.Incidencia = incidencia;

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
