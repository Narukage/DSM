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
    public class BebidaController : BasicController
    {
        //
        // GET: /Bebida/

        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Index()
        {
            BebidaCEN cen = new BebidaCEN();
            IEnumerable<BebidaEN> list = cen.ReadAll(0, -1).ToList();
            return View(list);
        }

        public ActionResult IndexUser()
        {
            BebidaCEN cen = new BebidaCEN();
            IEnumerable<BebidaEN> list = cen.ReadAll(0, -1).ToList();
            return View(list);
        }


        //
        // GET: /Bebida/Details/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Details(int id)
        {
            Bebida bebida = null;
           
            BebidaEN bebidaEN = new BebidaCAD().ReadOIDDefault(id);
            bebida = new AssemblerBebida().ConvertENToModelUI(bebidaEN);
            
            return View(bebida);
        }

        //
        // GET: /Bebida/Create
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Create()
        {

            Bebida brebaje = new Bebida();
 
            return View(brebaje);
        }

        //
        // POST: /Bebida/Create

        [HttpPost]
        public ActionResult Create(Bebida brebaje, HttpPostedFileBase file)
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
                BebidaCEN beb = new BebidaCEN();
                beb.New_(double.Parse(brebaje.precio, System.Globalization.CultureInfo.InvariantCulture), brebaje.nombre, fileName, 0);
                return RedirectToAction("PanelAdmin", "Home");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Bebida/Edit/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Edit(int id)
        {
            Bebida beb = null;
            SessionInitialize();
            BebidaEN bebEN = new BebidaCAD(session).ReadOIDDefault(id);
            beb = new AssemblerBebida().ConvertENToModelUI(bebEN);
            SessionClose();
            return View(beb);
        }

        //
        // POST: /Bebida/Edit/5

        [HttpPost]
        public ActionResult Edit(Bebida beb, HttpPostedFileBase file)
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
                BebidaCEN cen = new BebidaCEN();
                if (fileName == "")
                {
                    fileName = beb.foto;
                }
                else
                {
                    fileName = "/Images/Uploads/" + fileName;
                }

                cen.Modify(beb.id, double.Parse(beb.precio, System.Globalization.CultureInfo.InvariantCulture), beb.nombre, fileName, beb.numveces);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Bebida/Delete/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Delete(int id)
        {
            try
            {
                new BebidaCEN().Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Bebida/Delete/5

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
            BebidaCEN p = new BebidaCEN();
            IList<BebidaEN> lista = p.TopVentas();
            IEnumerable<Bebida> list = new AssemblerBebida().ConvertListEnToModel(lista).ToList();
            return View(list);
        }

    }
}
