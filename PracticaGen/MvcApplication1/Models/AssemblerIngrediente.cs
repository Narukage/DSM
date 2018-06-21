using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class AssemblerIngrediente
    {
        public Ingrediente ConvertENToModelUI(IngredienteEN en, NHibernate.ISession session)
        {

            Ingrediente ing = new Ingrediente();
            ing.Id = en.Id;
            ing.lineaPedido = en.LineaPedido;
            ing.personalizable = en.Personalizable;
            double precio = Convert.ToDouble(ing.precio);
            precio = en.Precio;
            ing.Nombre = en.Nombre;
            ing.Foto = en.Foto;
            ing.NumVeces = en.NumVeces;
            return ing;
        }

        public IList<Ingrediente> ConvertListENToModel(IList<IngredienteEN> ens, NHibernate.ISession session)
        {
            IList<Ingrediente> pred = new List<Ingrediente>();
            foreach (IngredienteEN en in ens)
            {
                pred.Add(ConvertENToModelUI(en,session));
            }
            return pred;
        }

      
    }
}