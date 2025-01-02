using System.Web.Mvc;

namespace CapaPresentacion.Controllers
{
    public interface IAuthController1
    {
        ActionResult InicioSesion1 { get; }

        ActionResult CerrarSesion();
        ActionResult InicioSesion(string usuario, string contrasena);
    }
}