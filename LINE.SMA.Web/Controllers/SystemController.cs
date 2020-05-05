using LINE.SMA.Infrastructure;
using LINE.SMA.Model;
using LINE.SMA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LINE.SMA.Web.Controllers
{
    public class SystemController : Controller
    {
        public UserService userService = IocContainer.Resolve<UserService>();

        public ActionResult ButtonList()
        {
            return View();
        }

        public ActionResult ButtonDetail()
        {
            return View();
        }

        public ActionResult MenuList()
        {
            return View();
        }

        public object GetModuleList()
        {
            var menuInfos = userService.GetAllModule();

            return ToMenuJson(menuInfos, 0);
        }

        private string ToMenuJson(List<Labmodule> data, long parentId)
        {
            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("[");

            List<Labmodule> entitys = data.FindAll(c => c.F_id == parentId).OrderBy(c => c.Sort).ToList();

            if (entitys.Count > 0)
            {
                foreach (var item in entitys)
                {
                    string strJson = item.ToJson();
                    strJson = strJson.Insert(strJson.Length - 1, ",\"ChildNodes\":" + ToMenuJson(data, item.Id) + "");
                    sbJson.Append(strJson + ",");
                }
                sbJson = sbJson.Remove(sbJson.Length - 1, 1);
            }
            sbJson.Append("]");
            return sbJson.ToString();
        }

        public string GetMenuList()
        {
            List<CustomMenu> menuList = new List<CustomMenu>();
            var menuInfos = userService.GetAllModule();
            // 父级菜单
            foreach (var item in menuInfos.Where(c => c.F_id == 0))
            {
                CustomMenu menu = new CustomMenu();
                menu.Id = item.Id;
                menu.Name = item.Module_name;
                menu.Url = item.Url;
                menu.ChildNodes = new List<CustomMenu>();
                foreach (var li in menuInfos.Where(c => c.F_id == item.Id).OrderBy(c => c.Sort))
                {
                    CustomMenu childMenu = new CustomMenu();
                    childMenu.Id = li.Id;
                    childMenu.Name = li.Module_name;
                    childMenu.Url = li.Url;
                    menu.ChildNodes.Add(childMenu);
                }

                menuList.Add(menu);
            }
            return menuList.ToJson();
        }

    }
}
