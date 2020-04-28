using System.Collections.Generic;
using System.Data;
using System.Web;
using Newtonsoft.Json;

namespace LINE.SMA.Infrastructure
{
    public class PageData
    {
        public PageData()
        {
            this.Data = new DataTable();
            this.Footer = new DataTable();
            this.Total = 0;
        }

        public PageData(DataTable data, int total)
        {
            this.Data = data;
            this.Total = total;
        }

        [JsonProperty("rows")]
        public DataTable Data { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("footer")]
        public DataTable Footer { get; set; }  

        public string ToJsonResult()
        {
            return this.ToJson();
        }
    }

    public class PageData<T>
    {
        public PageData()
        {
            this.Data = new List<T>();
            this.Total = 0;
        }

        public PageData(List<T> data, int total)
        {
            this.Data = data;
            this.Total = total;
        }

        [JsonProperty("rows")]
        public List<T> Data { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        public string ToJsonResult()
        {
            return this.ToJson();
        }

        public string GetNextUrl(int pageIndex)
        {
            var request = HttpContext.Current.Request;
            var result =request.Url.AbsoluteUri;
            var url = "";
            if (result.Contains("Page"))
            {
                var index = result.LastIndexOf('=');
                url = result.Substring(0,index+1)+pageIndex;
            }
            else
            {
                url =result+ "&Page=" + pageIndex;
            }

            return url;
        }
    }
}
