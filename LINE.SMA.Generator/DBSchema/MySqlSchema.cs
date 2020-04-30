using LINE.SMA.Generator.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINE.SMA.Generator.DBSchema
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public class MySqlSchema
    {
        // "server=127.0.0.1;port=3306;Database=ktpark;User ID=root;Password=123456"
        public string ConnectionString = @"server={0};port={1};Database={2};User ID={3};Password={4}";

        public MySqlConnection conn;

        public string dataBasename;

        public MySqlSchema(DbConfig config)
        {
            this.dataBasename = config.dataBaseName;
            ConnectionString = string.Format(ConnectionString, config.ip, config.port, config.dataBaseName, config.userName, config.password);

            conn = new MySqlConnection(ConnectionString);
            conn.Open();
        }

        public List<string> GetTablesList()
        {
            //DataTable dt = conn.GetSchema("Tables");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" SELECT TABLE_NAME from information_schema.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA='{0}' ", dataBasename);
            string selectCmdText = sb.ToString();
            MySqlCommand command = new MySqlCommand(selectCmdText, conn);
            MySqlDataAdapter ad = new MySqlDataAdapter(command);
            System.Data.DataSet ds = new DataSet();
            ad.Fill(ds);
            List<string> list = new List<string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(row["TABLE_NAME"].ToString());
            }
            return list;
        }

        public Table GetTableMetadata(string tableName)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" SELECT                                ");
            sb.AppendLine("   COLUMN_NAME,                        ");
            sb.AppendLine("   COLUMN_TYPE,                        ");
            sb.AppendLine("   DATA_TYPE,                          ");
            sb.AppendLine("   CHARACTER_MAXIMUM_LENGTH,           ");
            sb.AppendLine("   IS_NULLABLE,                        ");
            sb.AppendLine("   COLUMN_DEFAULT,                     ");
            sb.AppendLine("   COLUMN_COMMENT                      ");
            sb.AppendLine(" FROM                                  ");
            sb.AppendLine("  INFORMATION_SCHEMA.COLUMNS           ");
            sb.AppendFormat(" WHERE table_name  = '{0}'    ", tableName);

            string selectCmdText = sb.ToString();
            MySqlCommand command = new MySqlCommand(selectCmdText, conn);
            MySqlDataAdapter ad = new MySqlDataAdapter(command);
            System.Data.DataSet ds = new DataSet();
            ad.Fill(ds);
            Table table = new Table();
            table.TableName = tableName;

            // DataTable转List
            table.Columns = ds.Tables[0].Dt2List<Column>();

            return table;
        }

        public void Dispose()
        {
            if (conn != null)
                conn.Close();
        }
    }
}
