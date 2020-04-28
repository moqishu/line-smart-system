using LINE.SMA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LINE.SMA.Web
{
    public static class AutoConfig
    {
        public static void AutoRegister()
        {
            IocContainer.AutoRegister();
        }
    }
}