﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapaPresentacion.Controllers
{
    public class AuthController : Controller
    {
        private readonly EmpleadoService _empleadoService;

        public AuthController()
        {
            _empleadoService = new EmpleadoService(); // Inicializa el servicio de empleados  
        }

        // GET: Auth/InicioSesion  
        public ActionResult InicioSesion()
        {
            return View(); // Devuelve la vista de inicio de sesión  
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

            ModelState.AddModelError("", "Usuario o contraseña incorrectos."); // Muestra error en caso de fallo  
            return View();
        }

        public ActionResult CerrarSesion()
        {
            // Aquí puedes agregar lógica para limpiar la sesión  
            // Ejemplo: Session.Abandon(); o FormsAuthentication.SignOut();  
            return RedirectToAction("InicioSesion", "Auth"); // Redirige al inicio de sesión  
        }
    }
}