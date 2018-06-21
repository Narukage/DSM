
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class LineaPedido
    {

        [Display(Prompt = "Id del producto", Description = "Id del producto asociado a la linea", Name = "idproducto")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Required(ErrorMessage = "El pedido debe tener un valor válido")]
        public int idproducto { get; set; }

        [Display(Prompt = "Id del pedido", Description = "Id del pedido asociado a la linea", Name = "idpedido")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Required(ErrorMessage = "El pedido debe tener un valor válido")]
        public int idpedido  { get; set; }

        [ScaffoldColumn(false)]
        public IList<int> pedido;

        [ScaffoldColumn(false)]
        public String idusuario;

        [Display(Prompt = "Precio de subtotal", Description = "Precio del subtotal de un artículo", Name = "Subtotal")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum: 100000, ErrorMessage = "El precio debe ser mayor que 0")]
        [Required(ErrorMessage = "El pedido debe tener un valor válido")]
        public double Subtotal { get; set; } //PUEDE QUE NOS INTERESE JEJEJEJEJEJEJEJEJEJE
        
        [Display(Prompt = "Cantidad de articulos", Description = "Cantidad de articulos de un determinado producto en el pedido actual", Name = "Cantidad ")]
        [Range(minimum: 1, maximum: 10000, ErrorMessage = "Se debe comprar una cantidad de articulos mayor que 0")]
        [Required(ErrorMessage = "Se debe introducir la cantidad de articulos a comprar")]
        public int Cantidad { get; set; }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Cantidad de articulos", Description = "Cantidad de articulos de un determinado producto en el pedido actual", Name = "Valoración ")]
        public PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum Valoracion { get; set; }

        [Display(Prompt = "Producto de la línea de pedido", Description = "Producto que contiene la línea de pedido en cuestión", Name = "Producto")]
        public Producto producto{ get; set; }
       
    }
}