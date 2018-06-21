using MvcApplication1.Models;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.CEN.Practica;
using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class RegistradoController : BasicController
    {
        //
        // GET: Registrado/
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Index()
        {
            RegistradoCEN inc = new RegistradoCEN();
            IList<RegistradoEN> inci = inc.ReadAll(0, -1);
            IEnumerable<Registrado> list = new AssemblerRegistrado().ConvertListENToModel(inci).ToList();
            return View(list);
        }

        //
        // GET: /Registrado/Details/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Details(int id)
        {
            Registrado u = null;
            SessionInitialize();
            RegistradoEN uEN = new RegistradoCAD(session).ReadOID(id);
            u = new AssemblerRegistrado().ConvertENToModelUI(uEN);
            SessionClose();
            return View(u);
        }

        //
        // GET: /Registrado/Create
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Create()
        {
            Registrado reg = new Registrado();
            return View(reg);
        }

        //
        // POST: /Registrado/Create

        [HttpPost]
        public ActionResult Create(Registrado u)
        {
            try
            {
                RegistradoCEN pred = new RegistradoCEN();
                pred.New_(u.email,u.nombre,u.contrasenya,u.fecha_nac,u.telefono,DateTime.Today);
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Registrado/Edit/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Edit(int id)
        {
            Registrado u = null;
            SessionInitialize();
            RegistradoEN uEN = new RegistradoCAD(session).ReadOID(id);
            u = new AssemblerRegistrado().ConvertENToModelUI(uEN);
            SessionClose();
            return View(u);
        }

        //
        // POST: /Registrado/Edit/5

        [HttpPost]
        public ActionResult Edit(Registrado u)
        {
            try
            {
                // TODO: Add update logic here
                RegistradoCEN uCEN = new RegistradoCEN();
                uCEN.Modify(u.id, u.email, u.nombre, u.contrasenya, u.fecha_nac, u.telefono, u.fecha_reg);
   

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Registrado/Delete/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Delete(int id)
        {
            try
            {
                new RegistradoCEN().Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Registrado/Delete/5

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
