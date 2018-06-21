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
    public class DireccionController : BasicController
    {
        //
        // GET: /Direccion/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Direccion/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Direccion/Create

        public ActionResult Create()
        {
            Direccion dir = new Direccion();
            return View(dir);
        }

        //
        // POST: /Direccion/Create

        [HttpPost]
        public ActionResult Create(Direccion d)
        {
            try
            {
                DireccionCEN dir = new DireccionCEN();
                int id_dir =dir.New_(d.localidad,d.provincia,d.calle,d.codp,d.numero);
                UsuarioCEN u = new UsuarioCEN();
                IList<UsuarioEN> uEN = u.UsuarioPorEmail(User.Identity.Name);
                IList<int> lista = new List<int>();
                lista.Add(id_dir);
                u.AnyadirDireccion(uEN[0].Id,lista);
                return RedirectToAction("Perfil", "Account");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Direccion/Edit/5

        public ActionResult Edit(int id)
        {
            SessionInitialize();
            DireccionEN uEN = new DireccionCAD(session).ReadOID(id);
            Direccion u = new AssemblerDireccion().ConvertENToModelUI(uEN,session);
            SessionClose();
            return View(u);
        }

        //
        // POST: /Direccion/Edit/5

        [HttpPost]
        public ActionResult Edit(Direccion dir)
        {
            try
            {
                DireccionCEN dCEN = new DireccionCEN();
                dCEN.Modify(dir.id,dir.localidad,dir.provincia,dir.calle,dir.codp,dir.numero);

                return RedirectToAction("Perfil", "Account");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Direccion/Delete/5

        public ActionResult Delete(int id)
        {
            IList<int> lista = new List<int>();
            lista.Add(id);

            UsuarioEN u = new UsuarioCEN().UsuarioPorEmail(User.Identity.Name)[0];

            new UsuarioCEN().EliminarDireccion(u.Id,lista);
            new DireccionCEN().Destroy(id);
            return RedirectToAction("Perfil","Account");
        }

        //
        // POST: /Direccion/Delete/5

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
