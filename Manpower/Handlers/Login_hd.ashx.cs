using System;
using System.Web;

using System.Web.SessionState;

namespace Manpower.Handlers
{
    /// <summary>
    /// Login_hd 的摘要说明
    /// </summary>
    public class Login_hd : IHttpHandler, IRequiresSessionState //用于指示Http处理程序，对Session有只读的权限，也是空接口，无需实现任何方法
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["ac"].ToString();
           
            switch (action)
            {
                case "Userlogin":
                    UserLogin(context);
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
        public void UserLogin(HttpContext context)
        {
            //登录
            string name = context.Request["name"];
            string pwd = context.Request["pwd"];
            //是否记录Cookie,用于免输入登录 on/off
            string swch = context.Request["swch"];
            if (swch == "on")
            {
                
                context.Response.Cookies["cname"].Value = name;
                context.Response.Cookies["cpwd"].Value = pwd;
            }
            else
            {
                //设置过期时间 为当前天数-1，直接清除记录密码的cookie
                context.Response.Cookies["cname"].Expires = DateTime.Now.AddDays(-1);
                context.Response.Cookies["cpwd"].Expires = DateTime.Now.AddDays(-1);
            }

            //记录Cookie用于首页欢迎 ，退出时清除
            context.Response.Cookies["sname"].Value = name;
            //返回状态值
            ManpBLL.UserService user = new ManpBLL.UserService();
            //记住密码单选框值清空
            swch = null;
            context.Response.Write(user.UserLogin(name, pwd));
        }
    }
}