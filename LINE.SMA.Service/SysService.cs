using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINE.SMA.Repositories;
using LINE.SMA.Infrastructure;
using LINE.SMA.Model;

namespace LINE.SMA.Service
{
    public class SysService
    {
        ISysMenuRepository menuRes = IocContainer.Resolve<ISysMenuRepository>();

        public List<SysMenu> GetAllMenu()
        {
            return menuRes.GetAll();
        }
    }
}
