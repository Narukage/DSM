using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Registrado
    {

 

        [Display(Prompt = "Usuario1", Description = "Email del usuario", Name = "Email")]
        public String email { get; set; }

        [Display(Prompt = "Usuario2", Description = "Nombre del usuario", Name = "Nombre")]
        public String nombre { get; set; }

        [Display(Prompt = "Usuario3", Description = "Telefono del usuario", Name = "Telefono")]
        public int telefono { get; set; }

        [Display(Prompt = "Usuario5", Description = "Contrasenya del usuario", Name = "Contrasenya")]
        public String contrasenya { get; set; }

        [Display(Prompt = "Usuario4", Description = "Fecha de registro", Name = "Fecha Registro")]
        public Nullable<DateTime> fecha_reg { get; set; }

        [Display(Prompt = "Usuario6", Description = "Fecha de nacimiento", Name = "Fecha de nacimiento")]
        public Nullable<DateTime> fecha_nac { get; set; }

        [ScaffoldColumn(false)]
        public int id { get; set; }

    }
}