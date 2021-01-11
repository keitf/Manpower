using System.Web;

namespace Manpower.Handlers
{
    /// <summary>
    /// RoleEdit 的摘要说明
    /// </summary>
    public class RoleEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string ac = context.Request["action"];
            switch (ac)
            {
                case "selrole":
                    RoleSel(context);
                    break;
                case "RoleEditInfo":
                    Roleaddedit(context);
                    break;
                case "Treeview":
                    SelTreev(context);
                    break;
                case "RoleDel":
                    RoleDel(context);
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
        public void RoleSel(HttpContext context)
        {
            ManpBLL.RoleService roleService = new ManpBLL.RoleService();
            context.Response.Write(roleService.RoleSel());
        }
        public void Roleaddedit(HttpContext context)
        {
            ManpBLL.RoleService roleService = new ManpBLL.RoleService();
            string id = context.Request["roleinfo_id"];
            string name = context.Request["roleinfo_name"];
            string content = context.Request["roleinfo_content"];
            string expower = context.Request["expower"];

            //id为空【添加】
            if ("" == id)
            {
                context.Response.Write(roleService.AddRole(name, content, expower));
            }
            else
            {
                context.Response.Write(roleService.Edit(id, name, content, expower));
            }

        }
        public void SelTreev (HttpContext context)
        {
            ManpBLL.RoleService roleService = new ManpBLL.RoleService();
            context.Response.Write(roleService.RoleMenu());
        }
        public void RoleDel(HttpContext context)
        {
            ManpBLL.RoleService roleService = new ManpBLL.RoleService();
            string arrid = context.Request["roleid"];
            context.Response.Write(roleService.RoleDel(arrid));
        }
    }
}