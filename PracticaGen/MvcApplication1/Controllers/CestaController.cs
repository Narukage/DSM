using MvcApplication1.Models;
using PracticaGenNHibernate.CEN.Practica;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.CP.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class CestaController : BasicController
    {
        //
        // GET: /Cesta/
        [Authorize]
        public ActionResult Index()
        {
            SessionInitialize();
            PedidoCEN ped = new PedidoCEN(new PedidoCAD(session));
            UsuarioCEN usu = new UsuarioCEN(new UsuarioCAD(session));
            PedidoCP p = new PedidoCP(session);
            

            usu = new UsuarioCEN(new UsuarioCAD(session));
            IList<UsuarioEN> inci = usu.UsuarioPorEmail(User.Identity.Name);
            Usuario usu1 = new AssemblerUsuario().ConvertENToModelUI(inci.Last(), session);


            IList<PedidoEN> listaPedidoUsu = ped.DevolverPedidosUsuario(User.Identity.Name);
            PedidoEN pedEn = listaPedidoUsu.Last();

            if (pedEn.Codigo != null)
            {
                double actualizado = p.CalcularPrecio(pedEn.Id);
                ped.Descontar(pedEn.Id, actualizado);

            }


            PedidoCP pedCP = new PedidoCP(session);
            Pedido ped1 = new AssemblerPedido().ConvertENToModelUI(pedEn, session);

            IEnumerable<Cesta> cesta = new AssemblerCesta().ConvertListENToModel(ped1, usu1);
            SessionClose();
            

            return View(cesta);
        }

        [HttpPost]
        public ActionResult Index(Cesta cesta)
        {

            try
            {
                PedidoCEN pedCEN = new PedidoCEN();
                PedidoCP ped = new PedidoCP();
                pedCEN.Modify(cesta.pedido.Id,PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum.pendiente, DateTime.Now, cesta.pedido.PrecioTotal, cesta.pedido.TipoPago,true ,cesta.pedido.valoracion);            
                PedidoEN p = pedCEN.ReadOID(cesta.pedido.Id);
                //Aqui faltaria pillar la direccion a través de su id pero como no servia para na pues GG

                pedCEN.AnyadirDireccion(cesta.pedido.Id,cesta.usuario.direccion[0].id);

                PedidoCEN nuevo = new PedidoCEN();

                nuevo.New_(PracticaGenNHibernate.Enumerated.Practica.EstadoPedidoEnum.pendiente, DateTime.Now, 0.0, PracticaGenNHibernate.Enumerated.Practica.TipoPagoEnum.contrarreembolso, cesta.usuario.id, false, 0.0);
                ped.Confirmar(p.Id);
                Session["Clineas"] = 0;

                return RedirectToAction("PedidosUsuario", "Account");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cesta/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Cesta/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cesta/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cesta/Edit/5

        public ActionResult Edit()
        {
           /* SessionInitialize();
            PedidoCEN ped = new PedidoCEN(new PedidoCAD(session));
            UsuarioCEN usu = new UsuarioCEN();


            usu = new UsuarioCEN(new UsuarioCAD(session));
            IList<UsuarioEN> inci = usu.ReadAll(0, -1);
            Usuario usu1 = new AssemblerUsuario().ConvertENToModelUI(inci.Last(), session);


            IList<PedidoEN> listaPedidoUsu = ped.DevolverPedidosUsuario(User.Identity.Name);
            PedidoEN pedEn = listaPedidoUsu.Last();
            PedidoCP pedCP = new PedidoCP(session);
            Pedido ped1 = new AssemblerPedido().ConvertENToModelUI(pedEn, session);


            IEnumerable<Cesta> cesta = new AssemblerCesta().ConvertListENToModel(ped1, usu1);
            SessionClose();*/


            return View();
           
        }

        //
        // POST: /Cesta/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) //int id, FormCollection collection
        {
          
                return View();
            
        }

        //
        // GET: /Cesta/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Cesta/Delete/5

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