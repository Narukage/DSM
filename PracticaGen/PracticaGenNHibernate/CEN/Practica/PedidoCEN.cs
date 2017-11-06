

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
 *      Definition of the class PedidoCEN
 *
 */
public partial class PedidoCEN
{
private IPedidoCAD _IPedidoCAD;

public PedidoCEN()
{
        this._IPedidoCAD = new PedidoCAD ();
}

public PedidoCEN(IPedidoCAD _IPedidoCAD)
{
        this._IPedidoCAD = _IPedidoCAD;
}

public IPedidoCAD get_IPedidoCAD ()
{
        return this._IPedidoCAD;
}

public int New_ (PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum p_estado, Nullable<DateTime> p_fecha, double p_precioTotal, PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum p_tipoPago, string p_usuario, string p_admin)
{
        PedidoEN pedidoEN = null;
        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Estado = p_estado;

        pedidoEN.Fecha = p_fecha;

        pedidoEN.PrecioTotal = p_precioTotal;

        pedidoEN.TipoPago = p_tipoPago;


        if (p_usuario != null) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids id
                pedidoEN.Usuario = new PracticaGenNHibernate.EN.Practica.UsuarioEN ();
                pedidoEN.Usuario.Email = p_usuario;
        }


        if (p_admin != null) {
                // El argumento p_admin -> Property admin es oid = false
                // Lista de oids id
                pedidoEN.Admin = new PracticaGenNHibernate.EN.Practica.AdminEN ();
                pedidoEN.Admin.Email = p_admin;
        }

        //Call to PedidoCAD

        oid = _IPedidoCAD.New_ (pedidoEN);
        return oid;
}

public void Modify (int p_Pedido_OID, PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum p_estado, Nullable<DateTime> p_fecha, double p_precioTotal, PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum p_tipoPago)
{
        PedidoEN pedidoEN = null;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Id = p_Pedido_OID;
        pedidoEN.Estado = p_estado;
        pedidoEN.Fecha = p_fecha;
        pedidoEN.PrecioTotal = p_precioTotal;
        pedidoEN.TipoPago = p_tipoPago;
        //Call to PedidoCAD

        _IPedidoCAD.Modify (pedidoEN);
}

public void Destroy (int id
                     )
{
        _IPedidoCAD.Destroy (id);
}

public PedidoEN ReadOID (int id
                         )
{
        PedidoEN pedidoEN = null;

        pedidoEN = _IPedidoCAD.ReadOID (id);
        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> list = null;

        list = _IPedidoCAD.ReadAll (first, size);
        return list;
}
}
}
