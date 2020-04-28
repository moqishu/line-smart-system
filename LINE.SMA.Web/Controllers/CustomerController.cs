using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LINE.SMA.Web.Controllers
{
    public class CustomerController : BaseController
    {
        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Customer()
        {
            return View();
        }
    }
}