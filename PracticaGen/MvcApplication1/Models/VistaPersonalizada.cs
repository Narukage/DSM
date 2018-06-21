using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class VistaPersonalizada
    {
        [ScaffoldColumn(false)]
        public IList<PracticaGenNHibernate.EN.Practica.IngredienteEN> ingredientes{ get; set; }

        [ScaffoldColumn(false)]
        public Personalizada personalizada{ get; set; } 
       
    }
}