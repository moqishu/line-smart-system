using LINE.SMA.Infrastructure;
using LINE.SMA.Repositories.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINE.SMA.Service
{
    public class ReportServices
    {

        public PageData GetPageData(string reportName, SqlParams pars)
        {
            var reportHelper = new ReportHelper(reportName);

            var data = reportHelper.GetPageData(pars);

            return data;
        }

        public PageData GetOrderData()
        {


            return null;
        }

        
    }
}
