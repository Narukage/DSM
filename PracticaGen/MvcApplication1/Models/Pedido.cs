﻿
using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Pedido
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public int iduser { get; set; }

        [Display(Prompt = "Confirmado", Description = "Id del pedido", Name = "Confirmado")]
        public bool Confirmado { get; set; }

        [Display(Prompt = "Precio del pedido", Description = "Precio del pedido", Name = "Precio total")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        public double PrecioTotal { get; set; }

        [Display(Prompt = "Estado del pedido", Description = "Estado del pedido", Name = "Estado ")]
        public PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum Estado { get; set; }

        [Display(Prompt = "Tipo de pago ", Description = "Estado del pedido", Name = "TipoPago ")]
        public PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum TipoPago { get; set; }


        [Display(Prompt = "Linea del pedido", Description = "Linea del pedido", Name = "LinPed ")]
        public IList<LineaPedido> LinPed { get; set; }

        [Display(Prompt = "Fecha del pedido", Description = "Fecha del pedido", Name = "Fecha")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> Fecha { get; set; }

        [Display(Prompt = "Valoración ", Description = "Valoracion del pedido", Name = "Valoracion")]
        public double valoracion { get; set; }

        [Display(Prompt = "Direccion", Description = "Dirección del pedido", Name = "Direcccion")]
        public Direccion direcion { get; set; }

        [Display(Prompt = "Codigo", Description = "Código del pedido", Name = "Código")]
        public Codigo codigo { get; set; }


    }
}