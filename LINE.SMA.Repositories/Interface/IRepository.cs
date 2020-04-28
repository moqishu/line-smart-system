using LINE.SMA.Infrastructure;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LINE.SMA.Repositories.Interface
{
    public interface IRepository<T> where T : class, EntityBase
    {
        T Add(T entity);
        List<T> Add(List<T> entitys);
        T GetById(long id);
        int Delete(T entity);
        List<T> GetListByIdList(List<long> idList);
        int Delete(List<T> entitys);
        int Update(T entity);
        int Update(List<T> entitys);
        List<T> GetAll();
        IQueryable<T> GetByWhere(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> LoadPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool isAsc);
        DataTable GetSqlDataTable(string sql);
        DataSet GetSqlDataSet(string sql);
        string ExecuteScalar(string sql);
        int ExecuteNonQuery(string sql);
        DataSet ExecuteProcedure(string spName, string[] paraNames, MySqlDbType[] dbTypes, int[] sizes, object[] objs);

    }
}
