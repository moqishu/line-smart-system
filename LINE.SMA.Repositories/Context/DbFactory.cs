using System.Runtime.Remoting.Messaging;

namespace LINE.SMA.Repositories.Context
{
    public class DbFactory
    {
        public static LineDbContext GetInstance()
        {
            LineDbContext dbContext = CallContext.GetData("DbContext") as LineDbContext;
            if (dbContext == null)
            {
                dbContext = new LineDbContext();
                CallContext.SetData("DbContext", dbContext);
            }
            
            return dbContext;
        }



    }
}
