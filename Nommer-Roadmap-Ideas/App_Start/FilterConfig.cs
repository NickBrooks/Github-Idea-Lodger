using System.Web;
using System.Web.Mvc;

namespace Nommer_Roadmap_Ideas
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
