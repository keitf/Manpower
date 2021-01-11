using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Newtonsoft.Json;

namespace Manpower.Handlers
{
    /// <summary>
    /// Employee 的摘要说明
    /// </summary>
    public class Employee : IHttpHandler, IRequiresSessionState
    {
        ManpBLL.Employee EmployeeM = new ManpBLL.Employee();
        public void ProcessRequest(HttpContext context)
        {
            string ac = context.Request["ac"];

            switch (ac)
            {
                case "EmAdd":
                    EmAdd(context);
                    break;
                case "SEL":
                    EmSEl(context);
                    break;
                case "Formadd":
                    EmFormadd(context);
                    break;
                case "SelEmpByDerpID":
                    SelEmpByDerpID(context);
                    break;
                case "EmpAbout":
                    EmpAbout(context);
                    break;
                case "EmpDEl":
                    EmpDEl(context);
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

        public void EmAdd(HttpContext context)
        {
            string eminfo = context.Request["eminfo"];

            ManpowerMODEL.Employee employee = new ManpowerMODEL.Employee();

            employee = JsonConvert.DeserializeObject<ManpowerMODEL.Employee>(eminfo);

            int s = Convert.ToInt32(context.Request["eminfoid"]);

            int i;

            if (s > 0)
            {
                employee.ID = s;
                i = EmployeeM.Update(employee) ? 1 : 0;
            }
            else
            {
                i = EmployeeM.Add(employee);
            }

            context.Response.Write(i);
        }

        public void EmSEl(HttpContext context)
        {
            string stid = context.Request["stid"];

            //拼接条件
            string strWhere;
            if (stid =="0")
            {
                strWhere = "";
            }
            else if (stid == "1")
            {
                strWhere = " Status = 1 ";
            }
            else if (stid == "2")
            {
                strWhere = " Status = 0 ";
            }
            else
            {
                strWhere = "";
            }

            List<ManpowerMODEL.View_EmployeeSEL> view_EmployeeSELs = new List<ManpowerMODEL.View_EmployeeSEL>();

            ManpBLL.View_EmployeeSEL sel = new ManpBLL.View_EmployeeSEL();

            view_EmployeeSELs = sel.GetModelList(strWhere);

            EmListJson emList = new EmListJson()
            {
                code = 0,
                msg = "",
                count = view_EmployeeSELs.Count,
                data = view_EmployeeSELs
            };

            string s = JsonConvert.SerializeObject(emList);

            context.Response.Write(s);
        }

        public void EmFormadd(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request["empid"]);

            ManpowerMODEL.Employee employee = EmployeeM.GetModel(id);

            context.Response.Cookies["ename"].Value = employee.Name;
            context.Response.Cookies["esex"].Value = employee.Sex.ToString();
            context.Response.Cookies["eidcard"].Value = employee.IdCard;
            context.Response.Cookies["ephone"].Value = employee.Phone;
            context.Response.Cookies["enation"].Value = employee.Nation.ToString();
            context.Response.Cookies["esalart"].Value = employee.Salary.ToString();
            context.Response.Cookies["estatus"].Value = employee.Status.ToString();
            context.Response.Cookies["eresume"].Value = employee.Resume.ToString();
            context.Response.Cookies["edepid"].Value = employee.DepartmentID.ToString();
            context.Response.Cookies["ebir"].Value = employee.Birthday.ToString();
            context.Response.Cookies["eposi"].Value = employee.Position.ToString();
            context.Response.Cookies["email"].Value = employee.Email.ToString();
            context.Response.Cookies["epoli"].Value = employee.Polity.ToString();
            context.Response.Cookies["edegr"].Value = employee.Degree.ToString();

            context.Response.Write(employee.ID);
        }

        public void SelEmpByDerpID(HttpContext context)
        {
            string s = context.Request["IDs"];

            if (s == "")
            {
                EmSEl(context);
            }
            else
            {
                ManpBLL.View_EmployeeSEL view_EmployeeSEL = new ManpBLL.View_EmployeeSEL();

                string strWhere = string.Format("DepartmentID IN ({0}) AND Status = 1", s);

                List<ManpowerMODEL.View_EmployeeSEL> view_EmployeeSELs = view_EmployeeSEL.GetModelList(strWhere);

                EmListJson emListJson = new EmListJson()
                {
                    code = 0,
                    msg = "",
                    count = view_EmployeeSELs.Count,
                    data = view_EmployeeSELs
                };

                string eminfos = JsonConvert.SerializeObject(emListJson);

                context.Response.Write(eminfos);
            }

        }

        public void EmpAbout(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request["empid"]);

            ManpBLL.View_EmployeeSEL view_EmployeeSEL = new ManpBLL.View_EmployeeSEL();

            ManpowerMODEL.View_EmployeeSEL view_EmployeeSELinfo = view_EmployeeSEL.GetModelList("ID = " + id)[0];

            string s = JsonConvert.SerializeObject(view_EmployeeSELinfo);

            context.Response.Write(s);
        }

        public void EmpDEl(HttpContext context)
        {
            string empinfo = context.Request["empinfo"];

            context.Response.Write(EmployeeM.EmpDel(empinfo));
        }
        public class EmListJson
        {
            public int code { get; set; }

            public string msg { get; set; }

            public int count { get; set; }

            public List<ManpowerMODEL.View_EmployeeSEL> data { get; set; }
        }

    }
}