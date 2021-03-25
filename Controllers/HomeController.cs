using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace landingP.Models
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult detalles()
        {
            RegistroUsuario us = new RegistroUsuario();
            return View(us.RecupearTodos());

        }

        // GET: Home/Create
        public ActionResult crear()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult crear(FormCollection collection)
        {
            RegistroUsuario us = new RegistroUsuario();
            Usuario usr = new Usuario
            {
                
                Nombre = collection["nombre"],
                Correo = collection["correo"],
                Telefono = int.Parse(collection["telefono"]),
                Mensage = collection["mensage"]

            };
            us.Insertar(usr);

            return RedirectToAction("detalles");

        }
        
    }
}