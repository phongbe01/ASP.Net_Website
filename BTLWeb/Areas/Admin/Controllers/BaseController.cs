using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BTLWeb.Common.Session;

namespace BTLWeb.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ses = (UserSession)Session[Constant.USER_SESSION];
            if (ses == null)
            {
                {
                    filterContext.Result = new RedirectToRouteResult(
                                    new RouteValueDictionary(
                                new { controller = "Home", action = "Index", Area = ""}));
                }
                base.OnActionExecuting(filterContext);
            }
        }
    }
}