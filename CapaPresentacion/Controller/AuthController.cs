using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaPresentacion.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth/InicioSesion  
        public ActionResult InicioSesion()
        {
            return View(); // Devuelve la vista de inicio de sesión  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InicioSesion(string usuario, string contrasena)
        {
            // Aquí iría la lógica para autenticar al usuario  
            if (/* lógica de autenticación exitosa */)
            {
                return RedirectToAction("MenuPrincipal", "Intranet");
            }

            ModelState.AddModelError("", "Usuario o contraseña incorrectos.");
            return View();
        }

        public ActionResult CerrarSesion()
        {
            // Lógica para cerrar sesión  
            return RedirectToAction("InicioSesion", "Auth");
        }
    }
}