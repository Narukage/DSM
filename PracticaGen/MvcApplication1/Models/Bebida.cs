using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Bebida
    {

        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Precio del artículo", Description = "Precio del artículo", Name = "Precio ")]
        [Required(ErrorMessage = "Debe indicar un precio para el artículo")]
        public string precio { get; set; }

        [Display(Prompt = "Nombre del artículo", Description = "Nombre del artículo", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string nombre { get; set; }

        [Display(Prompt = "Imagen del artículo", Description = "Unidades del artículo", Name = "Imagen ")]
        [Required(ErrorMessage = "Debe indicar una imagen del artículo")]
        public string foto { get; set; }

        [ScaffoldColumn(false)]
        public int numveces { get; set; }

    }
}