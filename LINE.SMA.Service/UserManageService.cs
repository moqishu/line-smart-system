using LINE.SMA.Infrastructure;
using LINE.SMA.Model;
using LINE.SMA.Repositories;
using LINE.SMA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINE.SMA.Service
{
    public class UserManageService : BaseServices
    {
        //public TfunctionRepository tfunDal = new TfunctionRepository();

        public IFunctionRepository funDal = IocContainer.Resolve<IFunctionRepository>();

        [Transaction]
        public List<Function> GetAllFunction()
        {
            return funDal.GetAll();
        }

        
    }

    
}
