using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public interface IAuthController
    {
        ActionResult InicioSesion1 { get; }

        ActionResult CerrarSesion();
        ActionResult InicioSesion(string usuario, string contrasena);
    }
}