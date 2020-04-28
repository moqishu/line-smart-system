using LINE.SMA.Infrastructure;
using LINE.SMA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LINE.SMA.Web.Controllers
{
    public class CommonController : BaseController
    {
        public ReportServices report = new ReportServices();

        public string GetPageData(string reportName)
        {
            try
            {
                var pars = new SqlParams().Fill();
                var result = report.GetPageData(reportName, pars);
                return result.ToJson();
            }
            catch (Exception ex)
            {
                //Response.Write("<script type='text/javascript'>alert('XXX');</script>");
                throw new AlertException(ex.ToString());
            }
        }

        /// <summary>
        /// 报表导出
        /// </summary>
        /// <param name="reportName">报表名称</param>
        /// <param name="fields">字段名称</param>
        public void ExportPageData(string reportName,string fields)
        {
            var pars = new SqlParams().Fill();
            var result = report.GetPageData(reportName, pars);

        }
    }
}
