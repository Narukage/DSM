using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PracticaGenNHibernate.EN.Practica;

namespace MvcApplication1.Models
{
    public class AssemblerComplemento
    {

        public Complemento ConvertENToModelUI(ComplementoEN en)
        {
            Complemento complem = new Complemento();
            complem.id = en.Id;
            double precio = Convert.ToDouble(complem.precio);
            precio = en.Precio;
            complem.nombre = en.Nombre;
            complem.foto = en.Foto;
            complem.numVeces = en.NumVeces;

            return complem;


        }
        public IList<Complemento> ConvertListENToModel(IList<ComplementoEN> ens)
        {
            IList<Complemento> complems = new List<Complemento>();
            foreach (ComplementoEN en in ens)
            {
                complems.Add(ConvertENToModelUI(en));
            }
            return complems;
        }

    }
}