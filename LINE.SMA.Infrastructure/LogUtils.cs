using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LINE.SMA.Infrastructure
{
    /// <summary>
    /// Log处理类
    /// </summary>
    public class LogUtils
    {
        public LogUtils()
        {
        }
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");   //选择<logger name="loginfo">的配置 

        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");   //选择<logger name="logerror">的配置 
        public static void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        /// <summary>
        /// 设置文件路径
        /// </summary>
        /// <param name="configFile"></param>
        public static void SetConfig(FileInfo configFile)
        {
            log4net.Config.XmlConfigurator.Configure(configFile);
        }
        /// <summary>
        /// 操作日志
        /// </summary>
        /// <param name="info"></param>
        public static void InfoLog(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }

        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="message">错误信息</param>
        public static void ErrorLog(string message)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(message);
            }
        }

        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="Error">错误信息</param>
        /// <param name="ex">错误路经</param>
        public static void ErrorLog(string message, Exception ex)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(message, ex);
            }
        }
    }
}
