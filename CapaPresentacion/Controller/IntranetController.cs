



using System.Web.Mvc;

namespace TuEspacioDeNombres.Controllers
{
    public class IntranetController : Controller
    {
        public ActionResult InicioSesion()
        {
            return View();
        }

        public ActionResult MenuPrincipal()
        {
            // Verifica que el usuario esté autenticado antes de mostrar el menú.  
            // Aquí puedes usar Session o cualquier otra lógica.  
            if (Session["EmpleadoNombre"] == null)
            {
                return RedirectToAction("InicioSesion");
            }

            return View();
        }

        public ActionResult CerrarSesion()
        {
            Session.Clear(); // O cualquier otra lógica para cerrar sesión  
            return RedirectToAction("InicioSesion");
        }
    }
}