using MvcApplication1.Models;
using PracticaGenNHibernate.CEN.Practica;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class VistaPersonalizadaController : BasicController
    {
        //
        // GET: /VistaPersonalizada/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /VistaPersonalizada/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /VistaPersonalizada/Create

        [Authorize]
        public ActionResult Create0()
        {

            Personalizada per = new Personalizada();
            PersonalizableCEN personali = new PersonalizableCEN();
            int id = personali.New_(4, "Pizza Personalizada", "/Images/Uploads/personali.jpg", 0, PracticaGenNHibernate.Enumerated.Practica.TamanyoEnum.normal, PracticaGenNHibernate.Enumerated.Practica.TipoMasaEnum.clasica); 

            return RedirectToAction("Create", "VistaPersonalizada", new {idpizza = id });
           
        }

        [Authorize]
        public ActionResult Create(int idpizza)
        {
            IngredienteCEN pred = new IngredienteCEN();
           IList<IngredienteEN> L_ingredientes = pred.ReadAll(0,-1);
            Personalizada per= new Personalizada();    
            SessionInitialize();
            PersonalizableEN predEN = new PersonalizableCAD(session).ReadOIDDefault(idpizza);
            per = new AssemblerPersonalizada().ConvertENToModelUI(predEN,session);
            SessionClose();

            VistaPersonalizada list = new AssemblerVistaPersonalizabel().ConvertENToModelUI(per, L_ingredientes);
            
            return View(list);
        }

        //
        // POST: /VistaPersonalizada/Create

        [HttpPost]
        public ActionResult Create(VistaPersonalizada per, int cantidad)
        {
            try
            {
                PersonalizableCEN cen = new PersonalizableCEN();
                cen.Modify(per.personalizada.Id, per.personalizada.Precio, "Pizza Personalizada", "/Images/Uploads/personali.jpg",per.personalizada.NumVeces, per.personalizada.tamaño, per.personalizada.masa);

                return RedirectToAction("CreateyAnyade", "LineaPedido",new { id = per.personalizada.Id, cantidad = cantidad ,vuelve ="Personalizada" });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /VistaPersonalizada/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /VistaPersonalizada/Edit/5

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
        // GET: /VistaPersonalizada/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /VistaPersonalizada/Delete/5

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
