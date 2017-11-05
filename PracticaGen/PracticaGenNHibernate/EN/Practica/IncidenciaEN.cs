
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
private int estado;



/**
 *	Atributo usuario
 */
private PracticaGenNHibernate.EN.Practica.UsuarioEN usuario;



/**
 *	Atributo admin
 */
private PracticaGenNHibernate.EN.Practica.AdminEN admin;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual int Estado {
        get { return estado; } set { estado = value;  }
}



public virtual PracticaGenNHibernate.EN.Practica.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual PracticaGenNHibernate.EN.Practica.AdminEN Admin {
        get { return admin; } set { admin = value;  }
}





public IncidenciaEN()
{
}



public IncidenciaEN(int id, string descripcion, int estado, PracticaGenNHibernate.EN.Practica.UsuarioEN usuario, PracticaGenNHibernate.EN.Practica.AdminEN admin
                    )
{
        this.init (Id, descripcion, estado, usuario, admin);
}


public IncidenciaEN(IncidenciaEN incidencia)
{
        this.init (Id, incidencia.Descripcion, incidencia.Estado, incidencia.Usuario, incidencia.Admin);
}

private void init (int id
                   , string descripcion, int estado, PracticaGenNHibernate.EN.Practica.UsuarioEN usuario, PracticaGenNHibernate.EN.Practica.AdminEN admin)
{
        this.Id = id;


        this.Descripcion = descripcion;

        this.Estado = estado;

        this.Usuario = usuario;

        this.Admin = admin;
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
