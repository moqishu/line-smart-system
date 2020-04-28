using System.Runtime.Remoting.Messaging;

namespace LINE.SMA.Repositories.Context
{
    public class DbFactory
    {
        public static KtDbContext GetInstance()
        {
            KtDbContext dbContext = CallContext.GetData("DbContext") as KtDbContext;
            if (dbContext == null)
            {
                dbContext = new KtDbContext();
                CallContext.SetData("DbContext", dbContext);
            }
            
            return dbContext;
        }



    }
}
