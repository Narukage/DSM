using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public class AssemblerIncidencia
    {
        public Incidencia ConvertENToModelUI(IncidenciaEN en)
        {
            Incidencia inc = new Incidencia();

            inc.descripcion = en.Descripcion;
            inc.id = en.Id;
            inc.estado = en.Estado;
            inc.fecha = en.Fecha;
            inc.iduser = en.Usuario.Id;

            return (inc);
        }

        public IList<Incidencia> ConvertListENToModel(IList<IncidenciaEN> ens)
        {
            IList<Incidencia> inc = new List<Incidencia>();

            foreach (IncidenciaEN i in ens)
            {
                inc.Add(ConvertENToModelUI(i));
            }
            return inc;
        }
    }
}