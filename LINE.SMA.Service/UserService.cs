using LINE.SMA.Infrastructure;
using LINE.SMA.Model;
using LINE.SMA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINE.SMA.Service
{
    public class UserService : BaseServices
    {
        public ILabuserRepository userDal = IocContainer.Resolve<ILabuserRepository>();
        public ILabmoduleRepository moduleDal = IocContainer.Resolve<ILabmoduleRepository>();

        public List<Labmodule> GetAllModule()
        {
            return moduleDal.GetAll();
        }
    }
}
