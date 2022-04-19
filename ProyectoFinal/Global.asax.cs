using ProyectoFinal.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ProyectoFinal
{
    public class Global : HttpApplication
    {
        public static Voluntario vSigned;
        public static Residencia rSigned;
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            vSigned = null;
            rSigned = null;
        }
    }
}