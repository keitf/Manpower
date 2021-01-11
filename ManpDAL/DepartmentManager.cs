using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ManpDAL
{
	//Department
	public partial class Department
	{

		public bool Exists(int ID)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from Department");
			strSql.Append(" where ");
			strSql.Append(" ID = @ID  ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			
			return DbHelperSQL.Exists(strSql.ToString(), parameters);
		}



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ManpowerMODEL.Department model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into Department(");
			strSql.Append("Name,PID");
			strSql.Append(") values (");
			strSql.Append("@Name,@PID");
			strSql.Append(") ");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
						new SqlParameter("@Name", SqlDbType.VarChar,255) ,
						new SqlParameter("@PID", SqlDbType.Int,4)

			};

			parameters[0].Value = model.Name;
			parameters[1].Value = model.PID;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{

				return Convert.ToInt32(obj);

			}

		}


		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ManpowerMODEL.Department model)
		{
			//UPDATE Department SET Department.Name = '修改测试' WHERE Department.ID = 7

			string strConn = "server=.;database=Manpower;uid=sa;pwd=111";

			string strSql = string.Format("UPDATE Department SET Department.Name = '{0}' WHERE Department.ID = {1}",model.Name,model.ID);

			int rows = SqlHelper.ExecuteNonQuery(strConn,CommandType.Text,strSql);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from Department ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;


			int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 批量删除一批数据
		/// </summary>
		public bool DeleteList(string IDlist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from Department ");
			strSql.Append(" where ID in (" + IDlist + ")  ");
			int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ManpowerMODEL.Department GetModel(int ID)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ID, Name, PID  ");
			strSql.Append("  from Department ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;


			ManpowerMODEL.Department model = new ManpowerMODEL.Department();
			DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

			if (ds.Tables[0].Rows.Count > 0)
			{
				if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
				{
					model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
				if (ds.Tables[0].Rows[0]["PID"].ToString() != "")
				{
					model.PID = int.Parse(ds.Tables[0].Rows[0]["PID"].ToString());
				}

				return model;
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM Department ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ");
			if (Top > 0)
			{
				strSql.Append(" top " + Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM Department ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}


	}
}
