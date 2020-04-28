using LINE.SMA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LINE.SMA.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is AlertException)
            {
                //Response.Redirect(Url.Content("/Home/AlertInfo?message=" + filterContext.Exception.Message));
                RedirectToRoute(new { controller = "Home", action = "AlertInfo", message = filterContext.Exception.Message.ToString() });//可跳到其他controller,带参数。
            }
            LogUtils.ErrorLog("未处理异常", filterContext.Exception);
            base.OnException(filterContext);
        }
    }
}
