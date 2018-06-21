using MvcApplication1.Models;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.CEN.Practica;
using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class IncidenciaController : BasicController
    {
        //
        // GET: /Incidencia/
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Index()
        {
            IncidenciaCEN inc = new IncidenciaCEN();
            IList<IncidenciaEN> inci = inc.ReadAll(0, -1);
            IEnumerable<Incidencia> list = new AssemblerIncidencia().ConvertListENToModel(inci).ToList();
            return View(list);
        }

        //
        // GET: /Incidencia/Details/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Details(int id)
        {
            Incidencia incidencia = null;
            SessionInitialize();
            IncidenciaEN iEN = new IncidenciaCAD(session).ReadOIDDefault(id);
            incidencia = new AssemblerIncidencia().ConvertENToModelUI(iEN);
            SessionClose();
            return View(incidencia);
        }

        //
        // GET: /Incidencia/Create

        [Authorize]
        public ActionResult Create()
        {
            Incidencia inc = new Incidencia();
            return View(inc);
        }

        //
        // POST: /Incidencia/Create

        [HttpPost]
        public ActionResult Create(Incidencia inc)
        {
            try
            {
                // TODO: Add insert logic here
                IncidenciaCEN incidencia = new IncidenciaCEN();
                UsuarioCEN us = new UsuarioCEN();
                IList<UsuarioEN> lista=us.UsuarioPorEmail(User.Identity.Name);
               int id = incidencia.New_(inc.descripcion, PracticaGenNHibernate.Enumerated.Practica.EstadoIncidenciaEnum.pendiente,lista[0].Id, DateTime.Now);

                return RedirectToAction("Index","Home");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Incidencia/Edit/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Edit(int id)
        {
            Incidencia inc = null;
            SessionInitialize();
            IncidenciaEN incEN = new IncidenciaCAD(session).ReadOIDDefault(id);
            inc = new AssemblerIncidencia().ConvertENToModelUI(incEN);
            SessionClose();
            return View(inc);
        }

        //
        // POST: /Incidencia/Edit/5

        [HttpPost]
        public ActionResult Edit(Incidencia inc)
        {
            try
            {
                // TODO: Add update logic here
                IncidenciaCEN incidencia = new IncidenciaCEN();
                incidencia.Modify(inc.id, inc.descripcion, inc.estado, inc.fecha);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Incidencia/Delete/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Delete(int id)
        {
            try
            {
                new IncidenciaCEN().Destroy(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Incidencia/Delete/5

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

        // GET: /Incidencia/IncidenciasMensuales/mes
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult IncidenciasMensualesPost()
        {
            try
            {
                SessionInitialize();
                IncidenciaCAD pCAD = new IncidenciaCAD(session);
                IncidenciaCEN pCEN = new IncidenciaCEN(pCAD);

                DataTable tabla = new DataTable("incidenciasmensuales");

                tabla.Columns.Add("Nº de incidencias", typeof(int));
                tabla.Columns.Add("Mes", typeof(string));


                for (int i = 1; i <= 12; i++)
                {
                    long total = pCEN.IncidenciasMes(i);
                    ViewData["Veces"] = total;

                    switch (i)
                    {
                        case 1:
                            ViewData["Mes"] = "Enero";
                            break;
                        case 2:
                            ViewData["Mes"] = "Febrero";
                            break;
                        case 3:
                            ViewData["Mes"] = "Marzo";
                            break;
                        case 4:
                            ViewData["Mes"] = "Abril";
                            break;
                        case 5:
                            ViewData["Mes"] = "Mayo";
                            break;
                        case 6:
                            ViewData["Mes"] = "Junio";
                            break;
                        case 7:
                            ViewData["Mes"] = "Julio";
                            break;
                        case 8:
                            ViewData["Mes"] = "Agosto";
                            break;
                        case 9:
                            ViewData["Mes"] = "Septiembre";
                            break;
                        case 10:
                            ViewData["Mes"] = "Octubre";
                            break;
                        case 11:
                            ViewData["Mes"] = "Noviembre";
                            break;
                        case 12:
                            ViewData["Mes"] = "Diciembre";
                            break;
                    }
                    DataRow row = tabla.NewRow();

                    row["Nº de incidencias"] = total;
                    row["Mes"] = ViewData["Mes"];

                    tabla.Rows.Add(row);
                }

                SessionClose();
                if (tabla != null)
                {

                    return View(tabla);
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
