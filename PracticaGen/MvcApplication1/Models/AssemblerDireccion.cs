using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class AssemblerDireccion
    {
        public Direccion ConvertENToModelUI(DireccionEN en, NHibernate.ISession sesion)
        {
            Direccion inc = new Direccion();

            inc.id = en.Id;
            inc.localidad = en.Localidad;
            inc.provincia = en.Provincia;
            inc.numero = en.Numero;
            inc.codp = en.Codp;
            inc.calle = en.Calle;

            return (inc);
        }

        public IList<Direccion> ConvertListENToModel(IList<DireccionEN> ens, NHibernate.ISession sesion)
        {
            IList<Direccion> inc = new List<Direccion>();

            foreach (DireccionEN i in ens)
            {
                inc.Add(ConvertENToModelUI(i,sesion));
            }
            return inc;
        }
    }
}