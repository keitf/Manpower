using ManpowerMODEL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ManpDAL
{
    public class RoleManager
    {
        string strConn = "server=.;database=Manpower;uid=sa;pwd=111";

        //查询角色
        public string RoleSel()
        {
            string strSql = "SELECT * FROM Role";

            DataTable dt = SqlHelper.ExecuteDataset(strConn, CommandType.Text, strSql).Tables[0];
            List<RoleJsonEdit.JsonData> lsrole = new List<RoleJsonEdit.JsonData>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    RoleJsonEdit.JsonData role = new RoleJsonEdit.JsonData()
                    {
                        ID = Convert.ToInt32(dt.Rows[i][0]),
                        Name = dt.Rows[i][1].ToString(),
                        CreateDate = (dt.Rows[i][4]).ToString(),
                        Content = dt.Rows[i][2].ToString(),
                        Expower = dt.Rows[i][3].ToString()
                    };
                    lsrole.Add(role);
                }
            }
            RoleJsonEdit.JsonRoot jsonRoot = new RoleJsonEdit.JsonRoot()
            {
                code = 0,
                msg = "",
                count = dt.Rows.Count,
                data = lsrole
            };
            string Strjson = JsonConvert.SerializeObject(jsonRoot);
            return Strjson;
        }

        //add
        public int AddRole(string name, string content, string Expower)
        {
            string strSql = string.Format("INSERT INTO [dbo].[Role]([Name], [Content], [Expower]) VALUES ('{0}', '{1}', '{2}');", name, content, Expower);

            return Convert.ToBoolean(SqlHelper.ExecuteNonQuery(strConn, CommandType.Text, strSql)) ? 2 : 0;
        }
        public int Edit(string id, string name, string content, string Expower)
        {
            string strSql = string.Format("UPDATE [dbo].[Role] SET [Name] = '{0}', [Content] = '{1}', [Expower] = '{2}' WHERE [ID] = {3};", name, content, Expower, id);
            return Convert.ToBoolean(SqlHelper.ExecuteNonQuery(strConn, CommandType.Text, strSql)) ? 1 : 0;
        }

        public string RoleMenu()
        {            
            string strSql = "SELECT * FROM [dbo].[Menus]";
            DataTable dt = SqlHelper.ExecuteDataset(strConn, CommandType.Text, strSql).Tables[0];
            //父级菜单集合       将转为json 
            List<RoleJsonEdit.Root> lsroleroot = new List<RoleJsonEdit.Root>();
            //子菜单集合 为父级菜单添加  【使用后清空】
            List<RoleJsonEdit.ChildrenItem> childrens = new List<RoleJsonEdit.ChildrenItem>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //添加父级菜单前 先添加子级菜单集合
                    if (dt.Rows[i][3].ToString() == "")
                    {
                        //添加子级菜单
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (dt.Rows[i][0].ToString() == dt.Rows[j][3].ToString())
                            {
                                RoleJsonEdit.ChildrenItem children = new RoleJsonEdit.ChildrenItem()
                                {
                                    id = Convert.ToInt32(dt.Rows[j][0]),
                                    title = dt.Rows[j][1].ToString()
                                };
                                childrens.Add(children);
                            }
                        }
                        //添加父级菜单
                        RoleJsonEdit.Root root = new RoleJsonEdit.Root()
                        {
                            id = Convert.ToInt32(dt.Rows[i][0]),
                            title = dt.Rows[i][1].ToString(),
                            children = childrens
                        };
                        lsroleroot.Add(root);
                        //清空子级菜单list 防止添加上一级的子菜单
                        childrens = new List<RoleJsonEdit.ChildrenItem>();
                    }
                }
            }
            string strJson = JsonConvert.SerializeObject(lsroleroot);
            return strJson;
        }
        public int RoleDel(string arrid)
        {
            string strSql =string.Format( "DELETE Role WHERE ID IN({0});",arrid);

            return (Convert.ToBoolean(SqlHelper.ExecuteNonQuery(strConn, CommandType.Text, strSql))) ? 1 : 0;      
        }
    }
}
