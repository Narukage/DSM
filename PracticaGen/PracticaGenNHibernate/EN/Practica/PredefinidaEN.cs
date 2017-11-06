
using System;
// Definición clase PredefinidaEN
namespace PracticaGenNHibernate.EN.Practica
{
public partial class PredefinidaEN                                                                  : PracticaGenNHibernate.EN.Practica.PizzaEN


{
/**
 *	Atributo descripcion
 */
private string descripcion;






public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}





public PredefinidaEN() : base ()
{
}



public PredefinidaEN(int id, string descripcion
                     , PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum tamaño, PracticaGenNHibernate.Enumerated.Practica.TipomasaEnum masa
                     , double precio, string nombre, string foto, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido
                     )
{
        this.init (Id, descripcion, tamaño, masa, precio, nombre, foto, lineaPedido);
}


public PredefinidaEN(PredefinidaEN predefinida)
{
        this.init (Id, predefinida.Descripcion, predefinida.Tamaño, predefinida.Masa, predefinida.Precio, predefinida.Nombre, predefinida.Foto, predefinida.LineaPedido);
}

private void init (int id
                   , string descripcion, PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum tamaño, PracticaGenNHibernate.Enumerated.Practica.TipomasaEnum masa, double precio, string nombre, string foto, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido)
{
        this.Id = id;


        this.Descripcion = descripcion;

        this.Tamaño = tamaño;

        this.Masa = masa;

        this.Precio = precio;

        this.Nombre = nombre;

        this.Foto = foto;

        this.LineaPedido = lineaPedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PredefinidaEN t = obj as PredefinidaEN;
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
