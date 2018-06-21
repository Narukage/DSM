
using System;
// Definición clase ComplementoEN
namespace PracticaGenNHibernate.EN.Practica
{
public partial class ComplementoEN                                                                  : PracticaGenNHibernate.EN.Practica.ProductoEN


{
public ComplementoEN() : base ()
{
}



public ComplementoEN(int id,
                     double precio, string nombre, string foto, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido, int numVeces
                     )
{
        this.init (Id, precio, nombre, foto, lineaPedido, numVeces);
}


public ComplementoEN(ComplementoEN complemento)
{
        this.init (Id, complemento.Precio, complemento.Nombre, complemento.Foto, complemento.LineaPedido, complemento.NumVeces);
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
        ComplementoEN t = obj as ComplementoEN;
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
