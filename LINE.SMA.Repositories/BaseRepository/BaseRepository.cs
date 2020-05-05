using LINE.SMA.Infrastructure;
using LINE.SMA.Repositories.Context;
using LINE.SMA.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using LINE.SMA.Repositories.BaseRepository;

namespace LINE.SMA.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, EntityBase
    {
        private LineDbContext Db
        {
            get { return DbFactory.GetInstance(); }
        }

        private DbTransaction dbTransaction { get; set; }
        public IRepository<T> BeginTrans()
        {
            DbConnection dbConnection = ((IObjectContextAdapter)Db).ObjectContext.Connection;
            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }
            dbTransaction = dbConnection.BeginTransaction();
            return this;
        }
        public int Commit()
        {
            try
            {
                var returnValue = Db.SaveChanges();
                if (dbTransaction != null)
                {
                    dbTransaction.Commit();
                }
                return returnValue;
            }
            catch (Exception)
            {
                if (dbTransaction != null)
                {
                    this.dbTransaction.Rollback();
                }
                throw;
            }
            finally
            {
                this.Dispose();
            }
        }
        public void Dispose()
        {
            if (dbTransaction != null)
            {
                this.dbTransaction.Dispose();
            }
            this.Db.Dispose();
        }


        public virtual T Add(T entity)
        {
            var result = Db.Set<T>().Insert(entity);
            Db.SaveChanges();
            return result;
        }

        public virtual List<T> Add(List<T> entitys)
        {
            //var result = new List<T>();
            //foreach (var li in entitys)
            //{
            //    var re = Db.Set<T>().Insert(li);
            //    result.Add(re);
            //}

            var result = Db.Set<T>().InsertRange(entitys);

            Db.SaveChanges();
            return result.ToList();
        }

        public T GetById(long id)
        {
            if (id == 0)
            {
                return null;
            }
            var result = Db.Set<T>().AsNoTracking().FirstOrDefault(p => p.Id == id);

            return result;
        }

        public int Delete(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;

            return Db.SaveChanges();
        }

        public List<T> GetListByIdList(List<long> idList)
        {
            idList = idList ?? new List<long>();
            var result = Db.Set<T>().AsNoTracking().Where(p => idList.Contains(p.Id)).ToList();
            return result;
        }

        public int Delete(List<T> entitys)
        {
            foreach (var entity in entitys)
            {
                Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            }
            return Db.SaveChanges();
        }

        public int Update(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return Db.SaveChanges();
        }

        public int Update(List<T> entitys)
        {
            foreach (var entity in entitys)
            {
                Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            }
            return Db.SaveChanges();
        }

        public List<T> GetAll()
        {
            var result = Db.Set<T>().AsNoTracking().ToList();

            return result;
        }

        public IQueryable<T> GetByWhere(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Set<T>().Where(whereLambda).AsQueryable();
        }

        public IQueryable<T> LoadPageEntities<S>(int pageSize, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderbyLambda, bool isAsc)
        {
            total = Db.Set<T>().Where(whereLambda).Count();
            if (isAsc)
            {
                return
                Db.Set<T>()
                  .Where(whereLambda)
                  .OrderBy(orderbyLambda)
                  .Skip(pageSize * (pageIndex - 1))
                  .Take(pageSize)
                  .AsQueryable();
            }
            else
            {
                return
               Db.Set<T>()
                 .Where(whereLambda)
                 .OrderByDescending(orderbyLambda)
                 .Skip(pageSize * (pageIndex - 1))
                 .Take(pageSize)
                 .AsQueryable();
            }
        }

        /// <summary>
        /// 打开连接
        /// </summary>
        public void Open()
        {
            if(Db.Database.Connection.State == ConnectionState.Closed)
            {
                try
                {
                    Db.Database.Connection.Open();
                }
                catch (Exception ex)
                {
                    LogUtils.ErrorLog(ex.ToString());
                    throw new Exception("连接数据库出错" + ex.Message);
                }
            }
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            if (Db.Database.Connection.State.Equals(ConnectionState.Open))
            {
                Db.Database.Connection.Close();
                Db.Database.Connection.Dispose();
            }
        }

        public DataTable GetSqlDataTable(string sql)
        {
            DataTable dt = new DataTable();
            //try
            //{
            //    dt = Db.Database.SqlQuery<DataTable>(sql).FirstOrDefault();
            //}
            //catch (Exception ex)
            //{
            //    LogUtils.ErrorLog(ex.Message);
            //    throw new Exception("错误提醒" + ex.Message);
            //}
            //return dt;

            try
            {
                using (Db.Database.Connection)
                {
                    Open();
                    var cmd = (MySqlCommand)Db.Database.Connection.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    MySqlDataAdapter dba = new MySqlDataAdapter(cmd);
                    dba.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                LogUtils.ErrorLog(ex.Message);
                throw new Exception("错误提醒" + ex.Message);
            }
            finally
            {
                Close();
            }

            return dt;
        }

        public DataSet GetSqlDataSet(string sql)
        {
            DataSet dt = new DataSet();
            try
            {
                Open();
                var cmd = (MySqlCommand)Db.Database.Connection.CreateCommand();
                MySqlDataAdapter dba = new MySqlDataAdapter(cmd);
                dba.Fill(dt);
            }
            catch (Exception ex)
            {
                LogUtils.ErrorLog(ex.Message);
                throw new Exception("错误提醒" + ex.Message);
            }
            finally
            {
                Close();
            }
            return dt;
        }

        public string ExecuteScalar(string sql)
        {
            string str = "0";
            try
            {
                Open();
                MySqlCommand cmd = new MySqlCommand(sql, (MySqlConnection)Db.Database.Connection);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(result.ToString()))
                    {
                        str = result.ToString();
                    }
                }
            }
            catch (System.Exception e)
            {
                LogUtils.ErrorLog(e.Message);
                throw new Exception("错误提醒" + e.Message);
            }
            finally
            {
                Close();
            }
            return str;
        }

        public int ExecuteNonQuery(string sql)
        {
            int str = 0;
            try
            {
                Open();
                MySqlCommand cmd = new MySqlCommand(sql, (MySqlConnection)Db.Database.Connection);
                str = cmd.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                LogUtils.ErrorLog(e.Message);
                throw new Exception("错误提醒" + e.Message);
            }
            finally
            {
                Close();
            }
            return str;
        }

        public DataSet ExecuteProcedure(string spName, string[] paraNames, MySqlDbType[] dbTypes, int[] sizes, object[] objs)
        {
            DataSet dataset = new DataSet();
            Open();
            try
            {
                using (MySqlDataAdapter mysqldata = new MySqlDataAdapter())
                {

                    mysqldata.SelectCommand = new MySqlCommand();
                    mysqldata.SelectCommand.Connection = (MySqlConnection)Db.Database.Connection;
                    mysqldata.SelectCommand.CommandText = spName;
                    mysqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
                    mysqldata.SelectCommand.CommandTimeout = 60;
                    if (paraNames != null && paraNames.Length > 0)
                    {
                        for (int i = 0; i < paraNames.Length; i++)
                        {
                            mysqldata.SelectCommand.Parameters.Add(paraNames[i], dbTypes[i], sizes[i]);
                            mysqldata.SelectCommand.Parameters[paraNames[i]].Value = objs[i];
                        }
                    }
                    mysqldata.Fill(dataset, spName);
                }
            }
            catch (MySqlException ex)
            {
                LogUtils.ErrorLog(ex.Message);
                throw new Exception("错误提醒" + ex.Message);
            }
            finally
            {
                Close();
            }
            return dataset;
        }
    }
}
