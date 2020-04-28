using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LINE.SMA.Infrastructure
{
    public class SqlParams
    {
        public SqlParams()
        {
            Where = new Dictionary<string, object>();
            PageIndex = 1;
            PageSize = 100;
        }

        public SqlParams(int pageSize = 100)
            : this()
        {
            PageSize = pageSize;
        }

        public SqlParams(int index, int size)
            : this()
        {
            PageIndex = index;
            PageSize = size;
        }
        public SqlParams(int index, int size, Dictionary<string, object> where)
            : this()
        {
            PageIndex = index;
            PageSize = size;
            Where = where;
        }

        /// <summary>
        /// 将HttpContext.Current.Request的request.QueryString和request.Form转换并填充到SqlParams
        /// </summary>
        /// <returns></returns>
        public SqlParams Fill()
        {
            var request = HttpContext.Current.Request;
            if (!string.IsNullOrEmpty(request["page"]))
                PageIndex = request.Form["page"].ToInt(PageIndex);

            if (!string.IsNullOrEmpty(request["rows"]))
                PageSize = request.Form["rows"].ToInt(PageSize);

            if (!string.IsNullOrEmpty(request["sort"]))
                Order = request.Form["sort"] + " " + request.Form["order"];
            FillWhere(request.QueryString, request.Form);

            return this;
        }

        /// <summary>
        /// 将HttpContext.Current.Request的request.QueryString和request.Form转换并填充到SqlParams
        /// </summary>
        /// <returns></returns>
        public SqlParams FillBootStrapTable()
        {
            var request = HttpContext.Current.Request;

            if (!string.IsNullOrEmpty(request["limit"]))
                PageSize = request["limit"].ToInt(PageSize);

            if (!string.IsNullOrEmpty(request["offset"]))
                PageIndex = request["offset"].ToInt(PageIndex) / PageSize + 1;

            if (!string.IsNullOrEmpty(request["sort"]))
                Order = HttpContext.Current.Request["sort"] + " " + request["order"];
            FillWhere(request.QueryString, request.Form);

            return this;
        }


        protected void FillWhere(params NameValueCollection[] collections)
        {
            foreach (var collection in collections)
            {
                foreach (var item in collection)
                {
                    var key = item.ToString();
                    if (Where.Any(p => p.Key.ToLower() == key.ToLower()) || string.IsNullOrEmpty(collection[key])
                        || key.ToLower() == "page" || key.ToLower() == "rows" || key.ToLower() == "order" || key.ToLower() == "sort")
                        continue;

                    Where.Add(key, collection[key].Trim());
                }
            }
        }

        /// <summary>
        /// 添加Where
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void Add(string key, object value)
        {
            if (Where == null)
                Where = new Dictionary<string, object>();
            if (Where.ContainsKey(key))
                Where.Remove(key);

            if (string.IsNullOrEmpty(key) || value == null || (value is string && string.IsNullOrEmpty(value.ToString())))
                return;

            Where.Add(key, value);
        }

        public object this[string key]
        {
            get
            {
                if (Where == null || !Where.ContainsKey(key))
                    return null;
                return Where[key];
            }
            set
            {
                this.Add(key, value);
            }
        }

        public Dictionary<string, object> Where { get; set; }

        public string Order { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }
    }
}
