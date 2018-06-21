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
    public class IngredienteController : BasicController
    {
        //
        // GET: /Ingrediente/
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Index()
        {
            SessionInitialize();
            IngredienteCEN pred = new IngredienteCEN();
            IList<IngredienteEN> predEn = pred.ReadAll(0, -1);
            IEnumerable<Ingrediente> list = new AssemblerIngrediente().ConvertListENToModel(predEn,session).ToList();
            SessionClose();
            return View(list);
        }

        //
        // GET: /Ingrediente/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Ingrediente/Create
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Create()
        {
            Ingrediente ing = new Ingrediente();
            return View(ing);

        }

        //
        // POST: /Ingrediente/Create

        [HttpPost]
        public ActionResult Create(Ingrediente ing, HttpPostedFileBase file)
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
                fileName = "/Images/Uploads/" + fileName;
                IngredienteCEN ingre = new IngredienteCEN();
                ingre.New_(double.Parse(ing.precio, System.Globalization.CultureInfo.InvariantCulture), ing.Nombre, fileName, 0);
                return RedirectToAction("PanelAdmin","Home");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Ingrediente/Edit/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Edit(int id)
        {
            Ingrediente pred = null;
            SessionInitialize();
            IngredienteEN predEN = new IngredienteCAD(session).ReadOIDDefault(id);
            pred = new AssemblerIngrediente().ConvertENToModelUI(predEN,session);
            SessionClose();
            return View(pred);
        }

        //
        // POST: /Ingrediente/Edit/5

        [HttpPost]
        public ActionResult Edit(Ingrediente ing, HttpPostedFileBase file)
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
                 IngredienteCEN cen = new IngredienteCEN();
                if (fileName == "")
                {
                    fileName = ing.Foto;
                }
                else {
                    fileName = "/Images/Uploads/" + fileName;
                }

                cen.Modify(ing.Id, double.Parse(ing.precio, System.Globalization.CultureInfo.InvariantCulture), ing.Nombre, fileName, ing.NumVeces);

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Ingrediente/Delete/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Delete(int id)
        {
            try
            {
                new IngredienteCEN().Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Ingrediente/Delete/5

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
