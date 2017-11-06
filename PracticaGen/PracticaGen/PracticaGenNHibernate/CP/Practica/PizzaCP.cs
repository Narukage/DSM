
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using PracticaGenNHibernate.Exceptions;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.CEN.Practica;


namespace PracticaGenNHibernate.CP.Practica
{
public partial class PizzaCP : BasicCP
{
public PizzaCP() : base ()
{
}

public PizzaCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
