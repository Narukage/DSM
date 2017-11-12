

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaGenNHibernate.Exceptions;

using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;


namespace PracticaGenNHibernate.CEN.Practica
{
/*
 *      Definition of the class IncidenciaCEN
 *
 */
public partial class IncidenciaCEN
{
private IIncidenciaCAD _IIncidenciaCAD;

public IncidenciaCEN()
{
        this._IIncidenciaCAD = new IncidenciaCAD ();
}

public IncidenciaCEN(IIncidenciaCAD _IIncidenciaCAD)
{
        this._IIncidenciaCAD = _IIncidenciaCAD;
}

public IIncidenciaCAD get_IIncidenciaCAD ()
{
        return this._IIncidenciaCAD;
}

public int New_ (string p_descripcion, PracticaGenNHibernate.Enumerated.Practica.EstadoIncidenciaEnum p_estado, string p_usuario)
{
        IncidenciaEN incidenciaEN = null;
        int oid;

        //Initialized IncidenciaEN
        incidenciaEN = new IncidenciaEN ();
        incidenciaEN.Descripcion = p_descripcion;

        incidenciaEN.Estado = p_estado;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                incidenciaEN.Usuario = new PracticaGenNHibernate.EN.Practica.UsuarioEN ();
                incidenciaEN.Usuario.Email = p_usuario;
        }

        //Call to IncidenciaCAD

        oid = _IIncidenciaCAD.New_ (incidenciaEN);
        return oid;
}

public void Modify (int p_Incidencia_OID, string p_descripcion, PracticaGenNHibernate.Enumerated.Practica.EstadoIncidenciaEnum p_estado)
{
        IncidenciaEN incidenciaEN = null;

        //Initialized IncidenciaEN
        incidenciaEN = new IncidenciaEN ();
        incidenciaEN.Id = p_Incidencia_OID;
        incidenciaEN.Descripcion = p_descripcion;
        incidenciaEN.Estado = p_estado;
        //Call to IncidenciaCAD

        _IIncidenciaCAD.Modify (incidenciaEN);
}

public void Destroy (int id
                     )
{
        _IIncidenciaCAD.Destroy (id);
}

public IncidenciaEN ReadOID (int id
                             )
{
        IncidenciaEN incidenciaEN = null;

        incidenciaEN = _IIncidenciaCAD.ReadOID (id);
        return incidenciaEN;
}

public System.Collections.Generic.IList<IncidenciaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<IncidenciaEN> list = null;

        list = _IIncidenciaCAD.ReadAll (first, size);
        return list;
}
}
}
