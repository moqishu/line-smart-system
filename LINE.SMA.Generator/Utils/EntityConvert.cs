using MySql.Data.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LINE.SMA.Generator.Utils
{
    public static class EntityConvert
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="srcDT">要转换的表</param>
        /// <param name="relation">此值可为空，如果实体属性与表字段不一致才设置（key表字段，value实体字段;）</param>
        /// <returns></returns>
        public static List<T> Dt2List<T>(this DataTable srcDT, Hashtable relation = null)
        {
            List<T> list = new List<T>();
            T destObj = default(T);
            if (srcDT != null && srcDT.Rows.Count > 0)
            {
                list = new List<T>();
                foreach (DataRow row in srcDT.Rows)
                {
                    destObj = EntityConvert.GetEntityListByDT<T>(row, relation);
                    list.Add(destObj);
                }
            }
            return list;
        }
        public static T GetEntityListByDT<T>(DataRow row, Hashtable relation = null)
        {
            Type type = typeof(T);
            T destObj = Activator.CreateInstance<T>();
            PropertyInfo[] properties = type.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo prop = properties[i];
                if (row.Table.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                {
                    EntityConvert.SetPropertyValue(prop, destObj, row[prop.Name]);
                }
            }
            if (relation != null)
            {
                foreach (string name in relation.Keys)
                {
                    PropertyInfo temp = type.GetProperty(relation[name].ToString());
                    if (temp != null && row[name] != DBNull.Value)
                    {
                        EntityConvert.SetPropertyValue(temp, destObj, row[name]);
                    }
                }
            }
            return destObj;
        }
        public static List<T> GetEntityListByDT<T>(DataRow[] rows, Hashtable relation)
        {
            List<T> list = null;
            T destObj = default(T);
            if (rows != null && rows.Length > 0)
            {
                list = new List<T>();
                for (int i = 0; i < rows.Length; i++)
                {
                    DataRow row = rows[i];
                    destObj = EntityConvert.GetEntityListByDT<T>(row, relation);
                    list.Add(destObj);
                }
            }
            return list;
        }
        private static void SetPropertyValue(PropertyInfo prop, object destObj, object value)
        {
            object temp = EntityConvert.ChangeType(prop.PropertyType, value);
            prop.SetValue(destObj, temp, null);
        }
        private static object ChangeType(Type type, object value)
        {
            object result;
            if (value == null && type.IsGenericType)
            {
                result = Activator.CreateInstance(type);
            }
            else
            {
                if (value == null)
                {
                    result = null;
                }
                else
                {
                    if (type == value.GetType())
                    {
                        result = value;
                    }
                    else
                    {
                        if (type.IsEnum)
                        {
                            if (value is string)
                            {
                                result = Enum.Parse(type, value as string);
                            }
                            else
                            {
                                result = Enum.ToObject(type, value);
                            }
                        }
                        else
                        {
                            if (type == typeof(bool) && typeof(int).IsInstanceOfType(value))
                            {
                                int temp = int.Parse(value.ToString());
                                result = (temp != 0);
                            }
                            else
                            {
                                if (!type.IsInterface && type.IsGenericType)
                                {
                                    Type type2 = type.GetGenericArguments()[0];
                                    object obj = EntityConvert.ChangeType(type2, value);
                                    result = Activator.CreateInstance(type, new object[]
                                    {
                                        obj
                                    });
                                }
                                else
                                {
                                    if (value is string && type == typeof(Guid))
                                    {
                                        result = new Guid(value as string);
                                    }
                                    else
                                    {
                                        if (value is string && type == typeof(Version))
                                        {
                                            result = new Version(value as string);
                                        }
                                        else
                                        {
                                            if (!(value is IConvertible))
                                            {
                                                result = value;
                                            }
                                            else if (value is MySqlDateTime)
                                            {
                                                object temp;
                                                temp = Convert.ChangeType(value.ToString(), System.TypeCode.DateTime);
                                                result = Convert.ChangeType(temp, type);
                                            }
                                            else
                                            {
                                                result = Convert.ChangeType(value, type);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static List<T> ToList<T>(this DataTable srcDT, Hashtable relation = null)
        {
            List<T> list = new List<T>();
            T destObj = default(T);
            if (srcDT != null && srcDT.Rows.Count > 0)
            {
                list = new List<T>();
                foreach (DataRow row in srcDT.Rows)
                {
                    destObj = EntityConvert.GetEntityListByDT<T>(row, relation);
                    list.Add(destObj);
                }
            }
            return list;
        }

        public static T ToList<T>(this DataRow row, Hashtable relation = null)
        {
            Type type = typeof(T);
            T destObj = Activator.CreateInstance<T>();
            PropertyInfo[] properties = type.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo prop = properties[i];
                if (row.Table.Columns.Contains(prop.Name) && row[prop.Name] != DBNull.Value)
                {
                    EntityConvert.SetPropertyValue(prop, destObj, row[prop.Name]);
                }
            }
            if (relation != null)
            {
                foreach (string name in relation.Keys)
                {
                    PropertyInfo temp = type.GetProperty(relation[name].ToString());
                    if (temp != null && row[name] != DBNull.Value)
                    {
                        EntityConvert.SetPropertyValue(temp, destObj, row[name]);
                    }
                }
            }
            return destObj;
        }
    }
}
