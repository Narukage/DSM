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
    public class ProductoController : BasicController
    {
        //
        // GET: Producto//
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult IndexEdit()
        {
            SessionInitialize();
            ProductoCEN pred = new ProductoCEN(new ProductoCAD());
            IList<ProductoEN> predEn = pred.ReadAll(0, -1);        
            IList<ProductoEN> definitiva = new List<ProductoEN>();

            foreach (ProductoEN p in predEn) {
                if (!p.GetType().Name.Equals("PersonalizableEN")) {
                    definitiva.Add(p);
                }
            }
            
            IEnumerable<Producto> list = new AssemblerProducto().ConvertListENToModel(definitiva, session).ToList();
            SessionClose();
            return View(list);
        }
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult IndexDel()
        {
            SessionInitialize();
            ProductoCEN pred = new ProductoCEN(new ProductoCAD());
            IList<ProductoEN> predEn = pred.ReadAll(0, -1);

            IList<ProductoEN> definitiva = new List<ProductoEN>();

            foreach (ProductoEN p in predEn) {
                if (!p.GetType().Name.Equals("PersonalizableEN")) {
                    definitiva.Add(p);
                }
            }
            IEnumerable<Producto> list = new AssemblerProducto().ConvertListENToModel(definitiva, session).ToList();
            SessionClose();
            return View(list);
        }

        public ActionResult seleccionTipo()
        {
          
            return View();
        }
        //
        // GET: /Producto/Details/5

        public ActionResult Details(int id)
        {

          /*  Producto pro = null;
            SessionInitialize();
            ProductoEN proEN = new ProductoCAD(session).ReadOIDDefault(id);
            pro = new AssemblerProducto().ConvertENToModelUI(proEN,session);
            SessionClose();*/
            return View();

        }

        //
        // GET: /Producto/Create
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Create()
        {
            Producto pred = new Producto();
            return View(pred);
        }

        //
        // POST: /Producto/Create

        [HttpPost]
        public ActionResult Create(Producto pro, HttpPostedFileBase file)
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
                ProductoCEN pred = new ProductoCEN();
                pred.New_((double)pro.Precio, pro.Nombre, fileName, pro.NumVeces);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Producto/Edit/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Edit(int id)
        {
            Producto pred = null;
            SessionInitialize();
            ProductoEN predEN = new ProductoCAD(session).ReadOIDDefault(id);
            pred = new AssemblerProducto().ConvertENToModelUI(predEN, session);
            SessionClose();
            return View(pred);
        }

        //
        // POST: /Prpducto/Edit/5

        [HttpPost]
        public ActionResult Edit(Predefinida pro, HttpPostedFileBase file)
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
                ProductoCEN cen = new ProductoCEN();
                if (fileName == "")
                {
                    fileName = pro.Foto;
                }
                else
                {
                    fileName = "/Images/Uploads/" + fileName;
                }

                cen.Modify(pro.Id, double.Parse(pro.precio, System.Globalization.CultureInfo.InvariantCulture), pro.Nombre, fileName, pro.NumVeces);

                return RedirectToAction("IndexEdit");
            }
            catch
            {
                return View();
            }
        }



        //
        // GET: /Producto/Busqueda

        [AllowAnonymous]
        public ActionResult Busqueda()
        {
            return PartialView();
        }

        //
        // GET: /Producto/Busqueda/nombre
        [HttpPost]
        [AllowAnonymous]
        public ActionResult BusquedaPost(string nombre)
        {
            try
            {
                SessionInitialize();
                ProductoCAD pCAD = new ProductoCAD(session);
                ProductoCEN pCEN = new ProductoCEN(pCAD);
                AssemblerProducto assemblerProducto = new AssemblerProducto();
                IList<ProductoEN> listaP = pCEN.BuscarProducto(nombre);
                IList<Producto> Return = assemblerProducto.ConvertListENToModel(listaP,session);
                SessionClose();

                return View(Return);
            
            }
            catch
            {
                return View();
            }
        }






        //
        // GET: /Producto/Delete/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Delete(int id)
        {
            try
            {
                new ProductoCEN().Destroy(id);
                return RedirectToAction("IndexDel");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Producto/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("IndexDel");
            }
            catch
            {
                return View();
            }
        }

        // GET: /Producto/TopVentas
        [AllowAnonymous]
        public ActionResult TopVentasPost()
        {
            try
            {

                SessionInitialize();
                ProductoCEN pred = new ProductoCEN();
                IList<ProductoEN> list = pred.ReadAll(0, -1);
                List<ProductoEN> listica = new List<ProductoEN>();

                foreach (ProductoEN p in list)
                {
                    if (p.NumVeces != 0)
                    {
                        listica.Add(p);
                    }
                }

                listica = listica.OrderByDescending(o => o.NumVeces).ToList();
                IEnumerable<Producto> lista = new AssemblerProducto().ConvertListENToModel(listica, session).ToList();


                SessionClose();

                if (lista.Count()>0)
                {

                    return View(lista);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}

