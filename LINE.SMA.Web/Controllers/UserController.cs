using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LINE.SMA.Web.Controllers
{
    public class UserController : BaseController
    {
        /// <summary>
        /// 用户管理
        /// </summary>
        /// <returns></returns>
        public ActionResult UserList()
        {
            return View();
        }

        public ActionResult UserDetail()
        {
            return View();
        }

        public ActionResult RoleList()
        {
            return View();
        }

        public ActionResult RightSetting()
        {
            return View();
        }

        /// <summary>
        /// 个人中心
        /// </summary>
        /// <returns></returns>
        public ActionResult Personal()
        {
            return View();
        }
    }
}