using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Usuario
    {

        [Display(Prompt = "Email", Description = "Email del usuario", Name = "Email")]
        public String email { get; set; }

        [Display(Prompt = "Nombre", Description = "Nombre del usuario", Name = "Nombre")]
        public String nombre { get; set; }

        [Display(Prompt = "Telefono", Description = "Telefono del usuario", Name = "Telefono")]
        public int telefono { get; set; }

        [Display(Prompt = "Contrasenya", Description = "Contrasenya del usuario", Name = "Contrasenya")]
        public String contrasenya { get; set; }

        [Display(Prompt = "Fecha de registro", Description = "Fecha de registro", Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> fecha_reg { get; set; }

        [Display(Prompt = "Fecha de nacimiento", Description = "Fecha de nacimiento", Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> fecha_nac { get; set; }

        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public IList<Direccion> direccion { get; set; }
    }
}