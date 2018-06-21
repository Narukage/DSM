using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class AssemblerBebida
    {

        public Bebida ConvertENToModelUI(BebidaEN en)
        {
            Bebida bebida = new Bebida();
            bebida.id = en.Id;
            double precio = Convert.ToDouble(bebida.precio);
            precio = en.Precio;
            bebida.nombre = en.Nombre;
            bebida.foto = en.Foto;
            bebida.numveces = en.NumVeces;
            return bebida;
        }

        public IList<Bebida> ConvertListEnToModel(IList<BebidaEN> ens)
        {
            IList<Bebida> bebidas = new List<Bebida>();
            foreach (BebidaEN en in ens)
            {
                bebidas.Add(ConvertENToModelUI(en));
            }
            return bebidas;
        }

    }
}