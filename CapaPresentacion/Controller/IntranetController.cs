using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public class IntranetController : Controller
    {
        private readonly ProductoService _productoService;
        private readonly EmpleadoService _empleadoService;

        public IntranetController()
        {
            _productoService = new ProductoService(); // Inicializa el servicio de productos  
            _empleadoService = new EmpleadoService(); // Inicializa el servicio de empleados  
        }

        // GET: Intranet/Dashboard  
        public ActionResult Dashboard()
        {
            var totalProductos = _productoService.ObtenerTotalProductos(); // Obtén el total de productos  
            var totalEmpleados = _empleadoService.ObtenerTotalEmpleados(); // Obtén el total de empleados  

            ViewBag.TotalProductos = totalProductos; // Envía el total de productos a la vista  
            ViewBag.TotalEmpleados = totalEmpleados; // Envía el total de empleados a la vista  

            return View(); // Devuelve la vista del dashboard  
        }

        // GET: Intranet/Productos  
        public ActionResult Productos()
        {
            var productos = _productoService.ObtenerProductos(); // Obtiene la lista de productos  
            return View(productos); // Devuelve la vista con la lista de productos  
        }

        // GET: Intranet/Empleados  
        public ActionResult Empleados()
        {
            var empleados = _empleadoService.ObtenerEmpleados(); // Obtiene la lista de empleados  
            return View(empleados); // Devuelve la vista con la lista de empleados  
        }
    }
}