using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Data;

namespace LINE.SMA.Generator.Utils
{
    public static class DataTableUtils
    {
        public static void CheckTableHeader(this DataTable dt, string[] checkHeaders)
        {
            foreach (var header in checkHeaders)
            {
                bool result = false;
                foreach (DataColumn column in dt.Columns)
                {
                    if (column.ColumnName == header)
                    {
                        result = true;
                        break;
                    }
                }
                if (!result)
                    throw new Exception(String.Format("导入失败,文档未找到列【{0}】，请参考模板！", header));
            }
        }

        public static List<T> ConverClassList<T>(this DataTable dt) where T : class
        {
            var list = new List<T>();
            Type t = typeof(T);
            foreach (DataRow dr in dt.Rows)
            {
                object obj = Activator.CreateInstance(t);  //创建实例
                foreach (var property in t.GetProperties())
                {
                    if (dr.Table.Columns.Contains(property.Name))
                    {
                        object value = dr[property.Name];
                        if (!Convert.IsDBNull(dr[property.Name]))
                        {
                            property.SetValue(obj, value, null);
                        }
                        else
                        {
                            property.SetValue(obj, null, null);
                        }
                    }
                }
                list.Add(obj as T);
            }

            return list;
        }

        public static List<T> ToList<T>(this DataTable dt) where T : class
        {
            var list = new List<T>();
            Type t = typeof(T);
            foreach (DataRow dr in dt.Rows)
            {
                object obj = Activator.CreateInstance(t);  //创建实例
                foreach (var property in t.GetProperties())
                {
                    if (dr.Table.Columns.Contains(property.Name))
                    {
                        object value = dr[property.Name];
                        if (!Convert.IsDBNull(dr[property.Name]))
                        {
                            property.SetValue(obj, value, null);
                        }
                        else
                        {
                            property.SetValue(obj, null, null);
                        }
                    }
                }
                list.Add(obj as T);
            }

            return list;
        }

        /// <summary>
        /// 将泛类型集合List类转换成DataTable
        /// </summary>
        /// <param name="entitys">泛类型集合</param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this List<T> entitys)
        {
            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                throw new Exception("需转换的集合为空");
            }
            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();

            //生成DataTable的structure
            //生产代码中，应将生成的DataTable结构Cache起来，此处略
            DataTable dt = new DataTable();
            for (int i = 0; i < entityProperties.Length; i++)
            {
                //dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                dt.Columns.Add(entityProperties[i].Name);
            }
            //将所有entity添加到DataTable中
            foreach (object entity in entitys)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[entityProperties.Length];
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    entityValues[i] = entityProperties[i].GetValue(entity, null);
                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }
    }
}
