using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manpower.Handlers
{
    /// <summary>
    /// Statistics 的摘要说明
    /// </summary>
    public class Statistics : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string ac = context.Request["ac"];

            switch (ac)
            {
                case "SelSex":
                    SelSex(context);
                    break;
                case "SelDegree":
                    SelDegree(context);
                    break;
                case "SelDepartment":
                    SelDepartment(context);
                    break;
                case "SelSalary":
                    SelSalary(context);
                    break;
                default:
                    break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        ManpBLL.Statistics Statisticss = new ManpBLL.Statistics();

        public void SelSex(HttpContext context)
        {
            context.Response.Write(Statisticss.SexStatis());
        }
        public void SelDegree(HttpContext context)
        {
            context.Response.Write(Statisticss.EchartsData("View_Degree"));
        }
        public void SelDepartment(HttpContext context)
        {
            context.Response.Write(Statisticss.EchartsData("View_Department"));
        }
        public void SelSalary(HttpContext context)
        {
            context.Response.Write(Statisticss.Salary());
        }
    }
}