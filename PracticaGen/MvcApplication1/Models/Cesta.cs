using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Cesta
    {

        [ScaffoldColumn(false)]
        public Pedido pedido { get; set; }

        [ScaffoldColumn(false)]
        public Usuario usuario { get; set; }


    }
}