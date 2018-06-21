using MvcApplication1.Models;
using PracticaGenNHibernate.CAD.Practica;
using PracticaGenNHibernate.CEN.Practica;
using PracticaGenNHibernate.EN.Practica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using MvcApplication1.Filters;
using PracticaGenNHibernate.Utils;

namespace MvcApplication1.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class UsuarioController : BasicController
    {
        //
        // GET: /Usuario/
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Index()
        {
            SessionInitialize();
            UsuarioCEN inc = new UsuarioCEN(new UsuarioCAD(session)); 
            IList<UsuarioEN> inci = inc.ReadAll(0, -1);
            IEnumerable<Usuario> list = new AssemblerUsuario().ConvertListENToModel(inci,session).ToList();
            SessionClose();
            return View(list);
        }

        //
        // GET: /Usuario/Details/5
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Usuario/Create
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult Create()
        {
            Usuario u = new Usuario();
            return View(u);
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        public ActionResult Create(Usuario user)
        {
            try
            {
                UsuarioCEN u = new UsuarioCEN();
                u.New_(user.email,user.nombre,user.contrasenya,user.fecha_nac,user.telefono,DateTime.Today);
                WebSecurity.CreateUserAndAccount(user.email, user.contrasenya);              
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Usuario/Edit/5
        [Authorize]
        public ActionResult Edit()
        {
            Usuario u = null;
            SessionInitialize();
            UsuarioCEN ucen = new UsuarioCEN(new UsuarioCAD(session));
            UsuarioEN uEN = ucen.UsuarioPorEmail(User.Identity.Name)[0];
            u = new AssemblerUsuario().ConvertENToModelUI(uEN,session);
            SessionClose();
            return View(u);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        public ActionResult Edit(Usuario u)
        {
            try
            {
                RegistradoCEN uCEN = new RegistradoCEN();
                uCEN.Modify(u.id, u.email, u.nombre, u.contrasenya, u.fecha_nac, u.telefono, u.fecha_reg);

                return RedirectToAction("Perfil","Account");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult ResultadoBusqueda(string nombre)
        {
            try
            {
                SessionInitialize();
                UsuarioCAD pCAD = new UsuarioCAD(session);
                UsuarioCEN pCEN = new UsuarioCEN(pCAD);
                AssemblerUsuario assemblerusuario = new AssemblerUsuario();
                IList<UsuarioEN> listaP = pCEN.BuscarUsuario(nombre);
                IList<Usuario> Return = assemblerusuario.ConvertListENToModel(listaP,session);
                SessionClose();

                return View(Return);
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Users = "Admin@epizza.com")]
        public ActionResult ResultadoBusqueda2(string nombre)
        {
            try
            {
                SessionInitialize();
                UsuarioCAD pCAD = new UsuarioCAD(session);
                UsuarioCEN pCEN = new UsuarioCEN(pCAD);
                AssemblerUsuario assemblerusuario = new AssemblerUsuario();
                IList<UsuarioEN> listaP = pCEN.BuscarUsuario(nombre);
                IList<Usuario> Return = assemblerusuario.ConvertListENToModel(listaP,session);
                SessionClose();

                return View(Return);
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Users = "Admin@epizza.com")]
        //lista de usuarios para eliminar
        public ActionResult DeleteList()
        {
            UsuarioCEN inc = new UsuarioCEN(new UsuarioCAD(session));
            IList<UsuarioEN> inci = inc.ReadAll(0, -1);
            IEnumerable<Usuario> list = new AssemblerUsuario().ConvertListENToModel(inci,session).ToList();
            return View(list);
        }

        //
        // GET: /Usuario/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            Usuario pred = null;
            SessionInitialize();
            UsuarioEN predEN = new UsuarioCAD(session).ReadOIDDefault(id);
            pred = new AssemblerUsuario().ConvertENToModelUI(predEN,session);
            SessionClose();
            return View(pred);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost]
        public ActionResult Delete(Usuario u)
        {
            
            ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(new UsuarioCEN().ReadOID(u.id).Email);
            ((SimpleMembershipProvider)Membership.Provider).DeleteUser(new UsuarioCEN().ReadOID(u.id).Email, true);

            //borramos las direcciones del usuario
            if (new UsuarioCEN(new UsuarioCAD(session)).UsuarioPorEmail(User.Identity.Name)[0].Direccion.Count > 0)
            {
                foreach (DireccionEN d in new UsuarioCEN(new UsuarioCAD(session)).UsuarioPorEmail(User.Identity.Name)[0].Direccion)
                    new DireccionCEN().Destroy(d.Id);
            }
            //borramos las incidencias del usuario
            foreach (IncidenciaEN i in new IncidenciaCEN().ReadAll(0, -1)) {
                if (i.Usuario.Id == u.id) {
                    new IncidenciaCEN().Destroy(i.Id);
                }
            }
            //borramos los pedidos del usuario

            foreach (PedidoEN p in new PedidoCEN().ReadAll(0, -1))
            {
                if (p.Usuario.Id == u.id)
                {
                    new PedidoCEN().Destroy(p.Id);
                }
            }

            new UsuarioCEN().Destroy(u.id);
            String id=User.Identity.Name.ToUpper();
            if (id.Equals("Admin@epizza.com".ToUpper(), StringComparison.OrdinalIgnoreCase))
                {
                    return RedirectToAction("Index");
                }
                else {
                    WebSecurity.Logout();
                    return RedirectToAction("Index", "Home");
                }
        }

        // GET: /Usuario/RecuperarContrasenya
        [AllowAnonymous]
        public ActionResult RecuperarContrasenya()
        {
         
            return View();
        }

        // GET: /Usuario/RecuperarContrasenya
        [AllowAnonymous]
        [HttpPost]
        public ActionResult RecuperarContrasenya(String correo)
        {
           
            UsuarioCEN usu = new UsuarioCEN();

            if (usu.UsuarioPorEmail(correo).Count > 0)
            {
                UsuarioEN u = usu.UsuarioPorEmail(correo)[0];
               String clave = usu.RecuperarContrasenya(u.Id);

               var token = WebSecurity.GeneratePasswordResetToken(u.Email);

               if (WebSecurity.ResetPassword(token, clave))
                   usu.Modify(u.Id, u.Email, u.Nombre, clave, u.Fecha_nac, u.Telefono, u.FechaRegistro);
            }
            return RedirectToAction("Login","Account");
        }
    }
}
