using System.Web;
using System.Web.Mvc;

namespace CrystalReport_ASP.NetMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}