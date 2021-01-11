using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using ManpowerMODEL;
namespace ManpDAL
{
    //Employee
    public partial class Employee
    {

        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Employee");
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
        public int Add(ManpowerMODEL.Employee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Employee(");
            strSql.Append("DepartmentID,Name,Sex,Birthday,IdCard,Position,Phone,Email,Nation,Polity,Degree,Salary,Resume,Meno,Status");
            strSql.Append(") values (");
            strSql.Append("@DepartmentID,@Name,@Sex,@Birthday,@IdCard,@Position,@Phone,@Email,@Nation,@Polity,@Degree,@Salary,@Resume,@Meno,@Status");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@DepartmentID", SqlDbType.Int,4) ,
                        new SqlParameter("@Name", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Sex", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Birthday", SqlDbType.DateTime) ,
                        new SqlParameter("@IdCard", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Position", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Phone", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Email", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Nation", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Polity", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Degree", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Salary", SqlDbType.Money,8) ,
                        new SqlParameter("@Resume", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Meno", SqlDbType.Int,4) ,
                        new SqlParameter("@Status", SqlDbType.VarChar,255)

            };

            parameters[0].Value = model.DepartmentID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Birthday;
            parameters[4].Value = model.IdCard;
            parameters[5].Value = model.Position;
            parameters[6].Value = model.Phone;
            parameters[7].Value = model.Email;
            parameters[8].Value = model.Nation;
            parameters[9].Value = model.Polity;
            parameters[10].Value = model.Degree;
            parameters[11].Value = model.Salary;
            parameters[12].Value = model.Resume;
            parameters[13].Value = model.Meno;
            parameters[14].Value = model.Status;

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
        public bool Update(ManpowerMODEL.Employee model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Employee set ");

            strSql.Append(" DepartmentID = @DepartmentID , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" Sex = @Sex , ");
            strSql.Append(" Birthday = @Birthday , ");
            strSql.Append(" IdCard = @IdCard , ");
            strSql.Append(" Position = @Position , ");
            strSql.Append(" Phone = @Phone , ");
            strSql.Append(" Email = @Email , ");
            strSql.Append(" Nation = @Nation , ");
            strSql.Append(" Polity = @Polity , ");
            strSql.Append(" Degree = @Degree , ");
            strSql.Append(" Salary = @Salary , ");
            strSql.Append(" Resume = @Resume , ");
            strSql.Append(" Meno = @Meno , ");
            strSql.Append(" Status = @Status  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ID", SqlDbType.Int,4) ,
                        new SqlParameter("@DepartmentID", SqlDbType.Int,4) ,
                        new SqlParameter("@Name", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Sex", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Birthday", SqlDbType.DateTime) ,
                        new SqlParameter("@IdCard", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Position", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Phone", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Email", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Nation", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Polity", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Degree", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Salary", SqlDbType.Money,8) ,
                        new SqlParameter("@Resume", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Meno", SqlDbType.Int,4) ,
                        new SqlParameter("@Status", SqlDbType.VarChar,255)

            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.DepartmentID;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Birthday;
            parameters[5].Value = model.IdCard;
            parameters[6].Value = model.Position;
            parameters[7].Value = model.Phone;
            parameters[8].Value = model.Email;
            parameters[9].Value = model.Nation;
            parameters[10].Value = model.Polity;
            parameters[11].Value = model.Degree;
            parameters[12].Value = model.Salary;
            parameters[13].Value = model.Resume;
            parameters[14].Value = model.Meno;
            parameters[15].Value = model.Status;
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Employee ");
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
            strSql.Append("delete from Employee ");
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
        public ManpowerMODEL.Employee GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, DepartmentID, Name, Sex, Birthday, IdCard, Position, Phone, Email, Nation, Polity, Degree, Salary, Resume, Meno, Status  ");
            strSql.Append("  from Employee ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)
            };
            parameters[0].Value = ID;


            ManpowerMODEL.Employee model = new ManpowerMODEL.Employee();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DepartmentID"].ToString() != "")
                {
                    model.DepartmentID = int.Parse(ds.Tables[0].Rows[0]["DepartmentID"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Sex = Convert.ToInt32( ds.Tables[0].Rows[0]["Sex"]);
                if (ds.Tables[0].Rows[0]["Birthday"].ToString() != "")
                {
                    model.Birthday = (DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString()));
                }
                model.IdCard = ds.Tables[0].Rows[0]["IdCard"].ToString();
                model.Position = Convert.ToInt32( ds.Tables[0].Rows[0]["Position"]);
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Nation = Convert.ToInt32( ds.Tables[0].Rows[0]["Nation"]);
                model.Polity = Convert.ToInt32( ds.Tables[0].Rows[0]["Polity"]);
                model.Degree = Convert.ToInt32( ds.Tables[0].Rows[0]["Degree"]);
                if (ds.Tables[0].Rows[0]["Salary"].ToString() != "")
                {
                    model.Salary = decimal.Parse(ds.Tables[0].Rows[0]["Salary"].ToString());
                }
                model.Resume = ds.Tables[0].Rows[0]["Resume"].ToString();
                if (ds.Tables[0].Rows[0]["Meno"].ToString() != "")
                {
                    model.Meno =  ds.Tables[0].Rows[0]["Meno"].ToString();
                }
                model.Status = ds.Tables[0].Rows[0]["Status"].ToString();

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
            strSql.Append(" FROM Employee ");
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
            strSql.Append(" FROM Employee ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        public int EmpDel(string id)
        {
            int i = 0;

            string strSql = string.Format("UPDATE Employee SET Employee.Status = 0 WHERE Employee.ID = {0}",id);

            i = SqlHelper.ExecuteNonQuery(DbHelperSQL.connectionString, CommandType.Text, strSql);

            return i;
        }


    }
}

