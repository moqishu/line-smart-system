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
            allConfig.inputTables = Console.ReadLine();
            Console.WriteLine("请输入模块名(空则直接ENTER跳过):");
            allConfig.moduleName = Console.ReadLine();
            //
            DbConfig dbConfig = new DbConfig();

            dbConfig.dataBaseName = "natsucloud";
            dbConfig.userName = "root";
            dbConfig.port = 5831;
            dbConfig.password = "Keytop:wabjtam!";
            dbConfig.ip = "127.0.0.1";
            allConfig.dbConfig = dbConfig;

            allConfig.modelNamespaceVal = "LINE.SMA.Model";
            allConfig.modelSavePath = @"D:\SMA";
            allConfig.modelTemplate = "ModelAuto";
            allConfig.trimTablePre = "t_";
            allConfig.baseColumn = "id";

            allConfig.repNamespaceVal= "LINE.SMA.Repositories";
            allConfig.repSavePath = @"D:\SMA";
            allConfig.repTemplate = "RepositoryAuto";

            allConfig.iRepNamespaceVal = "LINE.SMA.Repositories";
            allConfig.iRepSavePath = @"D:\SMA";
            allConfig.iRepTemplate = "IRepositoryAuto";

            AutoGenerator.startExecute(allConfig);
        }

       
    }
}
