using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class AssemblerCesta
    {
        public Cesta ConvertENToModelUI(Pedido ped, Usuario usu)
        {
            Cesta cest = new Cesta();

            cest.pedido = ped;
            cest.usuario = usu;

            return cest;
        }

        public IList<Cesta> ConvertListENToModel(Pedido ped, Usuario usu)
        {
            IList<Cesta> cest = new List<Cesta>();
            cest.Add(ConvertENToModelUI(ped, usu));

            return cest;
        }

    }
}