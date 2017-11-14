
using System;
using PracticaGenNHibernate.EN.Practica;

namespace PracticaGenNHibernate.CAD.Practica
{
public partial interface IPedidoCAD
{
PedidoEN ReadOIDDefault (int id
                         );

void ModifyDefault (PedidoEN pedido);



int New_ (PedidoEN pedido);

void Modify (PedidoEN pedido);


void Destroy (int id
              );


PedidoEN ReadOID (int id
                  );


System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size);







void AnyadirCodigo (int p_Pedido_OID, int p_codigo_OID);

void EliminarCodigo (int p_Pedido_OID, int p_codigo_OID);



long PedidosMensuales (Nullable<DateTime> p_fecha);


long GetCodigosActivados ();


System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> DevolverPedidosUsuario (string usuario);
}
}
