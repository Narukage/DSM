using MvcApplication1.Models;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.CEN.Practica;
using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class PredefinidaController : BasicController
    {
        //
        // GET: /Predefinida/
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Index()
        {
           PredefinidaCEN pred = new PredefinidaCEN();
           IList<PredefinidaEN> predEn = pred.ReadAll(0,-1);
           IEnumerable<Predefinida> list = new AssemblerPredefinida().ConvertListENToModel(predEn).ToList(); 
            return View(list);
        }

        public ActionResult IndexUser()
        {
            PredefinidaCEN pred = new PredefinidaCEN();
            IList<PredefinidaEN> predEn = pred.ReadAll(0, -1);
            IEnumerable<Predefinida> list = new AssemblerPredefinida().ConvertListENToModel(predEn).ToList();
            return View(list);
        }

        //
        // GET: /Predefinida/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Predefinida/Create
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Create()
        {
            Predefinida pred = new Predefinida();
            return View(pred);
        }

        //
        // POST: /Predefinida/Create

        [HttpPost]
        public ActionResult Create(Predefinida pizza, HttpPostedFileBase file)
        {

            string fileName = "", path = "";
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                path = Path.Combine(Server.MapPath("~/Images/Uploads"), fileName);
                //string pathDef = path.Replace(@"\\", @"\");
                file.SaveAs(path);
            }
            try
            {
                // TODO: Add insert logic here
                fileName = "/Images/Uploads/" + fileName;
                PredefinidaCEN pred = new PredefinidaCEN();
                pred.New_(double.Parse(pizza.precio, System.Globalization.CultureInfo.InvariantCulture), pizza.Nombre, fileName, pizza.NumVeces, pizza.tamaño, pizza.masa, pizza.Descripcion);

                return RedirectToAction("PanelAdmin", "Home");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Predefinida/Edit/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Edit(int id)
        {
            Predefinida pred = null;
            SessionInitialize();
            PredefinidaEN predEN = new PredefinidaCAD(session).ReadOIDDefault(id);
            pred = new AssemblerPredefinida().ConvertENToModelUI(predEN);
            SessionClose();
            return View(pred);
        }

        //
        // POST: /Predefinida/Edit/5

        [HttpPost]
        public ActionResult Edit(Predefinida pizza, HttpPostedFileBase file)
        {
            string fileName = "", path = "";
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                fileName = Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                path = Path.Combine(Server.MapPath("~/Images/Uploads"), fileName);
                //string pathDef = path.Replace(@"\\", @"\");
                file.SaveAs(path);
            }
            
            try
            {
                  
                // TODO: Add update logic here
                PredefinidaCEN cen = new PredefinidaCEN();
                if (fileName == "")
                {
                    fileName = pizza.Foto;
                }
                else {
                    fileName = "/Images/Uploads/" + fileName;
                }

                cen.Modify(pizza.Id, double.Parse(pizza.precio, System.Globalization.CultureInfo.InvariantCulture), pizza.Nombre, fileName, pizza.NumVeces, pizza.tamaño, pizza.masa, pizza.Descripcion);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Predefinida/Delete/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Delete(int id)
        {

            try
            {
                new PredefinidaCEN().Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Predefinida/Delete/5

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

        public ActionResult Top()
        {
            PredefinidaCEN p = new PredefinidaCEN();
            IList<PredefinidaEN> lista = p.TopVentas();
            IEnumerable<Predefinida> list = new AssemblerPredefinida().ConvertListENToModel(lista).ToList();
            return View(list);
        }

    }
}
