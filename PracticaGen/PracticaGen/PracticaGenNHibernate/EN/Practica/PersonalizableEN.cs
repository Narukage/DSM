
using System;
// Definición clase PersonalizableEN
namespace PracticaGenNHibernate.EN.Practica
{
public partial class PersonalizableEN                                                                       : PracticaGenNHibernate.EN.Practica.PizzaEN


{
/**
 *	Atributo ingrediente
 */
private System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.IngredienteEN> ingrediente;






public virtual System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.IngredienteEN> Ingrediente {
        get { return ingrediente; } set { ingrediente = value;  }
}





public PersonalizableEN() : base ()
{
        ingrediente = new System.Collections.Generic.List<PracticaGenNHibernate.EN.Practica.IngredienteEN>();
}



public PersonalizableEN(int id, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.IngredienteEN> ingrediente
                        , int tamaño, int masa
                        , double precio, string nombre, string foto, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido
                        )
{
        this.init (Id, ingrediente, tamaño, masa, precio, nombre, foto, lineaPedido);
}


public PersonalizableEN(PersonalizableEN personalizable)
{
        this.init (Id, personalizable.Ingrediente, personalizable.Tamaño, personalizable.Masa, personalizable.Precio, personalizable.Nombre, personalizable.Foto, personalizable.LineaPedido);
}

private void init (int id
                   , System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.IngredienteEN> ingrediente, int tamaño, int masa, double precio, string nombre, string foto, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido)
{
        this.Id = id;


        this.Ingrediente = ingrediente;

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
        PersonalizableEN t = obj as PersonalizableEN;
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
