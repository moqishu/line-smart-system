using System.Data;
using System;
using System.Web;
using MySql.Data.MySqlClient;
using LINE.SMA.Infrastructure;
using System.Collections.Generic;

namespace LINE.SMA.Repositories.Context
{
    public class DBAdapter
    {
        private MySqlConnection _Conn = new MySqlConnection();
        private static string SqlConnectionString = null;
        public DBAdapter()
        {
            if (string.IsNullOrEmpty(SqlConnectionString))
            {
                //优先读取web.config里面配置信息，如果没有读取到再从通用config.ini文件夹里面读取
                try
                {
                    if (System.Configuration.ConfigurationManager.ConnectionStrings.Count > 1)
                        SqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBaseConnString_TEST"].ConnectionString;
                }
                catch { ; }

                /*if (!string.IsNullOrEmpty(SqlConnectionString))
                {
                    Dictionary<string, string> dic = Common.StringToDic(SqlConnectionString);
                    if (dic.ContainsKey("Password"))
                    {
                        dic["Password"] = KTEncDecEx.KTDecrypt(dic["Password"]);
                        SqlConnectionString = Common.DicToString(dic);
                    }
                }
                else
                {
                    if (CommonConfig.Instance.ConfigRecord != null)
                        SqlConnectionString = string.Format("Data Source={0};Port={1};Initial Catalog={2};Persist Security Info=True;User ID={3};Password={4}", CommonConfig.Instance.ConfigRecord.DBHost, CommonConfig.Instance.ConfigRecord.DBPort, CommonConfig.Instance.ConfigRecord.DBName, CommonConfig.Instance.ConfigRecord.DBUserName, CommonConfig.Instance.ConfigRecord.DBPass);
                }*/
            }
        }
        public MySqlConnection Conn
        {
            get
            {
                if (_Conn.State.Equals(ConnectionState.Closed))
                {
                    _Conn.ConnectionString = SqlConnectionString;
                    _Conn.Open();
                }
                return _Conn;
            }
        }
        /// <summary>
        /// 打开连接
        /// </summary>
        public void Open()
        {
            if (_Conn.State.Equals(ConnectionState.Closed))
            {
                try
                {
                    _Conn.ConnectionString = SqlConnectionString;
                    _Conn.Open();
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
            if (_Conn.State.Equals(ConnectionState.Open))
            {
                _Conn.Close();
                _Conn.Dispose();
            }
        }

        /// <summary>
        /// 取数据表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetSqlDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                Open();
                MySqlCommand cmd = new MySqlCommand(sql, Conn);
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

        /// <summary>
        /// 返回数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetSqlDataSet(string sql)
        {
            DataSet dt = new DataSet();
            try
            {
                Open();
                MySqlCommand cmd = new MySqlCommand(sql, Conn);
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

        /// <summary>
        /// 取值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string ExecuteScalar(string sql)
        {
            string str = "0";
            try
            {
                Open();
                MySqlCommand cmd = new MySqlCommand(sql, Conn);
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

        /// <summary>
        /// 返回影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql)
        {
            int str = 0;
            try
            {
                Open();
                MySqlCommand cmd = new MySqlCommand(sql, Conn);
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
        public string GetConnectionString(string _connectionStringsName)
        {
            System.Configuration.ConnectionStringSettingsCollection config = System.Configuration.ConfigurationManager.ConnectionStrings;
            for (int i = 0; i < config.Count; i++)
            {
                if (config[i].Name.Equals(_connectionStringsName, StringComparison.OrdinalIgnoreCase))
                    return config[i].ToString();
            }
            return String.Empty;
        }

        /// <summary>
        /// 调用存储过程，返回DataSet跟总数据辆
        /// </summary>
        /// <param name="proName">存储过程名称</param>
        /// <param name="whereStr">搜索条件要带where</param>
        /// <param name="types">搜索条件查询类型</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="total">总数据量</param>
        /// <returns></returns>
        /// 
        /// <summary>
        /// 调用存储过程，返回DataSet跟总数据辆
        /// </summary>
        /// <param name="proName">存储过程名称</param>
        /// <param name="whereStr">搜索条件要带where</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="total">总数据量</param>
        /// <returns></returns>
        /// 
        public DataSet ExecProcedure(string proName, string whereStr, int pageIndex, int pageSize, out int m_total)
        {
            m_total = 0;//返回的总数量  
            Open();
            using (MySqlDataAdapter mysqldata = new MySqlDataAdapter())
            {
                DataSet dataset = new DataSet();
                mysqldata.SelectCommand = new MySqlCommand();
                mysqldata.SelectCommand.Connection = Conn;
                mysqldata.SelectCommand.CommandText = proName;
                mysqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
                //设置参数，添加到数据库  
                MySqlParameter name_parameter = new MySqlParameter("?whereStr", MySqlDbType.VarChar, 200);//mysql的存储过程参数是以?打头的！！！！  
                name_parameter.Value = whereStr;
                mysqldata.SelectCommand.Parameters.Add(name_parameter);
                MySqlParameter email_parameter = new MySqlParameter("?pageIndex", MySqlDbType.Int32, 11);
                email_parameter.Value = pageIndex;
                mysqldata.SelectCommand.Parameters.Add(email_parameter);
                MySqlParameter password_parameter = new MySqlParameter("?pageSize", MySqlDbType.Int32, 11);
                password_parameter.Value = pageSize;
                mysqldata.SelectCommand.Parameters.Add(password_parameter);
                MySqlParameter id_parameter = new MySqlParameter("?o_tatal", MySqlDbType.Int32, 15);//返回值  
                id_parameter.Direction = ParameterDirection.Output;
                mysqldata.SelectCommand.Parameters.Add(id_parameter);
                try
                {
                    mysqldata.Fill(dataset, "yuan_user_cc");
                    m_total = (Int32)id_parameter.Value;
                    Conn.Close();
                    return dataset;
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
            }
        }

        public DataSet ExecProcedure(string proName, string whereStr, int types, int pageIndex, int pageSize, out int m_total)
        {
            m_total = 0;//返回的总数量  
            Open();
            using (MySqlDataAdapter mysqldata = new MySqlDataAdapter())
            {
                DataSet dataset = new DataSet();
                mysqldata.SelectCommand = new MySqlCommand();
                mysqldata.SelectCommand.Connection = Conn;
                mysqldata.SelectCommand.CommandText = proName;
                mysqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
                //设置参数，添加到数据库  
                MySqlParameter name_parameter = new MySqlParameter("?i_whereClause", MySqlDbType.VarChar, 200);//mysql的存储过程参数是以?打头的！！！！  
                name_parameter.Value = whereStr;
                mysqldata.SelectCommand.Parameters.Add(name_parameter);

                MySqlParameter types_parameter = new MySqlParameter("?i_types", MySqlDbType.Int32, 11);
                types_parameter.Value = types;
                mysqldata.SelectCommand.Parameters.Add(types_parameter);

                MySqlParameter email_parameter = new MySqlParameter("?i_page", MySqlDbType.Int32, 11);
                email_parameter.Value = pageIndex;
                mysqldata.SelectCommand.Parameters.Add(email_parameter);

                MySqlParameter password_parameter = new MySqlParameter("?i_pageSize", MySqlDbType.Int32, 11);
                password_parameter.Value = pageSize;
                mysqldata.SelectCommand.Parameters.Add(password_parameter);

                MySqlParameter id_parameter = new MySqlParameter("?o_total", MySqlDbType.Int32, 15);//返回值  
                id_parameter.Direction = ParameterDirection.Output;
                mysqldata.SelectCommand.Parameters.Add(id_parameter);
                try
                {
                    mysqldata.Fill(dataset, proName);
                    m_total = (Int32)id_parameter.Value;
                    Conn.Close();
                    return dataset;
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
            }
        }

        /// <summary>
        /// 执行存储过程的通用方法
        /// </summary>
        /// <param name="proName">存储过程名称</param>
        /// <param name="mysqlParams">参数</param>
        /// <returns></returns>
        public DataSet ExecProcedure(string proName, MySqlParameter[] mysqlParams)
        {
            Open();
            using (MySqlDataAdapter mysqldata = new MySqlDataAdapter())
            {
                DataSet dataset = new DataSet();
                mysqldata.SelectCommand = new MySqlCommand();
                mysqldata.SelectCommand.Connection = Conn;
                mysqldata.SelectCommand.CommandText = proName;
                mysqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
                mysqldata.SelectCommand.Parameters.AddRange(mysqlParams);
                try
                {
                    mysqldata.Fill(dataset, proName);
                    Conn.Close();
                    return dataset;
                }
                catch (MySqlException ex)
                {
                    LogUtils.ErrorLog(ex.Message);
                    throw new Exception("错误提醒" + ex.Message);
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
            }
        }

        /// <summary>
        /// 执行存储过程的通用方法
        /// </summary>
        /// <param name="proName">存储过程名称</param>
        /// <param name="mysqlParams">参数</param>
        /// <returns></returns>
        public int ExtUSPByOri(string spName, string[] paraNames, MySqlDbType[] dbTypes, int[] sizes, object[] objs)
        {

            int rowsAffected = 0;
            DataSet dataset = new DataSet();
            Open();
            try
            {
                using (MySqlDataAdapter mysqldata = new MySqlDataAdapter())
                {

                    mysqldata.SelectCommand = new MySqlCommand();
                    mysqldata.SelectCommand.Connection = Conn;
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
                    rowsAffected = mysqldata.SelectCommand.ExecuteNonQuery();
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
            return rowsAffected;
        }

        /// <summary>
        /// 执行存储过程的通用方法
        /// </summary>
        /// <param name="proName">存储过程名称</param>
        /// <param name="mysqlParams">参数</param>
        /// <returns></returns>
        public int ExtUSPByOri(string spName)
        {

            int rowsAffected = 0;
            DataSet dataset = new DataSet();
            Open();
            try
            {
                using (MySqlDataAdapter mysqldata = new MySqlDataAdapter())
                {

                    mysqldata.SelectCommand = new MySqlCommand();
                    mysqldata.SelectCommand.Connection = Conn;
                    mysqldata.SelectCommand.CommandText = spName;
                    mysqldata.SelectCommand.CommandType = CommandType.StoredProcedure;
                    mysqldata.SelectCommand.CommandTimeout = 60;
                    rowsAffected = mysqldata.SelectCommand.ExecuteNonQuery();
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
            return rowsAffected;
        }

        public DataSet GetUSPByOri(string spName, string[] paraNames, MySqlDbType[] dbTypes, int[] sizes, object[] objs)
        {
            DataSet dataset = new DataSet();
            Open();
            try
            {
                using (MySqlDataAdapter mysqldata = new MySqlDataAdapter())
                {

                    mysqldata.SelectCommand = new MySqlCommand();
                    mysqldata.SelectCommand.Connection = Conn;
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

        public string transaction(string sqltest)
        {
            #region 事务处理,执行sql语句
            Open();
            string r = "0";
            MySqlTransaction tran = Conn.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Conn;
            cmd.Transaction = tran;
            try
            {
                cmd.CommandText = sqltest;
                cmd.ExecuteNonQuery();
                tran.Commit();
                Close();
                r = "1";
            }
            catch (Exception W)
            {
                tran.Rollback();
                LogUtils.ErrorLog(W.Message);
                throw W;
            }
            finally
            {
                tran.Dispose();
                Close();
            }
            return r;
            #endregion
        }

        /// <summary>
        /// 获取图片路径
        /// </summary>
        /// <param name="imgUrl">图片名称</param>
        /// <returns></returns>
        public string GetImgSrc(object imgUrl)
        {
            if (!string.IsNullOrEmpty(imgUrl.ToString()))
            {
                string imgname = imgUrl.ToString();
                string mainfile = "/KT_ServerSoft/CarPlateRecognise/";
                string ymd = imgname.Substring(0, 8);
                string hourstr = imgname.Substring(8, 2);
                string[] strarr = imgname.Split('_');
                string ipadrr = strarr[1];
                string imgsrc = mainfile + ymd + "/" + ipadrr + "/" + hourstr + "/" + imgname;
                return imgsrc;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 创建参数
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="dbType"></param>
        /// <param name="size"></param>
        /// <param name="direction"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public MySqlParameter CreateParameter(string parameterName, MySqlDbType dbType, int size, ParameterDirection direction, object value)
        {
            MySqlParameter parameter = new MySqlParameter("?" + parameterName, dbType, size);//返回值  
            parameter.Direction = direction;
            parameter.Value = value;

            return parameter;
        }
    }
}
