using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Ingrediente
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.PersonalizableEN> personalizable{ get; set; }

        [ScaffoldColumn(false)]
        public System.Collections.Generic.IList<PracticaGenNHibernate.EN.Practica.LineaPedidoEN> lineaPedido { get; set; }

        [Display(Prompt = "Nombre del ingrediente", Description = "Nombre del ingrediente", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el ingrediente")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Precio del artículo", Description = "Precio del artículo", Name = "Precio ")]
        [Required(ErrorMessage = "Debe indicar un precio para el artículo")]
        public string precio { get; set; }

        [Display(Prompt = "Imagen del ingrediente", Description = "Imagen del ingrediente", Name = "Imagen ")]
        public string Foto { get; set; }

        [ScaffoldColumn(false)]
        public int NumVeces { get; set; }



    }
}