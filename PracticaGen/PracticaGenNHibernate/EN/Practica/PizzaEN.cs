
using System;
// Definición clase PizzaEN
namespace PracticaGenNHibernate.EN.Practica
{
public partial class PizzaEN                                                                        : PracticaGenNHibernate.EN.Practica.ProductoEN


{
/**
 *	Atributo tamaño
 */
private int tamaño;



/**
 *	Atributo masa
 */
private int masa;






public virtual int Tamaño {
        get { return tamaño; } set { tamaño = value;  }
}



public virtual int Masa {
        get { return masa; } set { masa = value;  }
}





public PizzaEN() : base ()
{
}



public PizzaEN(int id, int tamaño, int masa
               , double precio, string nombre, string foto, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido, int numVeces
               )
{
        this.init (Id, tamaño, masa, precio, nombre, foto, lineaPedido, numVeces);
}


public PizzaEN(PizzaEN pizza)
{
        this.init (Id, pizza.Tamaño, pizza.Masa, pizza.Precio, pizza.Nombre, pizza.Foto, pizza.LineaPedido, pizza.NumVeces);
}

private void init (int id
                   , int tamaño, int masa, double precio, string nombre, string foto, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido, int numVeces)
{
        this.Id = id;


        this.Tamaño = tamaño;

        this.Masa = masa;

        this.Precio = precio;

        this.Nombre = nombre;

        this.Foto = foto;

        this.LineaPedido = lineaPedido;

        this.NumVeces = numVeces;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PizzaEN t = obj as PizzaEN;
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
