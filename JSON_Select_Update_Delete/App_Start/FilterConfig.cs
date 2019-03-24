using System.Web;
using System.Web.Mvc;

namespace JSON_Select_Update_Delete
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
