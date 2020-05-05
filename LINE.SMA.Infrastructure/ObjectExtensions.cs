using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace LINE.SMA.Infrastructure
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// 非NULL字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string AsString(this object source)
        {
            if (source == null || source == DBNull.Value)
            {
                return string.Empty;
            }
            return Convert.ToString(source).Trim();
        }

        /// <summary>
        /// 非NULL int
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int AsInt(this object source)
        {
            if (source == null || source == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToInt32(source);
        }

        /// <summary>
        /// 可NULL int
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int? AsIntNullable(this object source)
        {
            if (source == null || source == DBNull.Value)
            {
                return null;
            }
            return Convert.ToInt32(source);
        }
        /// <summary>
        /// 非NULL Long
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static long AsLong(this object source)
        {
            if (source == null || source == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToInt64(source);
        }

        /// <summary>
        /// 非NULL Decimal
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static decimal AsDecimal(this object source)
        {
            if (source == null || source == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToDecimal(source);
        }

        /// <summary>
        /// 非NULL Double
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static double AsDouble(this object source)
        {
            if (source == null || source == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToDouble(source);
        }

        /// <summary>
        /// 非NULL bool
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool AsBool(this object source)
        {
            if (source == null || source == DBNull.Value)
            {
                return false;
            }
            return Convert.ToBoolean(source);
        }
        /// <summary>
        /// 时间转换
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime AsDateTime(this object source)
        {
            if (source == null || source == DBNull.Value)
            {
                return default(DateTime);
            }
            return Convert.ToDateTime(source);
        }

        /// <summary>
        /// 时间转换
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime? AsDateTimeNullable(this object source)
        {
            if (source == null || source == DBNull.Value)
            {
                return null;
            }
            return Convert.ToDateTime(source);
        }

        /// <summary>
        /// 枚举转换
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T AsEnum<T>(this object source) where T : struct, IConvertible
        {
            var type = typeof(T);
            if (!Enum.IsDefined(type, source.AsInt()))
                throw new Exception(source + "转为枚举类型的" + type.Name + "失败！");

            return (T)Enum.Parse(type, source.AsString());
        }

        public static object DeepClone(this object obj)
        {
            if (obj == null)
                return null;
            using (var memory = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memory, obj);
                memory.Position = 0;
                return binaryFormatter.Deserialize(memory);
            }
        }

        public static T DeepClone<T>(this T sourceObject) where T : class
        {
            if (sourceObject == null)
                return null;
            return DeepClone((object)sourceObject) as T;
        }

        public static T DeepCopy<T>(this T obj)
        {
            //如果是字符串或值类型则直接返回
            if (obj is string || obj.GetType().IsValueType) return obj;

            object retval = Activator.CreateInstance(obj.GetType());
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                try { field.SetValue(retval, DeepCopy(field.GetValue(obj))); }
                catch { }
            }
            return (T)retval;
        }


        //public static T ConvertType<T>(this object sourceObject) where T : class
        //{
        //    if (sourceObject == null)
        //        return null;
        //    return sourceObject.ToJson().JsonToObject<T>();
        //}

        public static long ObjectSize(this object obj)
        {
            if (obj == null)
                return 0;
            using (var memory = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memory, obj);
                return memory.Length;
            }
        }

        //public static List<TTo> Convert<TFrom, TTo>(this List<TFrom> sourceCollection) where TFrom : TTo
        //{
        //    List<TTo> result = new List<TTo>();
        //    foreach (TFrom sourceObject in sourceCollection)
        //    {
        //        result.Add(sourceObject);
        //    }
        //    return result;
        //}

        //public static string ToBase64(object obj)
        //{
        //    if (obj == null) return string.Empty;
        //    using (MemoryStream memory = new MemoryStream())
        //    {
        //        BinaryFormatter formatter = new BinaryFormatter();
        //        formatter.Serialize(memory, obj);
        //        return Convert.ToBase64String(memory.ToArray());
        //    }
        //}

        //public static T DeserializeFromBase64<T>(string base64String)
        //{
        //    if (string.IsNullOrEmpty(base64String))
        //        return default(T);
        //    using (MemoryStream memory = new MemoryStream(Convert.FromBase64String(base64String)))
        //    {
        //        BinaryFormatter formatter = new BinaryFormatter();
        //        return (T)formatter.Deserialize(memory);
        //    }
        //}
    }
}