﻿using MvcApplication1.Models;
using PracticaGenNHibernate.CEN.Practica;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticaGenNHibernate.CP.Practica;

namespace MvcApplication1.Controllers
{
    public class CodigoController : BasicController
    {
        //
        // GET: /Codigo/
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Index()
        {
            CodigoCEN cod = new CodigoCEN();
            IList<CodigoEN> coden = cod.ReadAll(0, -1);
            IEnumerable<Codigo> list = new AssemblerCodigo().ConvertListENToModel(coden, session).ToList();
            return View(list);
        }

        //
        // GET: /Codigo/Details/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Codigo/Create
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Create()
        {
            Codigo cod = new Codigo();
            return View(cod);
        }

        //
        // POST: /Codigo/Create

        [HttpPost]
        public ActionResult Create(Codigo cod)
        {
            try
            {
                CodigoCEN codigo = new CodigoCEN();
                codigo.New_(cod.Descuento, cod.Tipo, cod.Numero);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [Authorize]
        public ActionResult Comprobar(String cod)
        {
            try
            {
                SessionInitialize();
                CodigoCEN codigo = new CodigoCEN(new CodigoCAD(session));
                IList<CodigoEN> codigichi = codigo.ReadAll(0, -1);
                PedidoCP p = new PedidoCP(session);


                foreach (CodigoEN c in codigichi)
                {

                    if (c.Numero.Equals(cod))
                    {
                        int idCodigo = c.Id;
                        PedidoCEN pedidoCEN = new PedidoCEN();
                        UsuarioCEN usuarioCEN = new UsuarioCEN(new UsuarioCAD(session));
                        IList<UsuarioEN> usuario = usuarioCEN.BuscarUsuario(User.Identity.Name);
                        IList<PedidoEN> pedidos = pedidoCEN.DevolverPedidosUsuario(usuario[0].Nombre);
                        //Request.Form["cantidad"].AsInt();
                        //aqui busco el ultimo pedido que es el actual del usuario
                        if (pedidos.Count > 0)
                        {
                            int id = pedidos[(pedidos.Count) - 1].Id;
                            pedidoCEN.AnyadirCodigo(id, idCodigo);

                        }
                    }
                    else
                    {
                        return RedirectToAction("Error", "Codigo"); //no existe el codigichi
                    }

                }
                SessionClose();

                return RedirectToAction("Index", "Cesta"); //no existe el codigichi

            }
            catch
            {
                return View();
            }
        }


        //
        // GET: /Codigo/Create
        [Authorize]
        public ActionResult Error()
        {

            return View();
        }



        //
        // GET: /Codigo/Edit/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Edit(int id)
        {
            Codigo cod = null;
            SessionInitialize();
            CodigoEN codEN = new CodigoCAD(session).ReadOIDDefault(id);
            cod = new AssemblerCodigo().ConvertENToModelUI(codEN, session);
            SessionClose();
            return View(cod);
        }

        //
        // POST: /Codigo/Edit/5

        [HttpPost]
        public ActionResult Edit(Codigo cod)
        {
            try
            {
                // TODO: Add update logic here
                CodigoCEN codcen = new CodigoCEN();
                codcen.Modify(cod.Id, cod.Descuento, cod.Tipo, cod.Numero);

                return RedirectToAction("Index");
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
                new CodigoCEN().Destroy(id);
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
    }
}