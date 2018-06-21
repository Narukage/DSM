
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.CEN.Practica;
using System.Collections.Generic;



/*PROTECTED REGION ID(usingPracticaGenNHibernate.CP.Practica_Pedido_calcularPrecio) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaGenNHibernate.CP.Practica
{
    public partial class PedidoCP : BasicCP
    {
        public double CalcularPrecio(int p_oid)
        {
            /*PROTECTED REGION ID(PracticaGenNHibernate.CP.Practica_Pedido_calcularPrecio) ENABLED START*/

            IPedidoCAD pedidoCAD = null;
            PedidoCEN pedidoCEN = null;

            int cantidad = 0;
            bool tiene = false;
            double preciototal = 0;
            double preciolinea = 0;
            double descuento = 0;



            try
            {
                SessionInitializeTransaction();
                pedidoCAD = new PedidoCAD(session);
                pedidoCEN = new PedidoCEN(pedidoCAD);


                PredefinidaCEN predef = new PredefinidaCEN();
                PersonalizableCEN person = new PersonalizableCEN();
                ComplementoCEN complemento = new ComplementoCEN();
                BebidaCEN bebida = new BebidaCEN();

                PedidoEN pedidoEN = pedidoCAD.ReadOIDDefault(p_oid);

                //hago readall de todas los productos

                IList<PredefinidaEN> p = predef.ReadAll(0, -1);
                IList<PersonalizableEN> per = person.ReadAll(0, -1);
                IList<ComplementoEN> c = complemento.ReadAll(0, -1);
                IList<BebidaEN> b = bebida.ReadAll(0, -1);


                //compruebo si el pedido tiene c�digo

                if (pedidoEN.Codigo != null)
                {
                    tiene = true;
                }

                foreach (LineaPedidoEN lineaped in pedidoEN.LineaPedido)
                {
                    cantidad = lineaped.Cantidad;

                    if (tiene)
                    {
                        PracticaGenNHibernate.Enumerated.Practica.TipoCodigoEnum tipo = pedidoEN.Codigo.Tipo;

                        foreach (PredefinidaEN pres in p)
                        {

                            if (pres.Id == lineaped.Producto.Id)
                            {
                                preciolinea = lineaped.Producto.Precio * cantidad;



                                if (tipo == PracticaGenNHibernate.Enumerated.Practica.TipoCodigoEnum.pizza)
                                {

                                    descuento = preciolinea * (pedidoEN.Codigo.Descuento) * 0.01;
                                    preciolinea = preciolinea - descuento;


                                }
                                preciototal += preciolinea;
                            }

                        }

                        foreach (PersonalizableEN pres in per)
                        {
                            if (pres.Id == lineaped.Producto.Id)
                            {
                                preciolinea = lineaped.Producto.Precio * cantidad;
                                if (tipo == PracticaGenNHibernate.Enumerated.Practica.TipoCodigoEnum.pizza)
                                {
                                    descuento = preciolinea * (pedidoEN.Codigo.Descuento) * 0.01;
                                    preciolinea = preciolinea - descuento;

                                }

                                preciototal += preciolinea;
                            }
                        }

                        foreach (ComplementoEN pres in c)
                        {
                            if (pres.Id == lineaped.Producto.Id)
                            {
                                preciolinea = lineaped.Producto.Precio * cantidad;
                                if (tipo == PracticaGenNHibernate.Enumerated.Practica.TipoCodigoEnum.complemento)
                                {


                                    descuento = preciolinea * (pedidoEN.Codigo.Descuento) * 0.01;
                                    preciolinea = preciolinea - descuento;


                                }
                                preciototal += preciolinea;
                            }


                        }

                        foreach (BebidaEN pres in b)
                        {
                            if (pres.Id == lineaped.Producto.Id)
                            {
                                preciolinea = lineaped.Producto.Precio * cantidad;
                                if (tipo == PracticaGenNHibernate.Enumerated.Practica.TipoCodigoEnum.bebida)
                                {

                                    descuento = preciolinea * (pedidoEN.Codigo.Descuento) * 0.01;
                                    preciolinea = preciolinea - descuento;

                                }

                                preciototal += preciolinea;

                            }


                        }

                    }
                    else
                    {
                        preciototal += lineaped.Producto.Precio * cantidad;
                    }
                }


                pedidoEN.PrecioTotal = preciototal;

                pedidoCAD.ModifyDefault(pedidoEN);

                // Write here your custom transaction ...





                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }
            return preciototal;


            /*PROTECTED REGION END*/
        }
    }
}
