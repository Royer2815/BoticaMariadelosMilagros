using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace CapaPresentacion
{
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    public class RouteConfigBase1 : RouteConfigBase1Base
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        private static object DebuggerDisplay => throw new NotImplementedException();

        private static object DebuggerDisplay1 => throw new NotImplementedException();

        public override int GetHashCode() => base.GetHashCode();

        private string GetDebuggerDisplay() => ToString();

        public override bool Equals(object obj) => base.Equals(obj);

        public override string ToString() => base.ToString();
    }
}