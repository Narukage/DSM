using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PracticaGenNHibernate.CEN.Practica;
using PracticaGenNHibernate.EN.Practica;
using PracticaGenNHibernate.CAD.Practica;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class ComplementoController : BasicController
    {
        //
        // GET: /Complemento/
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Index()
        {
            ComplementoCEN cen = new ComplementoCEN();
            IEnumerable<ComplementoEN> list = cen.ReadAll(0, -1).ToList();
            return View(list);
        }

        public ActionResult IndexUser()
        {
            ComplementoCEN cen = new ComplementoCEN();
            IEnumerable<ComplementoEN> list = cen.ReadAll(0, -1).ToList();
            return View(list);
        }
        //
        // GET: /Complemento/Details/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Complemento/Create
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Create()
        {
            Complemento complem = new Complemento();
            return View(complem);
        }

        //
        // POST: /Complemento/Create

        [HttpPost]
        public ActionResult Create(Complemento complemento, HttpPostedFileBase file)
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
                ComplementoCEN complem = new ComplementoCEN();
                complem.New_(double.Parse(complemento.precio, System.Globalization.CultureInfo.InvariantCulture), complemento.nombre, fileName, complemento.numVeces);

                return RedirectToAction("PanelAdmin", "Home");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Complemento/Edit/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Edit(int id)
        {

            Complemento complem = null;
            SessionInitialize();
            ComplementoEN complemEN = new ComplementoCAD(session).ReadOIDDefault(id);
            complem = new AssemblerComplemento().ConvertENToModelUI(complemEN);
            SessionClose();
            return View(complem);
        }

        //
        // POST: /Complemento/Edit/5

        [HttpPost]
        public ActionResult Edit(Complemento complemento, HttpPostedFileBase file)
        {
            string fileName = "", path = "";
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
                ComplementoCEN complemCEN = new ComplementoCEN();
                if(fileName == "")
                {
                    fileName = complemento.foto;
                }
                else
                {
                    fileName = "Images/uploads/" + fileName;
                }
                complemCEN.Modify(complemento.id, double.Parse(complemento.precio, System.Globalization.CultureInfo.InvariantCulture), complemento.nombre, fileName, complemento.numVeces);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Complemento/Delete/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Delete(int id)
        {
            try
            {
                new ComplementoCEN().Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }

        //
        // POST: /Complemento/Delete/5

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
            ComplementoCEN p = new ComplementoCEN();
            IList<ComplementoEN> lista = p.TopVentas();
            IEnumerable<Complemento> list = new AssemblerComplemento().ConvertListENToModel(lista).ToList();
            return View(list);
        }

    }
}
