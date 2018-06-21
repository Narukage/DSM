
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Codigo
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Cantidad de descuento", Description = "Cantidad de descuento", Name = "Descuento")]
        [Required(ErrorMessage = "Debe indicar el descuento")]
        [Range(minimum: 0, maximum: 100, ErrorMessage = "El descuento debe ser mayor que cero y menor de 101")]
        public int Descuento { get; set; }

        [Display(Prompt = "Tipo de descuento", Description = "Tipo de descuento", Name = "Tipo")]
        [Required(ErrorMessage = "Debe indicar el Tipo")]
        public PracticaGenNHibernate.Enumerated.Practica.TipoCodigoEnum Tipo { get; set; }


        [Display(Prompt = "Código de descuento", Description = "Código de descuento", Name = "Código")]
        [Required(ErrorMessage = "Debe indicar el Numero")]
        public String Numero { get; set; }  //es el codigo de descuento en si


       
    }
}