

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
 *      Definition of the class IngredienteCEN
 *
 */
public partial class IngredienteCEN
{
private IIngredienteCAD _IIngredienteCAD;

public IngredienteCEN()
{
        this._IIngredienteCAD = new IngredienteCAD ();
}

public IngredienteCEN(IIngredienteCAD _IIngredienteCAD)
{
        this._IIngredienteCAD = _IIngredienteCAD;
}

public IIngredienteCAD get_IIngredienteCAD ()
{
        return this._IIngredienteCAD;
}

public int New_ (float p_precio, string p_nombre, string p_foto)
{
        IngredienteEN ingredienteEN = null;
        int oid;

        //Initialized IngredienteEN
        ingredienteEN = new IngredienteEN ();
        ingredienteEN.Precio = p_precio;

        ingredienteEN.Nombre = p_nombre;

        ingredienteEN.Foto = p_foto;

        //Call to IngredienteCAD

        oid = _IIngredienteCAD.New_ (ingredienteEN);
        return oid;
}

public void Modify (int p_Ingrediente_OID, float p_precio, string p_nombre, string p_foto)
{
        IngredienteEN ingredienteEN = null;

        //Initialized IngredienteEN
        ingredienteEN = new IngredienteEN ();
        ingredienteEN.Id = p_Ingrediente_OID;
        ingredienteEN.Precio = p_precio;
        ingredienteEN.Nombre = p_nombre;
        ingredienteEN.Foto = p_foto;
        //Call to IngredienteCAD

        _IIngredienteCAD.Modify (ingredienteEN);
}

public void Destroy (int id
                     )
{
        _IIngredienteCAD.Destroy (id);
}

public System.Collections.Generic.IList<IngredienteEN> GetTodosProductos (int first, int size)
{
        System.Collections.Generic.IList<IngredienteEN> list = null;

        list = _IIngredienteCAD.GetTodosProductos (first, size);
        return list;
}
}
}
