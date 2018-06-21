using MvcApplication1.Models;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.CEN.Practica;
using PracticaGenNHibernate.CP.Practica;
using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class PedidoController : BasicController
    {
        //
        // GET: /Codigo/
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Index()
        {
            SessionInitialize();
            PedidoCEN cod = new PedidoCEN(new PedidoCAD(session));
            IList<PedidoEN> coden = cod.ReadAll(0, -1);
            IEnumerable<Pedido> list = new AssemblerPedido().ConvertListENToModel(coden, session).ToList();
            SessionClose();
            return View(list);
        }
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult IndexEdit()
        {
            SessionInitialize();
            PedidoCEN ped = new PedidoCEN(new PedidoCAD(session));
            IList<PedidoEN> pedEn = ped.ReadAll(0, -1);
            IEnumerable<Pedido> list = new AssemblerPedido().ConvertListENToModel(pedEn, session);
            SessionClose();
            return View(list);
        }
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult IndexDel()
        {
            SessionInitialize();
            PedidoCEN pred = new PedidoCEN(new PedidoCAD(session));
            IList<PedidoEN> pedEn = pred.ReadAll(0, -1);
            IEnumerable<Pedido> list = new AssemblerPedido().ConvertListENToModel(pedEn, session).ToList();
            SessionClose();
            return View(list);
        }

        //
        // GET: /Codigo/Details/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Details(int id)
        {
            SessionInitialize();
            PedidoCEN pedidoCEN = new PedidoCEN(new PedidoCAD(session));
            PedidoEN pedidoEN = pedidoCEN.ReadOID(id);
            Pedido ped = new AssemblerPedido().ConvertENToModelUI(pedidoEN,session);
            SessionClose();
            return View(ped);
        }

        //
        // GET: /Codigo/Create
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Create()
        {
         
            Pedido cod = new Pedido();
            return View(cod);
        }

        //
        // POST: /Codigo/Create
        [Authorize(Users = "Admin@epizza.com")]
        [HttpPost]
        public ActionResult Create(Pedido ped)
        {
          
            try
            {
         
                PedidoCEN pedido = new PedidoCEN();
               int i= pedido.New_(ped.Estado, ped.Fecha, ped.PrecioTotal, ped.TipoPago,ped.iduser,false,0.0);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Codigo/Edit/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Edit(int id)
        {
            Pedido cod = null;
            SessionInitialize();
            PedidoEN codEN = new PedidoCAD(session).ReadOIDDefault(id);
            cod = new AssemblerPedido().ConvertENToModelUI(codEN, session);
            SessionClose();
            return View(cod);
        }

        //
        // POST: /Codigo/Edit/5
        [Authorize(Users = "Admin@epizza.com")]
        [HttpPost]
        public ActionResult Edit(Pedido cod)
        {
            try
            {

                // TODO: Add update logic here
                Boolean confirmado = false;
                PedidoCEN codcen = new PedidoCEN();
                if (cod.Confirmado == true)
                    confirmado = true;
                codcen.Modify(cod.Id, cod.Estado, cod.Fecha, cod.PrecioTotal, cod.TipoPago, confirmado,cod.valoracion);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Pedido/CalcularMedia
        [Authorize]
        public ActionResult CalcularMedia(int id)
        {

            try
            {
                SessionInitialize();
                PedidoCP pedidoCP = new PedidoCP(session);
                double media = pedidoCP.CalcularMedia(id);
                PedidoCEN pedidoCEN = new PedidoCEN();
                pedidoCEN.CambiarValoracion(id, media);
                SessionClose();
                return RedirectToAction("PedidosUsuario", "Account");
            }
            catch
            {
                return View();
            }
        }


        //
        // GET: /Producto/Busqueda

        [AllowAnonymous]
        public ActionResult Busqueda()
        {
            return PartialView();
        }

        //
        // GET: /Producto/Busqueda/nombre
        [HttpPost]
        [AllowAnonymous]
        public ActionResult BusquedaPost(int id)
        {
            try
            {
                SessionInitialize();
                PedidoCAD pCAD = new PedidoCAD(session);
                PedidoCEN pCEN = new PedidoCEN(pCAD);
                AssemblerPedido assemblerPedido= new AssemblerPedido();
                IList<PedidoEN> listaP = pCEN.BuscarPedido(id);
                IList<Pedido> Return = assemblerPedido.ConvertListENToModel(listaP, session);
                SessionClose();
                if (Return.Count > 0)
                {
                    return View(Return);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult BusquedaPorUsuario()
        {
            return PartialView();
        }

        //
        // GET: /Producto/Busqueda/nombre
        [HttpPost]
        [AllowAnonymous]
        public ActionResult BusquedaPorUsuarioPost(string nombre)
        {
            try
            {
                SessionInitialize();
                PedidoCAD pCAD = new PedidoCAD(session);
                PedidoCEN pCEN = new PedidoCEN(pCAD);
                AssemblerPedido assemblerPedido = new AssemblerPedido();
                IList<PedidoEN> listaP = pCEN.DevolverPedidosUsuario(nombre);
                IList<Pedido> Return = assemblerPedido.ConvertListENToModel(listaP, session);
                SessionClose();
                if (Return.Count > 0)
                {
                    return View(Return);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }


        //
        // GET: /Codigo/Delete/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Delete(int id)
        {
            try
            {
                new PedidoCEN().Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Codigo/Delete/5

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


           // GET: /Pedido/PedidosMensuales/mes
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult CodigosActivados()
        {
            try
            {

                SessionInitialize();
                PedidoCAD pCAD = new PedidoCAD(session);
                PedidoCEN pCEN = new PedidoCEN(pCAD);

                CodigoCAD cCAD = new CodigoCAD(session);
                CodigoCEN cCEN = new CodigoCEN(cCAD);

                DataTable tabla = new DataTable("codigosactivados");

                tabla.Columns.Add("Nº de veces", typeof(int));
                tabla.Columns.Add("Código", typeof(string));



                IList <PedidoEN> todos= pCEN.ReadAll(0,-1);
                IList <CodigoEN> codigos = cCEN.ReadAll(0,-1);
                int cont=0;
                int poraqui=0;
                foreach(PedidoEN p in todos){


                    if(p.Codigo!=null){

                        foreach(CodigoEN c in codigos){
                                  poraqui++;
                                if(c.Id.Equals(p.Codigo.Id)){
                                  cont++;
                                 if(poraqui==codigos.Count){
                                  DataRow row =tabla.NewRow();
                                  row["Nº de veces"]= cont;
                                  row["Código"]= c.Numero;
                                     tabla.Rows.Add(row);
                                 poraqui=0;
                                 cont=0;
                                 }

                                }
                                }

                    }

                }

                SessionClose();
                if (tabla != null)
                {

                    return View(tabla);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

    































        // GET: /Pedido/PedidosMensuales/mes
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult PedidosMensualesPost()
        {
            try
            {

                SessionInitialize();
                PedidoCAD pCAD = new PedidoCAD(session);
                PedidoCEN pCEN = new PedidoCEN(pCAD);

                DataTable tabla = new DataTable("pedidosmensuales");

                tabla.Columns.Add("Nº de pedidos", typeof(int));
                tabla.Columns.Add("Mes", typeof(string));


                for (int i = 1; i <= 12; i++)
                {
                    long total = pCEN.PedidosMensuales(i);
                    ViewData["Veces"] = total;

                    switch (i)
                    {
                        case 1:
                            ViewData["Mes"] = "Enero";
                            break;
                        case 2:
                            ViewData["Mes"] = "Febrero";
                            break;
                        case 3:
                            ViewData["Mes"] = "Marzo";
                            break;
                        case 4:
                            ViewData["Mes"] = "Abril";
                            break;
                        case 5:
                            ViewData["Mes"] = "Mayo";
                            break;
                        case 6:
                            ViewData["Mes"] = "Junio";
                            break;
                        case 7:
                            ViewData["Mes"] = "Julio";
                            break;
                        case 8:
                            ViewData["Mes"] = "Agosto";
                            break;
                        case 9:
                            ViewData["Mes"] = "Septiembre";
                            break;
                        case 10:
                            ViewData["Mes"] = "Octubre";
                            break;
                        case 11:
                            ViewData["Mes"] = "Noviembre";
                            break;
                        case 12:
                            ViewData["Mes"] = "Diciembre";
                            break;
                    }
                    DataRow row = tabla.NewRow();

                    row["Nº de pedidos"] = total;
                    row["Mes"] = ViewData["Mes"];

                    tabla.Rows.Add(row);



                }

                SessionClose();
                if (tabla != null)
                {

                    return View(tabla);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

    }
}

