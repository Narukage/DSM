

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
 *      Definition of the class PersonalizableCEN
 *
 */
public partial class PersonalizableCEN
{
private IPersonalizableCAD _IPersonalizableCAD;

public PersonalizableCEN()
{
        this._IPersonalizableCAD = new PersonalizableCAD ();
}

public PersonalizableCEN(IPersonalizableCAD _IPersonalizableCAD)
{
        this._IPersonalizableCAD = _IPersonalizableCAD;
}

public IPersonalizableCAD get_IPersonalizableCAD ()
{
        return this._IPersonalizableCAD;
}

public int New_ (double p_precio, string p_nombre, string p_foto, int p_numVeces, int p_tamaño, int p_masa)
{
        PersonalizableEN personalizableEN = null;
        int oid;

        //Initialized PersonalizableEN
        personalizableEN = new PersonalizableEN ();
        personalizableEN.Precio = p_precio;

        personalizableEN.Nombre = p_nombre;

        personalizableEN.Foto = p_foto;

        personalizableEN.NumVeces = p_numVeces;

        personalizableEN.Tamaño = p_tamaño;

        personalizableEN.Masa = p_masa;

        //Call to PersonalizableCAD

        oid = _IPersonalizableCAD.New_ (personalizableEN);
        return oid;
}

public void Modify (int p_Personalizable_OID, double p_precio, string p_nombre, string p_foto, int p_numVeces, int p_tamaño, int p_masa)
{
        PersonalizableEN personalizableEN = null;

        //Initialized PersonalizableEN
        personalizableEN = new PersonalizableEN ();
        personalizableEN.Id = p_Personalizable_OID;
        personalizableEN.Precio = p_precio;
        personalizableEN.Nombre = p_nombre;
        personalizableEN.Foto = p_foto;
        personalizableEN.NumVeces = p_numVeces;
        personalizableEN.Tamaño = p_tamaño;
        personalizableEN.Masa = p_masa;
        //Call to PersonalizableCAD

        _IPersonalizableCAD.Modify (personalizableEN);
}

public void Destroy (int id
                     )
{
        _IPersonalizableCAD.Destroy (id);
}

public PersonalizableEN ReadOID (int id
                                 )
{
        PersonalizableEN personalizableEN = null;

        personalizableEN = _IPersonalizableCAD.ReadOID (id);
        return personalizableEN;
}

public System.Collections.Generic.IList<PersonalizableEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PersonalizableEN> list = null;

        list = _IPersonalizableCAD.ReadAll (first, size);
        return list;
}
public void EliminarIngrediente (int p_Personalizable_OID, System.Collections.Generic.IList<int> p_ingrediente_OIDs)
{
        //Call to PersonalizableCAD

        _IPersonalizableCAD.EliminarIngrediente (p_Personalizable_OID, p_ingrediente_OIDs);
}
}
}
