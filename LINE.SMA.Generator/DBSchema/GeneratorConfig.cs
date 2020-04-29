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
        public DbConfig dbConfig { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        public string tableName { get; set; }
        /// <summary>
        /// 去掉表前缀
        /// </summary>
        public string trimTablePre { get; set; }
        /// <summary>
        /// 命名空间
        /// </summary>
        public string modelNamespaceVal { get; set; }

        public string modelSavePath { get; set; }

        public string modelTemplate { get; set; }
        /// <summary>
        /// 输入表名
        /// </summary>
        public string tableList { get; set; }

        public string moduleName { get; set; }

        public Table table { get; set; }


    }
}
