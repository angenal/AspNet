using System.Web.Mvc;
using System.Web.Routing;

namespace MvcDemo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Demo", action = "Input", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            EO.Pdf.Runtime.AddLicense(Properties.Resources.ResourceManager.GetString("L21"));

            //Register MVCToPDF filter
            EO.Pdf.Mvc.MVCToPDF.RegisterFilter(typeof(GlobalFilters));

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}
