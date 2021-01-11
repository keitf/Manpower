using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manpower.Handlers
{
    /// <summary>
    /// Employee_DIC 的摘要说明
    /// </summary>
    public class Employee_DIC : IHttpHandler
    {

        ManpBLL.Employee_DIC Employee_dic = new ManpBLL.Employee_DIC();

        public void ProcessRequest(HttpContext context)
        {
            string ac = context.Request["ac"];

            switch (ac)
            {
                case "OptIN_eposition":
                    OptIN_eposition(context);
                    break;
                case "OptIN_epople":
                    OptIN_epople(context);
                    break;
                case "OptIN_ePoliticaloutlook":
                    ePoliticaloutlook(context);
                    break;
                case "OptIN_eeducation":
                    eeducation(context);
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

        public void OptIN_eposition(HttpContext context)
        {
            context.Response.Write(SelAllDIC(1));
        }

        public void OptIN_epople(HttpContext context)
        {
            context.Response.Write(SelAllDIC(34));
        }

        public void ePoliticaloutlook(HttpContext context)
        {
            context.Response.Write(SelAllDIC(23));
        }

        public void eeducation(HttpContext context)
        {
            context.Response.Write(SelAllDIC(29));
        }
        public string SelAllDIC(int pid)
        {
            StringBuilder sb = new StringBuilder();

            List<ManpowerMODEL.Employee_DIC> employee_DICs = new List<ManpowerMODEL.Employee_DIC>();

            employee_DICs = Employee_dic.GetModelList("");

            var position = (from s in employee_DICs where (s.PID == pid) select s).ToList();

            sb.Append("<option value=\"\">直接选择或搜索选择</option>");
            for (int i = 0; i < position.Count; i++)
            {
                sb.Append("<option value=\"" + position[i].ID + "\">" + position[i].Name + "</option>");
            }

            return sb.ToString();
        }
    }
}