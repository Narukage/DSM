using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Home
    {


        [Display(Prompt = "Nombre", Description = "Nombre", Name = "Nombre")]
        [Required(ErrorMessage = "Nombre")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string nombre { get; set; }

        [Display(Prompt = "Email", Description = "Email", Name = "Email")]
        [Required(ErrorMessage = "Email")]
        [StringLength(maximumLength: 200, ErrorMessage = "El email no puede tener más de 200 caracteres")]
        public string email { get; set; }


        [ScaffoldColumn(false)]
        public string mensaje { get; set; }

    }
}