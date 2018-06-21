
using System;
// Definición clase BebidaEN
namespace PracticaGenNHibernate.EN.Practica
{
public partial class BebidaEN                                                                       : PracticaGenNHibernate.EN.Practica.ProductoEN


{
public BebidaEN() : base ()
{
}



public BebidaEN(int id,
                double precio, string nombre, string foto, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido, int numVeces
                )
{
        this.init (Id, precio, nombre, foto, lineaPedido, numVeces);
}


public BebidaEN(BebidaEN bebida)
{
        this.init (Id, bebida.Precio, bebida.Nombre, bebida.Foto, bebida.LineaPedido, bebida.NumVeces);
}

private void init (int id
                   , double precio, string nombre, string foto, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido, int numVeces)
{
        this.Id = id;


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
        BebidaEN t = obj as BebidaEN;
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
