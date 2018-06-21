using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Personalizada
    {
        [ScaffoldColumn(false)]
        public string Nombre { get; set; }

        [Display(Prompt = "Precio del complemento", Description = "Precio del articulo", Name = "Precio ")]
        [Required(ErrorMessage = "Debe indicar un precio para el artículo")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        public double Precio { get; set; }

        [ScaffoldColumn(false)]
        public PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum tamaño { get; set; }

        [ScaffoldColumn(false)]
        public PracticaGenNHibernate.Enumerated.Practica.TipoMasaEnum masa { get; set; }

        [ScaffoldColumn(false)]
        public string Foto { get; set; }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public int NumVeces { get; set; }

        [ScaffoldColumn(false)]
        public IList<Ingrediente> ingredientes{ get; set; }
    }
}