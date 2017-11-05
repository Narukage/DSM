
using System;
// Definición clase ProductoEN
namespace PracticaGenNHibernate.EN.Practica
{
public partial class ProductoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo precio
 */
private float precio;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo foto
 */
private string foto;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual float Precio {
        get { return precio; } set { precio = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Foto {
        get { return foto; } set { foto = value;  }
}



public virtual System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}





public ProductoEN()
{
        lineaPedido = new System.Collections.Generic.List<PracticaGenNHibernate.EN.Practica.LineaPedidoEN>();
}



public ProductoEN(int id, float precio, string nombre, string foto, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido
                  )
{
        this.init (Id, precio, nombre, foto, lineaPedido);
}


public ProductoEN(ProductoEN producto)
{
        this.init (Id, producto.Precio, producto.Nombre, producto.Foto, producto.LineaPedido);
}

private void init (int id
                   , float precio, string nombre, string foto, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido)
{
        this.Id = id;


        this.Precio = precio;

        this.Nombre = nombre;

        this.Foto = foto;

        this.LineaPedido = lineaPedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProductoEN t = obj as ProductoEN;
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
