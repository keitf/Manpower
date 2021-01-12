using System;
using System.Web;

namespace Manpower.Handlers
{
    /// <summary>
    /// UserEdit 的摘要说明
    /// </summary>
    public class UserEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string ac = context.Request["ac"];
            switch (ac)
            {
                case "ReadJson":
                    UserJson(context);
                    break;
                case "SelOptin":
                    UserSelOptin(context);
                    break;
                case "DelSelo":
                    UserDelSel(context);
                    break;
                case "UserEditInfo":
                    UserEditInfo(context);
                    break;
                case "UserRepwd":
                    UserRepwd(context);
                    break;
                case "CheckDuplicate":
                    Check_Duplicate(context);
                    break;
                case "UserReg":
                    UserReg(context);
                    break;
                case "mibaolist":
                    mibaolist(context);
                    break;
                case "Userrecover":
                    Userrecover(context);
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
        public void UserJson(HttpContext context)
        {
            int page = Convert.ToInt32(context.Request["page"]);
            int limit = Convert.ToInt32(context.Request["limit"]);
            string id = context.Request["id"];
            string name = context.Request["name"];
            string rid = context.Request["rid"];
            ManpBLL.UserService user = new ManpBLL.UserService();
            context.Response.Write(user.UserJosnEdit(page, limit, id, name, rid));
        }
        public void UserSelOptin(HttpContext context)
        {
            ManpBLL.UserService user = new ManpBLL.UserService();
            context.Response.Write(user.UserSelOption());
        }

        public void UserDelSel(HttpContext context)
        {
            string arridjson = context.Request["arridjson"];
            ManpBLL.UserService user = new ManpBLL.UserService();
            context.Response.Write(user.UserSelDel(arridjson));
        }
        public void UserEditInfo(HttpContext context)
        {
            string userinfo = context.Request["userinfo"];
            ManpBLL.UserService user = new ManpBLL.UserService();
            ManpowerMODEL.UserAddEditInfo addeditInfo = new ManpowerMODEL.UserAddEditInfo();
            addeditInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<ManpowerMODEL.UserAddEditInfo>(userinfo);
            //根据id是否为空判断 添加OR修改
            string id = addeditInfo.id;
            int i = 0;
            if (id != "")
            {
                i = user.UserEdit(addeditInfo);
            }
            else
            {
                i = user.UserAdd(addeditInfo);
            }
            context.Response.Write(i);
        }
        public void UserRepwd(HttpContext context)
        {
            ManpBLL.UserService user = new ManpBLL.UserService();
            //opwd: oldpwd,id: id,npwd: newpwd

            string opwd = context.Request["opwd"];
            int id = Convert.ToInt32(context.Request["id"]);
            string npwd = context.Request["npwd"];

            context.Response.Write(user.Repwd(opwd, id, npwd));
        }

        public void Check_Duplicate(HttpContext context)
        {
            string uname = context.Request["user"].ToString();

            ManpBLL.UserService user = new ManpBLL.UserService();

            int i = user.CheckDuplicate(uname);
            
            context.Response.Write(i);
        }

        public void UserReg(HttpContext context)
        {
            string user = context.Request["user"];
            string pwd = context.Request["pwd"];
            int se1 =Convert.ToInt32( context.Request["se1"]);
            string sesave = context.Request["selsave"];

            ManpBLL.UserService userService = new ManpBLL.UserService();

            int i = userService.UserReg(user, pwd, se1, sesave);

            context.Response.Write(i);
        }

        public void Userrecover(HttpContext context)
        {
            string user = context.Request["user"];
            string pwd = context.Request["pwd"];
            int se1 = Convert.ToInt32(context.Request["se1"]);
            string sesave = context.Request["selsave"];

            ManpBLL.UserService userService = new ManpBLL.UserService();

            int i= userService.Userrecover(user, pwd, se1, sesave);

            context.Response.Write(i);
        }

        public void mibaolist(HttpContext context)
        {
            ManpBLL.UserService userService = new ManpBLL.UserService();
            context.Response.Write(userService.MibaoList());
        }
    }
}