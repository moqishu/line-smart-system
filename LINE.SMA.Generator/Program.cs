using LINE.SMA.Generator.DBSchema;
using LINE.SMA.Generator.EnumExt;
using LINE.SMA.Generator.Utils;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINE.SMA.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            TemplateHelper.Init();

            GeneratorConfig allConfig = new GeneratorConfig();

            Console.WriteLine("请输入表名:");
            allConfig.tableList = Console.ReadLine();
            Console.WriteLine("请输入模块名:");
            allConfig.moduleName = Console.ReadLine();
            //
            DbConfig dbConfig = new DbConfig();

            dbConfig.dataBaseName = "ktpark";
            dbConfig.userName = "root";
            dbConfig.port = 3306;
            dbConfig.password = "123456";
            dbConfig.ip = "127.0.0.1";

            allConfig.dbConfig = dbConfig;
            allConfig.modelNamespaceVal = "DapperTemplate.Model";
            allConfig.modelSavePath = @"D:\Model";
            allConfig.modelTemplate = "ModelAuto";

            allConfig.trimTablePre = "t_";

            //生成Model================================================

            GenerateTemplate_Model(allConfig);
            

            Pause();
        }

        private static void GenerateTemplate_Model(GeneratorConfig allConfig)
        {
            Console.WriteLine("===============生成Model==================");
            DisplayTemplateName(allConfig.modelTemplate);
            var templateText = TemplateHelper.ReadTemplate(allConfig.modelTemplate);

            var db = new MySqlSchema(allConfig.dbConfig);
            var tableList = db.GetTablesList();
            tableList = tableList.Where(c => allConfig.tableList.Split(',').Contains(c)).ToList();

            foreach (var tableName in tableList)
            {
                var table = db.GetTableMetadata(tableName);

                if (!string.IsNullOrEmpty(allConfig.trimTablePre))
                {
                    table.ClassName = TrimPre(tableName, allConfig.trimTablePre);
                }

                //if (table.PKs.Count == 0) throw new Exception(string.Format("表{0}:没有设置主键！", tableName));
                Display(tableName, table);
                dynamic viewbag = new DynamicViewBag();
                viewbag.classnameVal = tableName;
                viewbag.namespaceVal = allConfig.modelNamespaceVal;
                allConfig.table = table;
                var outputText = TemplateHelper.Parse(TemplateKey.Model, templateText, allConfig, viewbag);
                outputText = TemplateHelper.Clean(outputText, RegexPub.H1());
                FileHelper.Save(string.Format(@"{0}\{1}.cs", allConfig.modelSavePath, viewbag.classnameVal), outputText);
            }

            Console.WriteLine("===============生成Model完成===============");
        }

        private static string TrimPre(string tableName,string trimTablePre)
        {
            char[] charArray = trimTablePre.ToCharArray();
            var  result = tableName.TrimStart(charArray);

            result = result.Replace("_", string.Empty);
            return result.Substring(0, 1).ToUpper() + result.Substring(1, result.Length - 1);
        }


        private static void Pause()
        {
            Console.ReadKey();
        }

        private static void DisplayTemplateName(string name)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Display Template Name:{0}", name);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Display(string tableName, Table table)
        {
            //foreach (Column col in table.Columns)
            //{
            //    Console.WriteLine("tableName:{0},table.ColumnNames:{1}", tableName, col.ColumnName);
            //}
            Console.WriteLine("正在生成表模型" + tableName);
        }
    }
}
