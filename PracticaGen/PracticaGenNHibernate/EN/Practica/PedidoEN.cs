
using System;
// Definición clase PedidoEN
namespace PracticaGenNHibernate.EN.Practica
{
public partial class PedidoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo estado
 */
private PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum estado;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo precioTotal
 */
private double precioTotal;



/**
 *	Atributo tipoPago
 */
private PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum tipoPago;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido;



/**
 *	Atributo codigo
 */
private PracticaGenNHibernate.EN.Practica.CodigoEN codigo;



/**
 *	Atributo usuario
 */
private PracticaGenNHibernate.EN.Practica.UsuarioEN usuario;



/**
 *	Atributo confirmado
 */
private bool confirmado;



/**
 *	Atributo valoracion
 */
private double valoracion;



/**
 *	Atributo direccion
 */
private PracticaGenNHibernate.EN.Practica.DireccionEN direccion;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual double PrecioTotal {
        get { return precioTotal; } set { precioTotal = value;  }
}



public virtual PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum TipoPago {
        get { return tipoPago; } set { tipoPago = value;  }
}



public virtual System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual PracticaGenNHibernate.EN.Practica.CodigoEN Codigo {
        get { return codigo; } set { codigo = value;  }
}



public virtual PracticaGenNHibernate.EN.Practica.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual bool Confirmado {
        get { return confirmado; } set { confirmado = value;  }
}



public virtual double Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual PracticaGenNHibernate.EN.Practica.DireccionEN Direccion {
        get { return direccion; } set { direccion = value;  }
}





public PedidoEN()
{
        lineaPedido = new System.Collections.Generic.List<PracticaGenNHibernate.EN.Practica.LineaPedidoEN>();
}



public PedidoEN(int id, PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum estado, Nullable<DateTime> fecha, double precioTotal, PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum tipoPago, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido, PracticaGenNHibernate.EN.Practica.CodigoEN codigo, PracticaGenNHibernate.EN.Practica.UsuarioEN usuario, bool confirmado, double valoracion, PracticaGenNHibernate.EN.Practica.DireccionEN direccion
                )
{
        this.init (Id, estado, fecha, precioTotal, tipoPago, lineaPedido, codigo, usuario, confirmado, valoracion, direccion);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (Id, pedido.Estado, pedido.Fecha, pedido.PrecioTotal, pedido.TipoPago, pedido.LineaPedido, pedido.Codigo, pedido.Usuario, pedido.Confirmado, pedido.Valoracion, pedido.Direccion);
}

private void init (int id
                   , PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum estado, Nullable<DateTime> fecha, double precioTotal, PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum tipoPago, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido, PracticaGenNHibernate.EN.Practica.CodigoEN codigo, PracticaGenNHibernate.EN.Practica.UsuarioEN usuario, bool confirmado, double valoracion, PracticaGenNHibernate.EN.Practica.DireccionEN direccion)
{
        this.Id = id;


        this.Estado = estado;

        this.Fecha = fecha;

        this.PrecioTotal = precioTotal;

        this.TipoPago = tipoPago;

        this.LineaPedido = lineaPedido;

        this.Codigo = codigo;

        this.Usuario = usuario;

        this.Confirmado = confirmado;

        this.Valoracion = valoracion;

        this.Direccion = direccion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
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
