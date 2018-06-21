
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



long PedidosMensuales (int ? p_mes);


long GetCodigosActivados ();


System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> DevolverPedidosUsuario (string usuario);



void AnyadirLineaPedido (int p_Pedido_OID, System.Collections.Generic.IList<int> p_lineaPedido_OIDs);

void EliminarLineaPedido (int p_Pedido_OID, System.Collections.Generic.IList<int> p_lineaPedido_OIDs);

System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PedidoEN> BuscarPedido (int ? id);




void AnyadirDireccion (int p_Pedido_OID, int p_direccion_OID);

void EliminarDireccion (int p_Pedido_OID, int p_direccion_OID);
}
}
