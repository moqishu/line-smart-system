using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINE.SMA.Generator.DBSchema
{
    /// <summary>
    /// 代码生成配置类
    /// </summary>
    public class GeneratorConfig
    {
        /// <summary>
        /// 数据连接
        /// </summary>
        public DbConfig dbConfig { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        public string tableName { get; set; }
       
        public List<string> tableList { get; set; }
        /// <summary>
        /// 输入表名，逗号分隔符
        /// </summary>
        public string inputTables { get; set; }
        /// <summary>
        /// 去掉表前缀
        /// </summary>
        public string trimTablePre { get; set; }
        /// <summary>
        /// 模块名
        /// </summary>
        public string moduleName { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        public string modelNamespaceVal { get; set; }

        public string modelSavePath { get; set; }

        public string modelTemplate { get; set; }

        public Table table { get; set; }
        public string repNamespaceVal { get; set; }
        public string repSavePath { get; set; }
        public string repTemplate { get; set; }
        public string iRepNamespaceVal { get; set; }
        public string iRepSavePath { get; set; }
        public string iRepTemplate { get; set; }
        public string serviceNamespaceVal { get; set; }
        public string serviceSavePath { get; set; }
        public string serviceTemplate { get; set; }

        public string baseColumn { get; set; }

        public string repClassName { get; set; }

        public string repInterfaceName { get; set; }

        public string serviceClassName { get; set; }
    }
}
