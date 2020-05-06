using LINE.SMA.Model;
using LINE.SMA.Service;
using LINE.SMA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LINE.SMA.Web.Controllers
{
    public class SysController : Controller
    {
        private SysService sysService = IocContainer.Resolve<SysService>();

        public string GetMenuList()
        {
            List<SysMenu> menuList = new List<SysMenu>();
            var menuInfos = sysService.GetAllMenu();
            // 父级菜单
            foreach (var item in menuInfos.Where(c => c.ParentId == 0))
            {
                item.Child = new List<SysMenu>();
                foreach (var li in menuInfos.Where(c => c.ParentId == item.Id).OrderBy(c => c.Sort))
                {
                    item.Child.Add(li);
                }

                menuList.Add(item);
            }
            return menuList.ToJson();
        }

        public ActionResult MenuList()
        {
            return View();
        }
    }
}