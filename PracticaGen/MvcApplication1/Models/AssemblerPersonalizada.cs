using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class AssemblerPersonalizada
    {
        public Personalizada ConvertENToModelUI(PersonalizableEN en, NHibernate.ISession session)
        {
            AssemblerIngrediente aprod = new AssemblerIngrediente();
            Personalizada pred = new Personalizada();

            pred.Id = en.Id;
            pred.Precio = en.Precio;
            pred.Nombre = en.Nombre;
            pred.Foto = en.Foto;
            pred.NumVeces = en.NumVeces;
            pred.tamaño = en.Tamaño;
            pred.masa = en.Masa;
            if(en.Ingrediente!=null)
                    pred.ingredientes = aprod.ConvertListENToModel(en.Ingrediente,session);
          
            return pred;
        }

        public IList<Personalizada> ConvertListENToModel(IList<PersonalizableEN> ens, NHibernate.ISession session)
        {
            IList<Personalizada> pred = new List<Personalizada>();
            foreach (PersonalizableEN en in ens)
            {
                pred.Add(ConvertENToModelUI(en,session));
            }
            return pred;
        }
    }
}