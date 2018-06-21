using MvcApplication1.Models;
using PracticaGenNHibernate.CEN.Practica;
using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            return View();
        }
        public ActionResult Ofertas()
        {


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PreguntasFrecuentes()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult PoliticaPrivacidad()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult QuienesSomos()
        {
            ViewBag.Message = "";

            return View();
        }
        public ActionResult Contacta()
        {
            ViewBag.Message = "";

            return View();
        }

        [HttpPost]
        public ActionResult Contacta(String nombre, String email, String textoAdicional)
        {
            return RedirectToAction("Enviado");
        }

        ///cosas del admin
        ///
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult PanelAdmin()
        {
            return View();
        }

        public ActionResult Contacto()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Estadisticas()
        {
            UsuarioCEN u = new UsuarioCEN();
            IncidenciaCEN i = new IncidenciaCEN();
            PedidoCEN p = new PedidoCEN();

            ViewData["usuarios"] = u.UsuariosMes(DateTime.Now);

            ViewData["Incidencia"] = i.IncidenciasMes(DateTime.Now.Month);
            ViewData["pedidos"] = p.PedidosMensuales(DateTime.Now.Month);
            int codigos = 0;
            foreach (PedidoEN c in p.ReadAll(0, -1))
            {
                if (c.Codigo != null)
                {
                    codigos++;
                }
            }
            // ViewData["codigos"] = p.GetCodigosActivados();
            ViewData["codigos"] = codigos;

            return View("Estadisticas");
        }


        // GET: /Home/Contacto



        //
        // POST: /Home/Contacto

        [HttpPost]
        public ActionResult Contacto(Home comentario)
        {


            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("contacto.epizza@gmail.com", "dsm-master");


                String mensaje = ("Contacto de: " + comentario.nombre + "\n\nCon email: " + comentario.email + ". \n\nMensaje: '" + comentario.mensaje + "'.");
                MailMessage mm = new MailMessage("epizza.servicios@gmail.com", "epizza.servicios@gmail.com", "Mensaje de contacto recibido", mensaje);
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
                return RedirectToAction("Index");

            }
            catch
            {

                return RedirectToAction("Index");
            }
        }
    }
}