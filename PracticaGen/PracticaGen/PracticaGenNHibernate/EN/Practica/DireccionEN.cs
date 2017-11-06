
using System;
// Definición clase DireccionEN
namespace PracticaGenNHibernate.EN.Practica
{
public partial class DireccionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo localidad
 */
private string localidad;



/**
 *	Atributo provincia
 */
private string provincia;



/**
 *	Atributo calle
 */
private string calle;



/**
 *	Atributo codp
 */
private int codp;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.UsuarioEN> usuario;



/**
 *	Atributo numero
 */
private int numero;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Localidad {
        get { return localidad; } set { localidad = value;  }
}



public virtual string Provincia {
        get { return provincia; } set { provincia = value;  }
}



public virtual string Calle {
        get { return calle; } set { calle = value;  }
}



public virtual int Codp {
        get { return codp; } set { codp = value;  }
}



public virtual System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual int Numero {
        get { return numero; } set { numero = value;  }
}





public DireccionEN()
{
        usuario = new System.Collections.Generic.List<PracticaGenNHibernate.EN.Practica.UsuarioEN>();
}



public DireccionEN(int id, string localidad, string provincia, string calle, int codp, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.UsuarioEN> usuario, int numero
                   )
{
        this.init (Id, localidad, provincia, calle, codp, usuario, numero);
}


public DireccionEN(DireccionEN direccion)
{
        this.init (Id, direccion.Localidad, direccion.Provincia, direccion.Calle, direccion.Codp, direccion.Usuario, direccion.Numero);
}

private void init (int id
                   , string localidad, string provincia, string calle, int codp, System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.UsuarioEN> usuario, int numero)
{
        this.Id = id;


        this.Localidad = localidad;

        this.Provincia = provincia;

        this.Calle = calle;

        this.Codp = codp;

        this.Usuario = usuario;

        this.Numero = numero;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        DireccionEN t = obj as DireccionEN;
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
