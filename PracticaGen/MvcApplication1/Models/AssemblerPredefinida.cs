using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;

namespace MvcApplication1.Models
{
    public class AssemblerPredefinida
    {
        public Predefinida ConvertENToModelUI(PredefinidaEN en) {

          Predefinida pred = new Predefinida();

            pred.Id = en.Id;
            pred.Descripcion = en.Descripcion;
            double precio = Convert.ToDouble(pred.precio);
            precio = en.Precio;
            pred.Nombre = en.Nombre;
            pred.Foto = en.Foto;
            pred.NumVeces = en.NumVeces;
            pred.tamaño = en.Tamaño;
            pred.masa = en.Masa;
     
            return pred;
        }

        public IList<Predefinida> ConvertListENToModel(IList<PredefinidaEN> ens)
        {
            IList<Predefinida> pred = new List<Predefinida>();
            foreach (PredefinidaEN en in ens)
            {
                pred.Add(ConvertENToModelUI(en));
            }
            return pred;
        }
    }
}