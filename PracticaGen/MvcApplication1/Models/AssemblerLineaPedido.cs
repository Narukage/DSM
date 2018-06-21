using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public class AssemblerLineaPedido
    {
        public LineaPedido ConvertENToModelUI(LineaPedidoEN en, NHibernate.ISession session)
        {
          
            AssemblerProducto aprod = new AssemblerProducto();
            LineaPedido linped = new LineaPedido();
            
            linped.Id = en.Id;


            if (en.Producto != null)
            {

                linped.producto = aprod.ConvertENToModelUI(en.Producto, session);
                linped.idproducto = en.Producto.Id;
                linped.Id = en.Id;
                linped.idpedido = en.Pedido.Id;
                linped.Cantidad = en.Cantidad;
                linped.Valoracion = en.Valoracion;
                linped.Subtotal = en.Cantidad * en.Producto.Precio;
            }
            
            return linped;
        }

        public IList<LineaPedido> ConvertListENToModel(IList<LineaPedidoEN> ens, NHibernate.ISession session)
        {
            IList<LineaPedido> linpeds = new List<LineaPedido>();
            foreach (LineaPedidoEN en in ens)
            {
                linpeds.Add(ConvertENToModelUI(en, session));
            }
            return linpeds;
        }
    }

}
