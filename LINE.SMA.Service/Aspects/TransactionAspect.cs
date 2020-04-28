using System;
using System.Diagnostics;
using SheepAspect.Framework;
using SheepAspect.Runtime;
using System.Data.Common;
using LINE.SMA.Infrastructure;
using System.Data.Entity;
using LINE.SMA.Repositories.Context;

namespace LINE.SMA.Service
{
    [Aspect]
    public class TransactionAspect
    {
        private DbContextTransaction dbTransaction { get; set; }

        [SelectMethods("HasCustomAttributeType:'LINE.SMA.Infrastructure.TransactionAttribute'")]
        public void TransactionMethods() { }

        [Around("TransactionMethods")]
        public object TransactionAroundMethod(MethodJointPoint jp)
        {
            Trace.TraceInformation("Entering {0} on {1}. Args:{2}", jp.Method, jp.This, string.Join(",", jp.Args));
            try
            {
                // 开启事务
                dbTransaction = DbFactory.GetInstance().Database.BeginTransaction();

                var result = jp.Execute();

                if (jp.Method.ReturnType == typeof(void))
                    result = "{void}";

                // 提交事务
                dbTransaction.Commit();

                Trace.TraceInformation("Exitting {0}. Result: {1}", jp.Method, result);
				return result;
            }
            catch (Exception e)
            {
                // 回滚事务
                dbTransaction.Rollback();
                Trace.TraceInformation("Exitting {0} with exception: '{1}'", jp.Method, e);
                throw;
            }
            finally
            {
                if (dbTransaction != null)
                    dbTransaction.Dispose();
            }
        }
    }
}