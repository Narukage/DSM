
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaGenNHibernate.Exceptions;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;


/*PROTECTED REGION ID(usingPracticaGenNHibernate.CEN.Practica_Incidencia_cambiarEstado) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CEN.Practica
{
public partial class IncidenciaCEN
{
public void CambiarEstado (int p_oid, PracticaGenNHibernate.Enumerated.Practica.EstadoIncidenciaEnum estado)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CEN.Practica_Incidencia_cambiarEstado) ENABLED START*/

        // Write here your custom code...

        IncidenciaEN incidenciaEN = _IIncidenciaCAD.ReadOID (p_oid);

        incidenciaEN.Estado = estado;
        _IIncidenciaCAD.Modify (incidenciaEN);

        /*PROTECTED REGION END*/
}
}
}
