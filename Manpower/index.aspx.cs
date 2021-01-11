using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Manpower
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //检查cookie防止 未登陆操作
            if (Request.Cookies["userroleid"] == null)
            {
                Response.Write("<script>alert('未登陆！无法操作系统！');</script>");                
            }
            else
            {

                string strConn = "server=.;database=Manpower;uid=sa;pwd=111";
                //欢迎
                welname.InnerText = Request.Cookies["sname"].Value;

                // 查询菜单                
                //【1.获取用户id】
                string id = Request.Cookies["userroleid"].Value;
                //【1.1根据id查询用户所属权限id】
                string strSql0 = string.Format("SELECT Users.RoleID FROM Users WHERE Users.ID ={0};",id);
                string userroleid = SqlHelper.ExecuteScalar(strConn, CommandType.Text, strSql0).ToString();
                //【2.根据权限id查询所属权限id集合】
                string strSql = string.Format("SELECT Expower FROM Role WHERE Role.ID ={0};", userroleid);
                //【3.所有权限集合】
                string s = SqlHelper.ExecuteScalar(strConn, CommandType.Text, strSql).ToString();
                //【4.集合所对应的菜单】
                string strSql1 = string.Format("SELECT * FROM Menus WHERE ID IN ({0});", s);
                //【5.菜单集合】
                DataTable dt = SqlHelper.ExecuteDataset(strConn, CommandType.Text, strSql1).Tables[0];


                StringBuilder sb = new StringBuilder();
                //取出菜单所有选项
                //DataTable dt = SqlHelper.ExecuteDataset(strConn, CommandType.Text, "SELECT * FROM Menus").Tables[0];

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

                string sinfo = sb.ToString();

                chuizhidaohang.InnerHtml = sinfo;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}