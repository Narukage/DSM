
using System;
// Definición clase LineaPedidoEN
namespace PracticaGenNHibernate.EN.Practica
{
public partial class LineaPedidoEN
{
/**
 *	Atributo producto
 */
private PracticaGenNHibernate.EN.Practica.ProductoEN producto;



/**
 *	Atributo pedido
 */
private PracticaGenNHibernate.EN.Practica.PedidoEN pedido;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo valoracion
 */
private int valoracion;






public virtual PracticaGenNHibernate.EN.Practica.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}



public virtual PracticaGenNHibernate.EN.Practica.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual int Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}





public LineaPedidoEN()
{
}



public LineaPedidoEN(int id, PracticaGenNHibernate.EN.Practica.ProductoEN producto, PracticaGenNHibernate.EN.Practica.PedidoEN pedido, int cantidad, int valoracion
                     )
{
        this.init (Id, producto, pedido, cantidad, valoracion);
}


public LineaPedidoEN(LineaPedidoEN lineaPedido)
{
        this.init (Id, lineaPedido.Producto, lineaPedido.Pedido, lineaPedido.Cantidad, lineaPedido.Valoracion);
}

private void init (int id
                   , PracticaGenNHibernate.EN.Practica.ProductoEN producto, PracticaGenNHibernate.EN.Practica.PedidoEN pedido, int cantidad, int valoracion)
{
        this.Id = id;


        this.Producto = producto;

        this.Pedido = pedido;

        this.Cantidad = cantidad;

        this.Valoracion = valoracion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaPedidoEN t = obj as LineaPedidoEN;
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
