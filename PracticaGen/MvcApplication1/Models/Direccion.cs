using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Direccion
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Provincia", Description = "Provincia Usuario", Name = "Provincia del Usuario")]
        [Required(ErrorMessage = "Se debe introducir la provincia")]
        public string provincia  { get; set; }

        [Display(Prompt = "Localidad", Description = "Localidad del usuario", Name = "Localidad el usuario")]
        [Required(ErrorMessage = "Se debe introducir la localidad")]
        public string localidad { get; set; }

        [Display(Prompt = "Código postal", Description = "Codigo postal Usuario", Name = "Codigo postal del Usuario")]
        [Required(ErrorMessage = "Se debe introducir el codigo postal")]
        public int codp { get; set; }

        [Display(Prompt = "Calle", Description = "Calle Usuario", Name = "Calle del usuario")]
        [Required(ErrorMessage = "Se debe introducir la Calle")]
        public string calle { get; set; }

        [Display(Prompt = "Numero", Description = "numero Usuario", Name = "numero del Usuario")]
        [Required(ErrorMessage = "Se debe introducir el Número")]
        public int numero { get; set; }

    }
}