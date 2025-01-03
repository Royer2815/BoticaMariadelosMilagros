using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers // Asegúrate de que la carpeta se llama Controllers  
{
    public class HomeController : Controller // Cambia ApiController a Controller  
    {
        // Acción para la vista principal  
        public ActionResult Index()
        {
            return View();
        }

        // Acción para la vista Acerca de  
        public ActionResult About()
        {
            ViewBag.Message = "Descripción de tu aplicación."; // Mensaje que se mostrará en la vista  
            return View(); // Asegúrate de que exista la vista About.cshtml  
        }

        // Acción para la vista de Contacto  
        public ActionResult Contact()
        {
            ViewBag.Message = "Tu página de contacto.";
            return View(); // Asegúrate de que exista la vista Contact.cshtml  
        }
    }
}