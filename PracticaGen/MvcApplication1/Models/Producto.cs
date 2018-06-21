
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Producto
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        public int NumVeces { get; set; }

        [Display(Prompt = "Nombre del producto", Description = "Nombre del producto", Name = "Nombre")]
        public String Nombre { get; set; }

        [Display(Prompt = "Precio del producto", Description = "Precio del producto", Name = "Precio total")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0.00, maximum: 10000.00, ErrorMessage = "EL precio debe ser mayor que cero y menor de 10000")]
        public double Precio { get; set; }


        [Display(Prompt = "Imagen del producto", Description = "Imagen del producto", Name = "Imagen ")]
        public string Foto { get; set; }

        [Display(Prompt = "Linea del pedido", Description = "Linea del pedido", Name = "LinPed ")]
        public IList<LineaPedido> LinPed { get; set; }

       

       
    }
}