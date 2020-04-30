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
    public class AutoGenerator
    {

        public static void startExecute(GeneratorConfig allConfig)
        {
            // GeneratorConfig配置处理
            var db = new MySqlSchema(allConfig.dbConfig);
            var tableList = db.GetTablesList();
            if (!string.IsNullOrEmpty(allConfig.inputTables))
            {
                tableList = tableList.Where(c => allConfig.inputTables.Split(',').Contains(c)).ToList();
            }
            if (tableList.Count == 0)
            {
                Console.WriteLine("表名不存在");
                return;
            }
            allConfig.tableList = tableList;

            try
            {
                GenerateTemplate_Model(allConfig);
                GenerateTemplate_Rep(allConfig);
                GenerateTemplate_IRep(allConfig);

                Pause();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
            
        }

        private static void GenerateTemplate_Model(GeneratorConfig allConfig)
        {
            Console.WriteLine("===============生成Model==================");
            DisplayTemplateName(allConfig.modelTemplate);
            var templateText = TemplateHelper.ReadTemplate(allConfig.modelTemplate);
            var db = new MySqlSchema(allConfig.dbConfig);
            foreach (var tableName in allConfig.tableList)
            {
                var table = db.GetTableMetadata(tableName);

                if (!string.IsNullOrEmpty(allConfig.trimTablePre))
                {
                    table.ClassName = TrimPre(tableName, allConfig.trimTablePre);
                }
                if (!string.IsNullOrEmpty(allConfig.baseColumn))
                {
                    table.BaseColumns = allConfig.baseColumn.Split(',').ToList();
                }
                table.TableName = tableName;

                //if (table.PKs.Count == 0) throw new Exception(string.Format("表{0}:没有设置主键！", tableName));
                Display(tableName, table);
                dynamic viewbag = new DynamicViewBag();
                viewbag.classnameVal = table.ClassName;
                viewbag.namespaceVal = allConfig.modelNamespaceVal;
                allConfig.table = table;
                var outputText = TemplateHelper.Parse(TemplateKey.Model, templateText, allConfig, viewbag);
                outputText = TemplateHelper.Clean(outputText, RegexPub.H1());

                var path = allConfig.modelSavePath + "\\" + allConfig.moduleName;

                FileHelper.Save(string.Format(@"{0}\{1}.cs", path, viewbag.classnameVal), outputText);
            }

            Console.WriteLine("===============生成Model完成==================");
        }

        private static void GenerateTemplate_Rep(GeneratorConfig allConfig)
        {
            Console.WriteLine("===============生成Repositories==================");
            DisplayTemplateName(allConfig.repTemplate);
            var templateText = TemplateHelper.ReadTemplate(allConfig.repTemplate);

            foreach (var tableName in allConfig.tableList)
            {
                if (!string.IsNullOrEmpty(allConfig.trimTablePre))
                {
                    allConfig.tableName = TrimPre(tableName, allConfig.trimTablePre);
                }

                var className = allConfig.tableName + "Repository";
                allConfig.repClassName = className;
                allConfig.repInterfaceName = "I" + className;
                var outputText = TemplateHelper.Parse(TemplateKey.Dao, templateText, allConfig);
                outputText = TemplateHelper.Clean(outputText, RegexPub.H1());

                var path = allConfig.repSavePath + "\\Repositories\\" + allConfig.moduleName;

                Console.WriteLine("生成Repositories表名:" + className);

                FileHelper.Save(string.Format(@"{0}\{1}.cs", path, className), outputText);
            }

            Console.WriteLine("===============生成Repositories完成===============");
        }

        private static void GenerateTemplate_IRep(GeneratorConfig allConfig)
        {
            Console.WriteLine("===============生成IRepositories==================");
            DisplayTemplateName(allConfig.iRepTemplate);
            var templateText = TemplateHelper.ReadTemplate(allConfig.iRepTemplate);

            foreach (var tableName in allConfig.tableList)
            {
                if (!string.IsNullOrEmpty(allConfig.trimTablePre))
                {
                    allConfig.tableName = TrimPre(tableName, allConfig.trimTablePre);
                }

                var className = "I" + allConfig.tableName + "Repository";
                allConfig.repInterfaceName = className;
                var outputText = TemplateHelper.Parse(TemplateKey.IDao, templateText, allConfig);
                outputText = TemplateHelper.Clean(outputText, RegexPub.H1());

                var path = allConfig.iRepSavePath + "\\Repositories\\" + allConfig.moduleName + "\\Interface";

                Console.WriteLine("生成IRepositories表名:" + className);

                FileHelper.Save(string.Format(@"{0}\{1}.cs", path, className), outputText);
            }

            Console.WriteLine("===============生成IRepositories完成===============");
        }

        private static string TrimPre(string tableName, string trimTablePre)
        {
            char[] charArray = trimTablePre.ToCharArray();
            var result = tableName.TrimStart(charArray);

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
