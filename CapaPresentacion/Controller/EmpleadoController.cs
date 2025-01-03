
using System;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class EmpleadoController : EmpleadoControllers
    {
        private readonly EmpleadoService _empleadoService;

        public EmpleadoController()
        {
            _empleadoService = new EmpleadoService(); // Inicializa el servicio de empleados  
        }

        // GET: Empleado  
        public ActionResult Index()
        {
            var empleados = _empleadoService.ObtenerEmpleados(); // Obtiene la lista de empleados  
            return View(empleados); // Devuelve la vista con la lista de empleados  
        }

        private ActionResult View(object empleados)
        {
            throw new NotImplementedException();
        }

        // Otras acciones como Create, Edit, Delete...  
    }
}