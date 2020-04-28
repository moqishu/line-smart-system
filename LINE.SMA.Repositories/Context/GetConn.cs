using System;

namespace LINE.SMA.Repositories.Context
{
    /// <summary>
    ///GetConn 的摘要说明
    /// </summary>
    public class GetConn
    {
        public GetConn()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
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
        public string Set_Tpye_Connection(String str, String str_Conn)
        {
            String RValue = "";
            switch (str.ToUpper())
            {
                case "TEST":
                    RValue = GetConnectionString(str_Conn + "_TEST");
                    break;
                case "PROD":
                    RValue = GetConnectionString(str_Conn + "_PROD");
                    break;
                case "DEVL":
                    RValue = GetConnectionString(str_Conn + "_DEVL");
                    break;
                default:
                    RValue = GetConnectionString(str_Conn + "_TEST");
                    break;
            }
            return RValue;
        }
        public string Get_Conn_Type(String str)
        {
            String RValue = "";
            if (str.IndexOf("?") > 0)
            {
                String[] Params = str.Substring(str.IndexOf("?") + 1, str.Length - str.IndexOf("?") - 1).Split('&');
                for (int i = 0; i < Params.Length; i++)
                {
                    String[] Params_Value = Params[i].Split('=');
                    if (Params_Value[0].Equals("type"))
                        RValue = Params_Value[1];
                }
            }
            return RValue;
        }
        public string Get_Conn_Type(String str, String name)
        {
            String RValue = "";
            if (str.IndexOf("?") > 0)
            {
                String[] Params = str.Substring(str.IndexOf("?") + 1, str.Length - str.IndexOf("?") - 1).Split('&');
                for (int i = 0; i < Params.Length; i++)
                {
                    String[] Params_Value = Params[i].Split('=');
                    if (Params_Value[0].Equals(name))
                        RValue = Params_Value[1];
                }
            }
            return RValue;
        }
    }
}
