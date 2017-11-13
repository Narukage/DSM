
using System;
// Definición clase IncidenciaEN
namespace PracticaGenNHibernate.EN.Practica
{
public partial class IncidenciaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo estado
 */
private PracticaGenNHibernate.Enumerated.Practica.EstadoIncidenciaEnum estado;



/**
 *	Atributo usuario
 */
private PracticaGenNHibernate.EN.Practica.UsuarioEN usuario;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual PracticaGenNHibernate.Enumerated.Practica.EstadoIncidenciaEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual PracticaGenNHibernate.EN.Practica.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public IncidenciaEN()
{
}



public IncidenciaEN(int id, string descripcion, PracticaGenNHibernate.Enumerated.Practica.EstadoIncidenciaEnum estado, PracticaGenNHibernate.EN.Practica.UsuarioEN usuario, Nullable<DateTime> fecha
                    )
{
        this.init (Id, descripcion, estado, usuario, fecha);
}


public IncidenciaEN(IncidenciaEN incidencia)
{
        this.init (Id, incidencia.Descripcion, incidencia.Estado, incidencia.Usuario, incidencia.Fecha);
}

private void init (int id
                   , string descripcion, PracticaGenNHibernate.Enumerated.Practica.EstadoIncidenciaEnum estado, PracticaGenNHibernate.EN.Practica.UsuarioEN usuario, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Descripcion = descripcion;

        this.Estado = estado;

        this.Usuario = usuario;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        IncidenciaEN t = obj as IncidenciaEN;
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
