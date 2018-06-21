﻿using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class AssemblerPedido
    {
        public Pedido ConvertENToModelUI(PedidoEN en, NHibernate.ISession session)
        {

            IList<int> lpeds = new List<int>();
            Pedido ped = new Pedido();
            AssemblerLineaPedido alinped = new AssemblerLineaPedido();
            ped.Id = en.Id;
            ped.LinPed = alinped.ConvertListENToModel(en.LineaPedido, session);
            ped.Fecha = en.Fecha;
            ped.PrecioTotal = en.PrecioTotal;
            ped.iduser = en.Usuario.Id; //clave primaria del usuario
            ped.Estado = en.Estado;
            ped.TipoPago = en.TipoPago;
            ped.Confirmado = en.Confirmado;
            ped.valoracion = en.Valoracion;
            if (en.Direccion != null)
                ped.direcion = new AssemblerDireccion().ConvertENToModelUI(en.Direccion, session);
            if (en.Codigo != null)
                ped.codigo = new AssemblerCodigo().ConvertENToModelUI(en.Codigo, session);

            return ped;
        }

        public IList<Pedido> ConvertListENToModel(IList<PedidoEN> ens, NHibernate.ISession session)
        {
            IList<Pedido> ped = new List<Pedido>();
            foreach (PedidoEN en in ens)
            {
                ped.Add(ConvertENToModelUI(en, session));
            }
            return ped;
        }
    }
}