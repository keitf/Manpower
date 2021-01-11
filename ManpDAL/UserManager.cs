using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ManpDAL
{
    public class UserManager
    {
        string strConn = "server=.;database=Manpower;uid=sa;pwd=111";

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns>登录状态</returns>
        public int UserLonin(string name, string pwd)
        {
            string strSql = "p_Login '" + name + "', '" + pwd + "'";

            DataTable dt = SqlHelper.ExecuteDataset(strConn, CommandType.Text, strSql).Tables[0];

            return Convert.ToInt32( dt.Rows[0][0]);
        }

        /// <summary>
        /// 表格Json数据转换
        /// </summary>
        /// <param name="account">模糊查询用户名</param>
        /// <param name="id">模糊查询ID</param>
        /// <param name="rid">模糊查询角色</param>
        /// <param name="page">页数</param>
        /// <param name="limit">每页的行数</param>
        /// <returns>UserEditJson数据</returns>
        /// ,string id,string account,string rolename
        public string UserJosnEdit(int page, int limit, string id, string account, string rid)
        {

            string strSql = "SELECT row_number() OVER (ORDER BY ID) AS RowID,* FROM View_UserEdit WHERE IsActive ='1'";
            //查询User
            DataTable dt = SqlHelper.ExecuteDataset(strConn, CommandType.Text, strSql).Tables[0];
            //生成jsonDate实体集合
            List<ManpowerMODEL.UserJsonEdit.JsonData> jsonDatas = new List<ManpowerMODEL.UserJsonEdit.JsonData>();

            //datateble 转 list
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ManpowerMODEL.UserJsonEdit.JsonData json = new ManpowerMODEL.UserJsonEdit.JsonData()
                    {
                        RowID = Convert.ToInt32(dt.Rows[i][0]),
                        ID = dt.Rows[i][1].ToString(),
                        Account = dt.Rows[i][2].ToString(),
                        CreatDate = dt.Rows[i][6].ToString(),
                        IsActive = dt.Rows[i][4].ToString(),
                        Password = dt.Rows[i][3].ToString(),
                        Name = dt.Rows[i][5].ToString(),
                        RID = dt.Rows[i][7].ToString()
                    };
                    jsonDatas.Add(json);
                }
            }

            //分页
            //第一行数据的索引 
            int fpageindex = ((page - 1) * limit) + 1;
            //最后一行的数据的索引
            int epageindex = page * limit;
            //查询总行数用于数据分页
            int count = 0;

            ////Linq 表达式查询
            //查询条件都为空时   查询所有
            if (string.IsNullOrEmpty(rid) && string.IsNullOrEmpty(account) && string.IsNullOrEmpty(id) && rid != "0")
            {
                //Linq 表达式查询
                jsonDatas = (from vs in jsonDatas where vs.RowID >= fpageindex && vs.RowID <= epageindex select vs).ToList();
                //查询全部时 总行数为所有数据
                count = dt.Rows.Count;
            }
            //条件查询
            else
            {
                //当角色id为0时设为空防止干扰查询
                if (rid == "0")
                {
                    rid = "";
                }
                //条件查询
                jsonDatas = (from v in jsonDatas where v.RID.Contains(rid) && v.Account.Contains(account) && v.ID.Contains(id) select v).ToList();
                count = jsonDatas.Count;
            }

            //为生成Json拼接实体类
            ManpowerMODEL.UserJsonEdit.JsonRoot jsonRoot = new ManpowerMODEL.UserJsonEdit.JsonRoot()
            {
                code = 0,
                msg = "",
                count = count,
                data = jsonDatas
            };

            //list转Json  方便查看调试
            string StrJson = JsonConvert.SerializeObject(jsonRoot);

            return StrJson;
        }

        public string UserSelOptin()
        {
            StringBuilder sb = new StringBuilder();

            string strSql = "SELECT * FROM Role";

            DataTable dt = SqlHelper.ExecuteDataset(strConn, CommandType.Text, strSql).Tables[0];

            if (dt.Rows.Count > 0)
            {
                sb.Append("<option value=\"0\">不限</option>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<option value=\"" + dt.Rows[i][0].ToString() + "\">" + dt.Rows[i][1].ToString() + "</option>");
                }
            }
            string s = sb.ToString();
            return sb.ToString();
        }

        public int UserSelDel(string allid)
        {
            string strSql = "UPDATE Users SET IsActive = '0' WHERE Users.ID IN(" + allid + ")";

            int result = SqlHelper.ExecuteNonQuery(strConn, CommandType.Text, strSql);

            return Convert.ToBoolean(result) ? 1 : 0;
        }

        public int UserEdit(ManpowerMODEL.UserAddEditInfo user)
        {
            string strSql = string.Format("UPDATE [dbo].[Users] SET [Account] = '{0}', [Password] = '{1}', [RoleID] = {2}," +
                " [IsActive] = '{3}', [CreateDate] = '{4}' WHERE [ID] = {5};", user.username, user.repwd, user.interest, 1, DateTime.Now, user.id);
            int result = SqlHelper.ExecuteNonQuery(strConn, CommandType.Text, strSql);

            return Convert.ToBoolean(result) ? 1 : 0;
        }

        public int UserAdd(ManpowerMODEL.UserAddEditInfo user)
        {
            string strSql = string.Format("INSERT INTO [dbo].[Users]([Account], [Password]," +
                " [RoleID], [IsActive]) VALUES ('{0}', '{1}', '{2}', '{3}');", user.username, user.repwd, user.interest, 1);

            int result = SqlHelper.ExecuteNonQuery(strConn, CommandType.Text, strSql);

            return Convert.ToBoolean(result) ? 2 : 0;
        }


        public string Repwd(string npwd,int id,string lpwd)
        {
            string strSql = "p_Repwd '" + npwd + "'," + id + ",'" + lpwd + "'";

            return SqlHelper.ExecuteScalar(strConn, CommandType.Text, strSql).ToString();
        }

        ////暂停使用
        ///
        /// 
        ///// <summary>
        ///// DataTable转化为List集合
        ///// </summary>
        ///// <typeparam name="T">实体对象</typeparam>
        ///// <param name="dt">datatable表</param>
        ///// <param name="isStoreDB">是否存入数据库datetime字段，date字段没事，取出不用判断</param>
        ///// <returns>返回list集合</returns>
        //public static List<T> TableToList<T>(DataTable dt, bool isStoreDB = true)
        //{
        //    List<T> list = new List<T>();
        //    Type type = typeof(T);
        //    //List<string> listColums = new List<string>();
        //    PropertyInfo[] pArray = type.GetProperties(); //集合属性数组
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        T entity = Activator.CreateInstance<T>(); //新建对象实例 
        //        foreach (PropertyInfo p in pArray)
        //        {
        //            if (!dt.Columns.Contains(p.Name) || row[p.Name] == null || row[p.Name] == DBNull.Value)
        //            {
        //                continue;  //DataTable列中不存在集合属性或者字段内容为空则，跳出循环，进行下个循环   
        //            }
        //            if (isStoreDB && p.PropertyType == typeof(DateTime) && Convert.ToDateTime(row[p.Name]) < Convert.ToDateTime("1753-01-01"))
        //            {
        //                continue;
        //            }
        //            try
        //            {
        //                var obj = Convert.ChangeType(row[p.Name], p.PropertyType);//类型强转，将table字段类型转为集合字段类型  
        //                p.SetValue(entity, obj, null);
        //            }
        //            catch (Exception)
        //            {
        //                // throw;
        //            }
        //            //if (row[p.Name].GetType() == p.PropertyType)
        //            //{
        //            //    p.SetValue(entity, row[p.Name], null); //如果不考虑类型异常，foreach下面只要这一句就行
        //            //}                    
        //            //object obj = null;
        //            //if (ConvertType(row[p.Name], p.PropertyType,isStoreDB, out obj))
        //            //{                                        
        //            //    p.SetValue(entity, obj, null);
        //            //}                
        //        }
        //        list.Add(entity);
        //    }
        //    return list;
        //}


        //public static class ModelConvertHelper<T> where T : new()
        //{
        //    public static List<T> ConvertToModel(DataTable dt)
        //    {
        //        // 定义的集合    
        //        List<T> ts = new List<T>();


        //        // 获得此模型的类型   
        //        Type type = typeof(T);
        //        string tempName = "";


        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            T t = new T();
        //            // 获得此模型的公共属性      
        //            PropertyInfo[] propertys = t.GetType().GetProperties();
        //            foreach (PropertyInfo pi in propertys)
        //            {
        //                tempName = pi.Name;  // 检查DataTable是否包含此列    


        //                if (dt.Columns.Contains(tempName))
        //                {
        //                    // 判断此属性是否有Setter      
        //                    if (!pi.CanWrite) continue;


        //                    object value = dr[tempName];
        //                    if (value != DBNull.Value)
        //                        pi.SetValue(t, value, null);
        //                }
        //            }
        //            ts.Add(t);
        //        }
        //        return ts;
        //    }
        //}


        //public class DtConverToList<T> where T : new()
        //{
        //    public static List<T> DtToList(DataTable dt)
        //    {
        //        //定义集合
        //        List<T> ListCollection = new List<T>(dt.Rows.Count);
        //        //获得 T 模型类型
        //        Type T_type = typeof(T);
        //        //获得 T 模型类型公共属性
        //        PropertyInfo[] Proper = T_type.GetProperties();
        //        //临时变量，存储变量模型公共属性Name
        //        string Tempname = "";
        //        //遍历参数 DataTable的每行
        //        foreach (DataRow Dr in dt.Rows)
        //        {
        //            //实例化 T 模版类
        //            T t = new T();
        //            //遍历T 模版类各个属性
        //            #region
        //            foreach (PropertyInfo P in Proper)
        //            {
        //                //取出类属性之一
        //                Tempname = P.Name;
        //                //判断DataTable中是否有此列
        //                if (dt.Columns.Contains(Tempname))
        //                {
        //                    //判断属性是否可写属性
        //                    if (!P.CanWrite)
        //                    {
        //                        continue;
        //                    }
        //                    try
        //                    {
        //                        //得到Datable单元格中的值
        //                        object value = Dr[Tempname];
        //                        //得到 T 属性类型
        //                        Type ProType = P.PropertyType;
        //                        //判断类型赋值
        //                        if (value != DBNull.Value)
        //                        {
        //                            //
        //                            if (value.GetType() == ProType)
        //                            {
        //                                P.SetValue(t, value, null);
        //                            }
        //                            else
        //                            {
        //                                if (ProType == typeof(string))
        //                                {
        //                                    string Temp = value.ToString();
        //                                    P.SetValue(t, Temp, null);
        //                                }
        //                                else if (ProType == typeof(byte))
        //                                {
        //                                    byte Temp = Convert.ToByte(value);
        //                                    P.SetValue(t, Temp, null);
        //                                }
        //                                else if (ProType == typeof(short))
        //                                {
        //                                    short Temp = short.Parse(value.ToString());
        //                                    P.SetValue(t, Temp, null);
        //                                }
        //                                else if (ProType == typeof(long))
        //                                {
        //                                    long Temp = long.Parse(value.ToString());
        //                                    P.SetValue(t, Temp, null);
        //                                }

        //                                else if (ProType == typeof(Int64))
        //                                {
        //                                    Int64 Temp = Convert.ToInt64(value);
        //                                    P.SetValue(t, Temp, null);
        //                                }
        //                                else if (ProType == typeof(Int32))
        //                                {
        //                                    Int32 Temp = Convert.ToInt32(value);
        //                                    P.SetValue(t, Temp, null);
        //                                }
        //                                else if (ProType == typeof(Int16))
        //                                {
        //                                    Int16 Temp = Convert.ToInt16(value);
        //                                    P.SetValue(t, Temp, null);
        //                                }
        //                                else
        //                                {
        //                                    object Temp = Convert.ChangeType(value, ProType);
        //                                    P.SetValue(t, Temp, null);
        //                                }
        //                            }
        //                        }
        //                    }
        //                    catch (Exception)
        //                    {

        //                        throw;
        //                    }
        //                }
        //            }
        //            #endregion
        //            ListCollection.Add(t);
        //        }
        //        return ListCollection;
        //    }
        //}

    }
}
