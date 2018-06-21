using MvcApplication1.Models;
using PracticaGenNHibernate.CEN.Practica;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class LineaPedidoController : BasicController
    {
        
        // GET: /LineaPedido/
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Index()
        {
            SessionInitialize();
            LineaPedidoCEN linPed = new LineaPedidoCEN(new LineaPedidoCAD(session));
            IList<LineaPedidoEN> linPeden = linPed.ReadAll(0, -1);
            IEnumerable<LineaPedido> list = new AssemblerLineaPedido().ConvertListENToModel(linPeden, session).ToList();
            SessionClose();
            return View(list);
        }

        //
        // GET: /LineaPedido/Details/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Details(int id)
        {
            return View();
        }



        //
        // GETPROPIO: /LineaPedido/Create

        [Authorize]
        public ActionResult CreateyAnyade( int id, int cantidad, string vuelve )
        {
            try
            {
                SessionInitialize();
                PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum valor = PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum.sin_valorar;
                LineaPedidoCEN linPed = new LineaPedidoCEN(new LineaPedidoCAD());
                UsuarioCEN usu = new UsuarioCEN();
                PedidoCEN pedi = new PedidoCEN(new PedidoCAD(session));
                IList<UsuarioEN> hola = usu.UsuarioPorEmail(User.Identity.Name);
                IList<PedidoEN> pedidos = pedi.DevolverPedidosUsuario(hola[0].Nombre);
               
                Boolean existe = false;
                foreach (LineaPedidoEN linea in pedidos[(pedidos.Count) - 1].LineaPedido) {
                    if (linea.Producto.Id == id) {
                        linPed.Modify(linea.Id,linea.Cantidad+cantidad,linea.Valoracion);
                        existe = true;
                    }
                }
                int id2 = pedidos[(pedidos.Count) - 1].Id;
                if (existe == false) {
                   
                    int idLin = linPed.New_(id2, cantidad, valor);
                    IList<int> idLineas = new List<int>();
                    idLineas.Add(idLin);
                    linPed.AnyadirProducto(idLin, id);
                    pedi.AnyadirLineaPedido(id2, idLineas);
                    Session["Clineas"] = Convert.ToInt32(Session["Clineas"]) + 1;
                }
                     

                PracticaGenNHibernate.CP.Practica.PedidoCP a = new PracticaGenNHibernate.CP.Practica.PedidoCP();
                a.CalcularPrecio(id2);
                SessionClose();
                if (!vuelve.Equals("Personalizada"))
                {
                    return RedirectToAction("IndexUser", vuelve);
                }
                else
                {
                    return RedirectToAction("Index","Cesta");
                }
            }

            catch
            {
                return View();
            }
        }


        //
        // GET: /LineaPedido/Create
        [Authorize]
        public ActionResult Create()
        {
            LineaPedido linPed = new LineaPedido();
            if (User.Identity.Name.Equals("admin@epizza.com"))
                return View(linPed);
            else
            {

                return RedirectToAction("Index", "Home");
            }
        }

        //
        // POST: /LineaPedido/Create

        [HttpPost]
        public ActionResult Create(LineaPedido linea)
        {
            try
            {
                LineaPedidoCEN linPed = new LineaPedidoCEN();
                int id = linPed.New_(linea.idpedido, linea.Cantidad, linea.Valoracion);
                linPed.AnyadirProducto(id, linea.idproducto);
                PracticaGenNHibernate.CP.Practica.PedidoCP a = new PracticaGenNHibernate.CP.Practica.PedidoCP();
                a.CalcularPrecio(linea.idpedido);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /LineaPedido/Edit/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Edit(int id)
        {
            LineaPedido linPed= null;
            SessionInitialize();
            LineaPedidoEN linPedEN = new LineaPedidoCAD(session).ReadOIDDefault(id);
            linPed= new AssemblerLineaPedido().ConvertENToModelUI(linPedEN, session);
            PracticaGenNHibernate.CP.Practica.PedidoCP a = new PracticaGenNHibernate.CP.Practica.PedidoCP();
            a.CalcularPrecio(linPedEN.Pedido.Id);
            SessionClose();
            return View(linPed);
        }

        //
        // POST: /LineaPedido/Edit/5

        [HttpPost]
        public ActionResult Edit(LineaPedido linea)
        {
            try
            {
               
                // TODO: Add update logic here
                LineaPedidoCEN lineacen = new LineaPedidoCEN();
               

                lineacen.Modify(linea.Id, linea.Cantidad, linea.Valoracion);
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /LineaPedido/Valorar/5

        [Authorize]
        public ActionResult Valorar(int id, int pedido, int valoracion)
        {
            try
            {

                // TODO: Add update logic here

                SessionInitialize();
                PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum valor = PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum.sin_valorar;
                LineaPedidoCEN linPed = new LineaPedidoCEN(new LineaPedidoCAD());
                PedidoCEN pedi = new PedidoCEN(new PedidoCAD(session));
                PedidoEN pedEN = pedi.ReadOID(pedido);
                IList<LineaPedidoEN> lineas = pedEN.LineaPedido;


                switch (valoracion)
                {
                    case 1:

                        valor = PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum.mala;

                        break;

                    case 2:

                        valor = PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum.regular;
                        break;

                    case 3:

                        valor = PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum.buena;
                        break;

                    case 4:

                        valor = PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum.muybuena;
                        break;

                    case 5:

                        valor = PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum.excelente;
                        break;

                }

                linPed.ValorarLinea(id, valor);



                int contador = 0;

                //compruebo que todas las chismas han sido valoradas, y si es asi llamo a calcularmedia
                foreach (LineaPedidoEN lin in lineas)
                {

                    if (lin.Valoracion != PracticaGenNHibernate.Enumerated.Practica.TipoValoracionEnum.sin_valorar)
                    {
                        contador++;

                        if (contador == lineas.Count)
                        {

                            return RedirectToAction("CalcularMedia", "Pedido", new { id = pedido });
                        }

                    }

                }


                SessionClose();

                return RedirectToAction("PedidosUsuario", "Account");
            }
            catch
            {
                return View();
            }
        }







         [Authorize]
        public ActionResult BorrarLineaCesta(int id)
        {
            try
            {
                
                LineaPedidoEN linPedEN = new LineaPedidoCAD(session).ReadOIDDefault(id);
                PracticaGenNHibernate.CP.Practica.PedidoCP a = new PracticaGenNHibernate.CP.Practica.PedidoCP();
               int id_pedido =linPedEN.Pedido.Id;
                new LineaPedidoCEN().Destroy(id);
                a.CalcularPrecio(id_pedido);
                Session["Clineas"] = Convert.ToInt32(Session["Clineas"]) - 1;
                return RedirectToAction("../Cesta/Index");
            }
            catch
            {
                return View();
            }
        }

         [Authorize]
        public ActionResult anyadirCantidadLinea(int id)
        {
            //LineaPedido linPed = null;
            SessionInitialize();
            LineaPedidoEN linPedEN = new LineaPedidoCAD(session).ReadOIDDefault(id);
            LineaPedidoCEN cen = new LineaPedidoCEN();
            cen.Modify(id, linPedEN.Cantidad + 1, linPedEN.Valoracion);
            PracticaGenNHibernate.CP.Practica.PedidoCP a = new PracticaGenNHibernate.CP.Practica.PedidoCP();
            a.CalcularPrecio(linPedEN.Pedido.Id);

            //linPed = new AssemblerLineaPedido().ConvertENToModelUI(linPedEN, session);
            SessionClose();
            return RedirectToAction("../Cesta/Index");
        }

         [Authorize]
        public ActionResult restarCantidadLinea(int id)
        {
            //LineaPedido linPed = null;
            SessionInitialize();
            LineaPedidoEN linPedEN = new LineaPedidoCAD(session).ReadOIDDefault(id);
            LineaPedidoCEN cen = new LineaPedidoCEN();
            if (linPedEN.Cantidad > 1) {
                cen.Modify(id, linPedEN.Cantidad - 1, linPedEN.Valoracion);
                PracticaGenNHibernate.CP.Practica.PedidoCP a = new PracticaGenNHibernate.CP.Practica.PedidoCP();
                a.CalcularPrecio(linPedEN.Pedido.Id);
            }
                

            //linPed = new AssemblerLineaPedido().ConvertENToModelUI(linPedEN, session);
            SessionClose();
            return RedirectToAction("../Cesta/Index");
        }

        //
        // GET: /LineaPedido/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            try
            {

                LineaPedidoEN linPedEN = new LineaPedidoCAD(session).ReadOIDDefault(id);
                PracticaGenNHibernate.CP.Practica.PedidoCP a = new PracticaGenNHibernate.CP.Practica.PedidoCP();
                int id_pedido = linPedEN.Pedido.Id;
                new LineaPedidoCEN().Destroy(id);
                a.CalcularPrecio(id_pedido);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /LineaPedido/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

