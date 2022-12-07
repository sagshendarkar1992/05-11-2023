using System.Web;
using System.Web.Mvc;
using Vzah.Models;

namespace Vzah
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new SessionExpireAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
