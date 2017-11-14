
using System;
// Definición clase IngredienteEN
namespace PracticaGenNHibernate.EN.Practica
{
public partial class IngredienteEN                                                                  : PracticaGenNHibernate.EN.Practica.ProductoEN


{
/**
 *	Atributo personalizable
 */
private System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PersonalizableEN> personalizable;






public virtual System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PersonalizableEN> Personalizable {
        get { return personalizable; } set { personalizable = value;  }
}





public IngredienteEN() : base ()
{
        personalizable = new System.Collections.Generic.List<PracticaGenNHibernate.EN.Practica.PersonalizableEN>();
}



public IngredienteEN(int id, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PersonalizableEN> personalizable
                     , double precio, string nombre, string foto, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido, int numVeces
                     )
{
        this.init (Id, personalizable, precio, nombre, foto, lineaPedido, numVeces);
}


public IngredienteEN(IngredienteEN ingrediente)
{
        this.init (Id, ingrediente.Personalizable, ingrediente.Precio, ingrediente.Nombre, ingrediente.Foto, ingrediente.LineaPedido, ingrediente.NumVeces);
}

private void init (int id
                   , System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PersonalizableEN> personalizable, double precio, string nombre, string foto, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido, int numVeces)
{
        this.Id = id;


        this.Personalizable = personalizable;

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
        IngredienteEN t = obj as IngredienteEN;
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
