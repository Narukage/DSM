
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.CEN.Practica;



/*PROTECTED REGION ID(usingPracticaGenNHibernate.CP.Practica_Pedido_calcularMedia) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CP.Practica
{
public partial class PedidoCP : BasicCP
{
public double CalcularMedia (int p_oid)
{
        /*PROTECTED REGION ID(PracticaGenNHibernate.CP.Practica_Pedido_calcularMedia) ENABLED START*/

        IPedidoCAD pedidoCAD = null;
        PedidoCEN pedidoCEN = null;
        PedidoEN pedidoEN = null;

        double result = 0;
        double acumulador = 0;

        try
        {
                SessionInitializeTransaction ();
                pedidoCAD = new PedidoCAD (session);
                pedidoCEN = new  PedidoCEN (pedidoCAD);



                // Write here your custom transaction ...

                pedidoEN = pedidoCEN.ReadOID (p_oid);


                double count = 0.0;
                foreach (LineaPedidoEN lineaped in pedidoEN.LineaPedido) {
                        if (lineaped.Valoracion == PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum.mala) {
                                acumulador += 1;
                        }
                        if (lineaped.Valoracion == PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum.regular) {
                                acumulador += 2;
                        }
                        if (lineaped.Valoracion == PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum.buena) {
                                acumulador += 3;
                        }
                        if (lineaped.Valoracion == PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum.muybuena) {
                                acumulador += 4;
                        }
                        if (lineaped.Valoracion == PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum.excelente) {
                                acumulador += 5;
                        }
                        count++; //numero de lineas de pedido que tiene pedido
                }
                //calculando media

                result = acumulador / count;




                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
