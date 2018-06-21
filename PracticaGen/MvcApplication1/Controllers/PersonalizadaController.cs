using MvcApplication1.Models;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.CEN.Practica;
using PracticaGenNHibernate.CP.Practica;
using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class PersonalizadaController : BasicController
    {
        //
        // GET: /Personalizada/
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Index()
        {
            SessionInitialize();
            PersonalizableCEN pred = new PersonalizableCEN(new PersonalizableCAD(session));
            IList<PersonalizableEN> predEn = pred.ReadAll(0, -1);
            IEnumerable<Personalizada> list = new AssemblerPersonalizada().ConvertListENToModel(predEn,session).ToList();
            SessionClose();
            return View(list);
        }

        //
        // GET: /Personalizada/Details/5

        public ActionResult Details(int id)
        {
            Personalizada pers = null;
            SessionInitialize();
            PersonalizableEN en = new PersonalizableCAD(session).ReadOIDDefault(id);
            pers = new AssemblerPersonalizada().ConvertENToModelUI(en, session);
            SessionClose();
            return View(pers);
        }

        //
        // GET: /Personalizada/Create

        public ActionResult Create()
        {
           
            return View();
        }

        //
        // POST: /Personalizada/Create

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
        // GET: /Personalizada/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Personalizada/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Personalizada/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Personalizada/Delete/5

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

        // POST: /Personalizada/anyadirIngrediente
        public ActionResult anyadirIngrediente(int id, int pizzaid)
        {
            try
            {
                SessionInitialize();
               
                IList<int> lista = new List<int>();

                PersonalizableEN pizza = new PersonalizableCAD(session).ReadOIDDefault(pizzaid);
                Boolean existe = false;
                foreach (IngredienteEN eo in pizza.Ingrediente)
                {
                    if (eo.Id == id)
                        existe = true;
                }
               
                if (existe == false)
                {
                    lista.Add(id);
                    PersonalizableCP perso = new PersonalizableCP();
                    perso.AnaydirIngrediente(pizzaid, lista);
                }
                
               
                SessionClose();

                return RedirectToAction("Create", "VistaPersonalizada", new {idpizza=pizzaid });
            }
            catch
            {
                return RedirectToAction("Create", "VistaPersonalizada");
            }
        }


        public ActionResult eliminarIngrediente(int id, int pizzaid)
        {
            try
            {
                SessionInitialize();

                IList<int> lista = new List<int>();

                lista.Add(id);

                PersonalizableEN pizza3 = new PersonalizableCAD(session).ReadOIDDefault(pizzaid);
                Boolean existe = false;
                foreach (IngredienteEN eo in pizza3.Ingrediente)
                {
                    if (eo.Id == id)
                        existe = true;
                }

                if (existe == true)
                {

                    PersonalizableCP perso = new PersonalizableCP();
                    perso.EliminarIngrediente(pizzaid, lista);
                }
                SessionClose();

                return RedirectToAction("Create", "VistaPersonalizada", new { idpizza = pizzaid });
            }
            catch
            {
                return RedirectToAction("Create", "VistaPersonalizada");
            }
        }
    }
}
