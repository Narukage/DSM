
using System;
// Definición clase CodigoEN
namespace PracticaGenNHibernate.EN.Practica
{
public partial class CodigoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo descuento
 */
private int descuento;



/**
 *	Atributo tipo
 */
private PracticaGenNHibernate.Enumerated.Practica.TipoCodigoEnum tipo;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> pedido;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Descuento {
        get { return descuento; } set { descuento = value;  }
}



public virtual PracticaGenNHibernate.Enumerated.Practica.TipoCodigoEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}





public CodigoEN()
{
        pedido = new System.Collections.Generic.List<PracticaGenNHibernate.EN.Practica.PedidoEN>();
}



public CodigoEN(int id, int descuento, PracticaGenNHibernate.Enumerated.Practica.TipoCodigoEnum tipo, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> pedido
                )
{
        this.init (Id, descuento, tipo, pedido);
}


public CodigoEN(CodigoEN codigo)
{
        this.init (Id, codigo.Descuento, codigo.Tipo, codigo.Pedido);
}

private void init (int id
                   , int descuento, PracticaGenNHibernate.Enumerated.Practica.TipoCodigoEnum tipo, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> pedido)
{
        this.Id = id;


        this.Descuento = descuento;

        this.Tipo = tipo;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CodigoEN t = obj as CodigoEN;
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
