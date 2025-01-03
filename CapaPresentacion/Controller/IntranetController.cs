



using System.Web.Mvc;


namespace TuEspacioDeNombres.Controllers
{
    public class IntranetController : Controller
    {
        // Acción para mostrar la vista de inicio de sesión  
        public ActionResult InicioSesion()
        {
            return View();
        }

        // Acción para manejar el inicio de sesión  
        [HttpPost]
        public ActionResult InicioSesion(string usuario, string contraseña)
        {
            // Lógica de autenticación (simplificada)  
            if (usuario == "admin" && contraseña == "password") // Cambia esto a tu lógica real de autenticación  
            {
                Session["EmpleadoNombre"] = usuario; // Almacena el nombre del usuario en la sesión  
                return RedirectToAction("MenuPrincipal"); // Redirige al menú principal  
            }

            ViewBag.Error = "Usuario o contraseña incorrecto."; // Mensaje de error  
            return View(); // Regresa a la vista de inicio de sesión  
        }

        // Acción para mostrar el menú principal  
        public ActionResult MenuPrincipal()
        {
            if (Session["EmpleadoNombre"] == null)
            {
                return RedirectToAction("InicioSesion"); // Redirige a inicio de sesión si no hay sesión  
            }

            return View(); // Regresa a la vista del menú principal  
        }
    }
}