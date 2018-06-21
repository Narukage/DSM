using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public class AssemblerRegistrado
    {
        public Registrado ConvertENToModelUI(RegistradoEN en)
        {
            Registrado inc = new Registrado();
           
            inc.email = en.Email;
            inc.nombre = en.Nombre;
            inc.telefono = en.Telefono;
            inc.contrasenya = en.Contrasenya;
            inc.fecha_nac = en.Fecha_nac;
            inc.fecha_reg = en.FechaRegistro;
            inc.id = en.Id;

            return (inc);
        }

        public IList<Registrado> ConvertListENToModel(IList<RegistradoEN> ens)
        {
            IList<Registrado> inc = new List<Registrado>();

            foreach (RegistradoEN i in ens)
            {
                inc.Add(ConvertENToModelUI(i));
            }
            return inc;
        }
    }
}