using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

namespace CapaPresentacion
{
    [DebuggerDisplay("{" + nameof(DebuggerDisplay ) + "(),nq}")]
    public class RouteConfig : RouteConfigBase1
    {
        public RouteConfig()
        {
        }

        private static object DebuggerDisplay => throw new NotImplementedException();
    }
}