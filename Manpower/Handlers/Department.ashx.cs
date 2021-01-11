using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ManpowerMODEL;
using System.Text;
using Newtonsoft.Json;

namespace Manpower.Handlers
{
    /// <summary>
    /// Department 的摘要说明
    /// </summary>
    public class Department : IHttpHandler
    {

        ManpBLL.Department department = new ManpBLL.Department();

        public void ProcessRequest(HttpContext context)
        {
            string ac = context.Request["ac"];

            switch (ac)
            {
                case "treedata":
                    Treedata(context);
                    break;
                case "treeadd":
                    TreeAdd(context);
                    break;
                case "treeupdate":
                    TreeUpdate(context);
                    break;
                case "treedel":
                    TreeDel(context);
                    break;
                case "OptIN_edep":
                    OptINDep(context);
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

        public void Treedata(HttpContext context)
        {
            //查询所有部门
            List<ManpowerMODEL.Department> departments = department.GetModelList("");

            //递归
            List<Treeitem.Root> roots = new List<Treeitem.Root>();

            var fdpr = (from k in departments where k.PID == 0 select k).ToList();

            if (fdpr.Count > 0)
            {
                for (int i = 0; i < fdpr.Count; i++)
                {
                    Treeitem.Root root = new Treeitem.Root()
                    {
                        title = fdpr[i].Name,
                        id = fdpr[i].ID
                    };
                    root.children = selchidren(departments, fdpr[i].ID);
                    roots.Add(root);
                }
            }

            string s = JsonConvert.SerializeObject(roots);

            context.Response.Write(s);
        }

        public void TreeAdd(HttpContext context)
        {
            string pid = context.Request["pid"];
            

            ManpowerMODEL.Department departmentinfo = new ManpowerMODEL.Department()
            {
                PID = Convert.ToInt32(pid),
                Name = "未命名"
            };

            int i = department.Add(departmentinfo);

            context.Response.Write(i);
        }

        public void TreeUpdate(HttpContext context)
        {
            string id = context.Request["id"];
            string name = context.Request["name"];

            ManpowerMODEL.Department departmentinfo = new ManpowerMODEL.Department()
            {
                ID = Convert.ToInt32(id),
                Name = name
            };

            bool bl = department.Update(departmentinfo);

            context.Response.Write(bl);
        }

        public void TreeDel(HttpContext context)
        {
            string id = context.Request["id"];

            bool bl = department.Delete(Convert.ToInt32(id));

            context.Response.Write(bl);
        }

        public void OptINDep(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();

            List<ManpowerMODEL.Department> departments = new List<ManpowerMODEL.Department>();

            departments = department.GetModelList("");

            sb.Append("<option value=\"\">直接选择或搜索选择</option>");
            for (int i = 0; i < departments.Count; i++)
            {
                sb.Append("<option value=\""+departments[i].ID+"\">"+departments[i].Name+"</option>");
            }

            context.Response.Write(sb.ToString());
        }

        public List<Treeitem.ChildrenItem> selchidren(List<ManpowerMODEL.Department> departments, int id)
        {
            List<Treeitem.ChildrenItem> childrens = new List<Treeitem.ChildrenItem>();
            var ss = (from k in departments where k.PID == id select k).ToList();
            for (int i = 0; i < ss.Count; i++)
            {
                Treeitem.ChildrenItem childrenItem = new Treeitem.ChildrenItem()
                {
                    title = ss[i].Name,
                    id = ss[i].ID
                };
                childrenItem.children = (selchidren(departments, ss[i].ID));
                childrens.Add(childrenItem);
            }
            return childrens;
        }
    }
}