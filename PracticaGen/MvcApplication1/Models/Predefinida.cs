using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Predefinida
    {


        [Display(Prompt = "Nombre de la pizza", Description = "Nombre de la pizza", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para para la pizza")]
        [StringLength(maximumLength: 200, ErrorMessage = "El descripción no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Descripción de la pizza", Description = "Descripción de la pizza", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar una descripción para el artículo")]
        [StringLength(maximumLength: 500, ErrorMessage = "El descripción no puede tener más de 500 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Precio del artículo", Description = "Precio del artículo", Name = "Precio ")]
        [Required(ErrorMessage = "Debe indicar un precio para el artículo")]
        public string precio { get; set; }

        [ScaffoldColumn(false)]
        public PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum tamaño { get; set; }

        [ScaffoldColumn(false)]
        public PracticaGenNHibernate.Enumerated.Practica.TipoMasaEnum masa { get; set; }


        [Display(Prompt = "Imagen de la pizza", Description = "Imagen de la pizza", Name = "Imagen ")]
        public string Foto { get; set; }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public int NumVeces { get; set; }
    }
}