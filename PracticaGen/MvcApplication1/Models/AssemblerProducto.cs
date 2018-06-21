using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class AssemblerProducto
    {
        public Producto ConvertENToModelUI(ProductoEN en, NHibernate.ISession session)
        {
           
            Producto ped = new Producto();
            ped.Id = en.Id;
            ped.Foto = en.Foto; 
            ped.Nombre = en.Nombre;
            ped.NumVeces = en.NumVeces;
            ped.Precio = en.Precio;

           
            return ped;
        }

        public IList<Producto> ConvertListENToModel(IList<ProductoEN> ens, NHibernate.ISession session)
        {
            IList<Producto> ped= new List<Producto>();
            foreach (ProductoEN en in ens)
            {
               ped.Add(ConvertENToModelUI(en, session));
            }
            return ped;
        }
    }
}