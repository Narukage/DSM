

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
 *      Definition of the class PizzaCEN
 *
 */
public partial class PizzaCEN
{
private IPizzaCAD _IPizzaCAD;

public PizzaCEN()
{
        this._IPizzaCAD = new PizzaCAD ();
}

public PizzaCEN(IPizzaCAD _IPizzaCAD)
{
        this._IPizzaCAD = _IPizzaCAD;
}

public IPizzaCAD get_IPizzaCAD ()
{
        return this._IPizzaCAD;
}

public int New_ (double p_precio, string p_nombre, string p_foto, int p_tamaño, int p_masa)
{
        PizzaEN pizzaEN = null;
        int oid;

        //Initialized PizzaEN
        pizzaEN = new PizzaEN ();
        pizzaEN.Precio = p_precio;

        pizzaEN.Nombre = p_nombre;

        pizzaEN.Foto = p_foto;

        pizzaEN.Tamaño = p_tamaño;

        pizzaEN.Masa = p_masa;

        //Call to PizzaCAD

        oid = _IPizzaCAD.New_ (pizzaEN);
        return oid;
}

public void Modify (int p_Pizza_OID, double p_precio, string p_nombre, string p_foto, int p_tamaño, int p_masa)
{
        PizzaEN pizzaEN = null;

        //Initialized PizzaEN
        pizzaEN = new PizzaEN ();
        pizzaEN.Id = p_Pizza_OID;
        pizzaEN.Precio = p_precio;
        pizzaEN.Nombre = p_nombre;
        pizzaEN.Foto = p_foto;
        pizzaEN.Tamaño = p_tamaño;
        pizzaEN.Masa = p_masa;
        //Call to PizzaCAD

        _IPizzaCAD.Modify (pizzaEN);
}

public void Destroy (int id
                     )
{
        _IPizzaCAD.Destroy (id);
}

public PizzaEN ReadOID (int id
                        )
{
        PizzaEN pizzaEN = null;

        pizzaEN = _IPizzaCAD.ReadOID (id);
        return pizzaEN;
}

public System.Collections.Generic.IList<PizzaEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PizzaEN> list = null;

        list = _IPizzaCAD.ReadAll (first, size);
        return list;
}
}
}
