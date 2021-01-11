using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;


namespace Manpower
{
    public partial class MenusTest : System.Web.UI.Page
    {


        //记录session防止未登陆时操作
        
        string strConn = "server=.;database=Manpower;uid=sa;pwd=111";
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            //取出菜单所有选项
            DataTable dt = SqlHelper.ExecuteDataset(strConn, CommandType.Text, "SELECT * FROM Menus").Tables[0];

            ////设置一级菜单
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][3].ToString() == "")
                {
                    sb.Append("<li class=\"layui-nav-item\">");
                    sb.Append("<a href=\"javascript:;\">" + dt.Rows[i][1].ToString() + "</a>");
                    sb.Append("<dl class=\"layui-nav-child\">");
                    //设置子级菜单
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (dt.Rows[j][3].ToString() == dt.Rows[i][0].ToString())
                        {
                            sb.Append("<dd><a href=\"" + dt.Rows[j][2].ToString() + "\">" + dt.Rows[j][1].ToString() + "</a></dd>");
                        }
                    }
                    sb.Append("</dl>");
                    sb.Append("</li>");
                }
            }

            string s = sb.ToString();

            chuizhidaohang.InnerHtml = s;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 递归加载导航
        /// </summary>
        /// <param name="i">当前id</param>
        /// <param name="dt">所有菜单集合</param>
        /// <returns></returns>
        public string MenusLsPrint(int Id, DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("<liclass=\"layui-nav-item\">");
                sb.Append("<a href=\"javascript:;\">" + dt.Rows[i][1].ToString() + "</a>");
                sb.Append("<dl class=\"layui-nav-child\">");
                if (dt.Rows[Id][3].ToString() == dt.Rows[i][0].ToString())
                {
                    sb.Append("<dd><a href=\"javascript:;\">" + dt.Rows[i][1].ToString() + "</a></dd>");
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        MenusLsPrint(j, dt);
                    }
                }
                sb.Append("</dl>");
                sb.Append("</li>");
            }
            string ss = sb.ToString();
            return ss;
        }
    }
}