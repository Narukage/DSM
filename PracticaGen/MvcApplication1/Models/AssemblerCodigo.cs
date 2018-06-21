﻿using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class AssemblerCodigo
    {
        public Codigo ConvertENToModelUI(CodigoEN en, NHibernate.ISession session)
        {

            Codigo cod = new Codigo();

            cod.Id = en.Id;
            cod.Descuento = en.Descuento;
            cod.Numero = en.Numero;
            cod.Tipo = en.Tipo;
            return cod;
        }

        public IList<Codigo> ConvertListENToModel(IList<CodigoEN> ens, NHibernate.ISession session)
        {
            IList<Codigo> cod = new List<Codigo>();
            foreach (CodigoEN en in ens)
            {
                cod.Add(ConvertENToModelUI(en, session));
            }
            return cod;
        }
    }
}