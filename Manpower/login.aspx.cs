using System;

namespace Manpower
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //当两个Cookie同时存在时将会赋值
            if (Request.Cookies["cname"] != null && Request.Cookies["cpwd"] != null)
            {
                name.Value = Request.Cookies["cname"].Value;

                string pwdw = Request.Cookies["cpwd"].Value;
                //给密码框赋值
                pwd.Attributes.Add("value", pwdw);
            }
            //测试用
            pwd.Attributes.Add("value", "123123");
        }
    }
}