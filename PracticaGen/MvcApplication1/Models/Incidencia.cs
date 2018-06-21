using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Incidencia
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Incidencia", Description = "Id Usuaio", Name = "Id del Usuario")]
        public int iduser { get; set; }

        [Display(Prompt = "Incidencia", Description = "Fecha de la incidencia", Name = "Fecha")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> fecha { get; set; }

        [Display(Prompt = "Incidencia", Description = "Mensaje de incidencia del usuario", Name = "Contenido")]
        [Required(ErrorMessage = "Se debe introducir el mensaje de incidencia")]
        [DataType(DataType.MultilineText)]
        public String descripcion { get; set; }

        [Display(Prompt = "Estado de incidencia", Description = "Estado de resolucion de incidencia", Name = "Estado de la Incidencia")]
        [Required(ErrorMessage = "Se debe introducir el estado de la incidencia")]
        public PracticaGenNHibernate.Enumerated.Practica.EstadoIncidenciaEnum estado { get; set; }



    }
}