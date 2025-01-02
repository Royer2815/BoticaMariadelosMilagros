using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class AuthController : EmpleadoControllers, IAuthController1
    {
        private readonly EmpleadoService _empleadoService;

        public AuthController()
        {
            _empleadoService = new EmpleadoService(); // Inicializa el servicio de empleados  
        }

        // GET: Auth/InicioSesion  
        public ActionResult InicioSesion1 => View();

        private ActionResult View()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InicioSesion(string usuario, string contrasena)
        {
            // Verifica las credenciales del usuario  
            if (_empleadoService.Autenticar(usuario, contrasena)) // Usa un método real para la autenticación  
            {
                return RedirectToAction("MenuPrincipal", "Intranet"); // Redirige si la autenticación es exitosa  
            }

            object value = ModelState.AddModelError("",
                "Usuario o contraseña incorrectos."); // Muestra error en caso de fallo  
            return View();
        }

        public ActionResult CerrarSesion()
        {
            // Aquí puedes agregar lógica para limpiar la sesión  
            // Ejemplo: Session.Abandon(); o FormsAuthentication.SignOut();  
            return RedirectToAction("InicioSesion", "Auth"); // Redirige al inicio de sesión  
        }

        private ActionResult RedirectToAction(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        private string GetDebuggerDisplay() => this.ToString();
    }