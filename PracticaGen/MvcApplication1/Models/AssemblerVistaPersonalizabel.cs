using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class AssemblerVistaPersonalizabel
    {
        public VistaPersonalizada ConvertENToModelUI(Personalizada en, IList<IngredienteEN> ing)
        {
            VistaPersonalizada per = new VistaPersonalizada();
            per.personalizada = en;
            per.ingredientes = ing;
            return per;
        }

        public IList<VistaPersonalizada> ConvertListEnToModel(Personalizada ens, IList<IngredienteEN> ing)
        {
            IList<VistaPersonalizada> personalizadas = new List<VistaPersonalizada>();

            personalizadas.Add(ConvertENToModelUI(ens, ing));

            return personalizadas;
        }


    }
}