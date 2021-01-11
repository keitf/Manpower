using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ManpDAL
{
    //View_EmployeeSEL
    public partial class View_EmployeeSEL
    {

        public bool Exists(int ID, string Name, int DepartmentID, string Department, int Sex, DateTime Birthday, string IdCard, string Position, string Phone, string Email, string Nation, string Polity, string Degree, decimal Salary, string Resume, string Meno, string Status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from View_EmployeeSEL");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID and  ");
            strSql.Append(" Name = @Name and  ");
            strSql.Append(" DepartmentID = @DepartmentID and  ");
            strSql.Append(" Department = @Department and  ");
            strSql.Append(" Sex = @Sex and  ");
            strSql.Append(" Birthday = @Birthday and  ");
            strSql.Append(" IdCard = @IdCard and  ");
            strSql.Append(" Position = @Position and  ");
            strSql.Append(" Phone = @Phone and  ");
            strSql.Append(" Email = @Email and  ");
            strSql.Append(" Nation = @Nation and  ");
            strSql.Append(" Polity = @Polity and  ");
            strSql.Append(" Degree = @Degree and  ");
            strSql.Append(" Salary = @Salary and  ");
            strSql.Append(" Resume = @Resume and  ");
            strSql.Append(" Meno = @Meno and  ");
            strSql.Append(" Status = @Status  ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@Name", SqlDbType.VarChar,255),
                    new SqlParameter("@DepartmentID", SqlDbType.Int,4),
                    new SqlParameter("@Department", SqlDbType.VarChar,255),
                    new SqlParameter("@Sex", SqlDbType.Int,4),
                    new SqlParameter("@Birthday", SqlDbType.DateTime),
                    new SqlParameter("@IdCard", SqlDbType.VarChar,255),
                    new SqlParameter("@Position", SqlDbType.VarChar,255),
                    new SqlParameter("@Phone", SqlDbType.VarChar,255),
                    new SqlParameter("@Email", SqlDbType.VarChar,255),
                    new SqlParameter("@Nation", SqlDbType.VarChar,255),
                    new SqlParameter("@Polity", SqlDbType.VarChar,255),
                    new SqlParameter("@Degree", SqlDbType.VarChar,255),
                    new SqlParameter("@Salary", SqlDbType.Money,8),
                    new SqlParameter("@Resume", SqlDbType.VarChar,255),
                    new SqlParameter("@Meno", SqlDbType.VarChar,255),
                    new SqlParameter("@Status", SqlDbType.VarChar,255)          };
            parameters[0].Value = ID;
            parameters[1].Value = Name;
            parameters[2].Value = DepartmentID;
            parameters[3].Value = Department;
            parameters[4].Value = Sex;
            parameters[5].Value = Birthday;
            parameters[6].Value = IdCard;
            parameters[7].Value = Position;
            parameters[8].Value = Phone;
            parameters[9].Value = Email;
            parameters[10].Value = Nation;
            parameters[11].Value = Polity;
            parameters[12].Value = Degree;
            parameters[13].Value = Salary;
            parameters[14].Value = Resume;
            parameters[15].Value = Meno;
            parameters[16].Value = Status;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ManpowerMODEL.View_EmployeeSEL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into View_EmployeeSEL(");
            strSql.Append("ID,Email,Nation,Polity,Degree,Salary,Resume,Meno,Status,Name,DepartmentID,Department,Sex,Birthday,IdCard,Position,Phone");
            strSql.Append(") values (");
            strSql.Append("@ID,@Email,@Nation,@Polity,@Degree,@Salary,@Resume,@Meno,@Status,@Name,@DepartmentID,@Department,@Sex,@Birthday,@IdCard,@Position,@Phone");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ID", SqlDbType.Int,4) ,
                        new SqlParameter("@Email", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Nation", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Polity", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Degree", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Salary", SqlDbType.Money,8) ,
                        new SqlParameter("@Resume", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Meno", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Status", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Name", SqlDbType.VarChar,255) ,
                        new SqlParameter("@DepartmentID", SqlDbType.Int,4) ,
                        new SqlParameter("@Department", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Sex", SqlDbType.Int,4) ,
                        new SqlParameter("@Birthday", SqlDbType.DateTime) ,
                        new SqlParameter("@IdCard", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Position", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Phone", SqlDbType.VarChar,255)

            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.Email;
            parameters[2].Value = model.Nation;
            parameters[3].Value = model.Polity;
            parameters[4].Value = model.Degree;
            parameters[5].Value = model.Salary;
            parameters[6].Value = model.Resume;
            parameters[7].Value = model.Meno;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.Name;
            parameters[10].Value = model.DepartmentID;
            parameters[11].Value = model.Department;
            parameters[12].Value = model.Sex;
            parameters[13].Value = model.Birthday;
            parameters[14].Value = model.IdCard;
            parameters[15].Value = model.Position;
            parameters[16].Value = model.Phone;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ManpowerMODEL.View_EmployeeSEL model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update View_EmployeeSEL set ");

            strSql.Append(" ID = @ID , ");
            strSql.Append(" Email = @Email , ");
            strSql.Append(" Nation = @Nation , ");
            strSql.Append(" Polity = @Polity , ");
            strSql.Append(" Degree = @Degree , ");
            strSql.Append(" Salary = @Salary , ");
            strSql.Append(" Resume = @Resume , ");
            strSql.Append(" Meno = @Meno , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" DepartmentID = @DepartmentID , ");
            strSql.Append(" Department = @Department , ");
            strSql.Append(" Sex = @Sex , ");
            strSql.Append(" Birthday = @Birthday , ");
            strSql.Append(" IdCard = @IdCard , ");
            strSql.Append(" Position = @Position , ");
            strSql.Append(" Phone = @Phone  ");
            strSql.Append(" where ID=@ID and Name=@Name and DepartmentID=@DepartmentID and Department=@Department and Sex=@Sex and Birthday=@Birthday and IdCard=@IdCard and Position=@Position and Phone=@Phone and Email=@Email and Nation=@Nation and Polity=@Polity and Degree=@Degree and Salary=@Salary and Resume=@Resume and Meno=@Meno and Status=@Status  ");

            SqlParameter[] parameters = {
                        new SqlParameter("@ID", SqlDbType.Int,4) ,
                        new SqlParameter("@Email", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Nation", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Polity", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Degree", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Salary", SqlDbType.Money,8) ,
                        new SqlParameter("@Resume", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Meno", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Status", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Name", SqlDbType.VarChar,255) ,
                        new SqlParameter("@DepartmentID", SqlDbType.Int,4) ,
                        new SqlParameter("@Department", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Sex", SqlDbType.Int,4) ,
                        new SqlParameter("@Birthday", SqlDbType.DateTime) ,
                        new SqlParameter("@IdCard", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Position", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Phone", SqlDbType.VarChar,255)

            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.Email;
            parameters[2].Value = model.Nation;
            parameters[3].Value = model.Polity;
            parameters[4].Value = model.Degree;
            parameters[5].Value = model.Salary;
            parameters[6].Value = model.Resume;
            parameters[7].Value = model.Meno;
            parameters[8].Value = model.Status;
            parameters[9].Value = model.Name;
            parameters[10].Value = model.DepartmentID;
            parameters[11].Value = model.Department;
            parameters[12].Value = model.Sex;
            parameters[13].Value = model.Birthday;
            parameters[14].Value = model.IdCard;
            parameters[15].Value = model.Position;
            parameters[16].Value = model.Phone;
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
        public bool Delete(int ID, string Name, int DepartmentID, string Department, int Sex, DateTime Birthday, string IdCard, string Position, string Phone, string Email, string Nation, string Polity, string Degree, decimal Salary, string Resume, string Meno, string Status)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from View_EmployeeSEL ");
            strSql.Append(" where ID=@ID and Name=@Name and DepartmentID=@DepartmentID and Department=@Department and Sex=@Sex and Birthday=@Birthday and IdCard=@IdCard and Position=@Position and Phone=@Phone and Email=@Email and Nation=@Nation and Polity=@Polity and Degree=@Degree and Salary=@Salary and Resume=@Resume and Meno=@Meno and Status=@Status ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@Name", SqlDbType.VarChar,255),
                    new SqlParameter("@DepartmentID", SqlDbType.Int,4),
                    new SqlParameter("@Department", SqlDbType.VarChar,255),
                    new SqlParameter("@Sex", SqlDbType.Int,4),
                    new SqlParameter("@Birthday", SqlDbType.DateTime),
                    new SqlParameter("@IdCard", SqlDbType.VarChar,255),
                    new SqlParameter("@Position", SqlDbType.VarChar,255),
                    new SqlParameter("@Phone", SqlDbType.VarChar,255),
                    new SqlParameter("@Email", SqlDbType.VarChar,255),
                    new SqlParameter("@Nation", SqlDbType.VarChar,255),
                    new SqlParameter("@Polity", SqlDbType.VarChar,255),
                    new SqlParameter("@Degree", SqlDbType.VarChar,255),
                    new SqlParameter("@Salary", SqlDbType.Money,8),
                    new SqlParameter("@Resume", SqlDbType.VarChar,255),
                    new SqlParameter("@Meno", SqlDbType.VarChar,255),
                    new SqlParameter("@Status", SqlDbType.VarChar,255)          };
            parameters[0].Value = ID;
            parameters[1].Value = Name;
            parameters[2].Value = DepartmentID;
            parameters[3].Value = Department;
            parameters[4].Value = Sex;
            parameters[5].Value = Birthday;
            parameters[6].Value = IdCard;
            parameters[7].Value = Position;
            parameters[8].Value = Phone;
            parameters[9].Value = Email;
            parameters[10].Value = Nation;
            parameters[11].Value = Polity;
            parameters[12].Value = Degree;
            parameters[13].Value = Salary;
            parameters[14].Value = Resume;
            parameters[15].Value = Meno;
            parameters[16].Value = Status;


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
        /// 得到一个对象实体
        /// </summary>
        public ManpowerMODEL.View_EmployeeSEL GetModel(int ID, string Name, int DepartmentID, string Department, int Sex, DateTime Birthday, string IdCard, string Position, string Phone, string Email, string Nation, string Polity, string Degree, decimal Salary, string Resume, string Meno, string Status)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, Email, Nation, Polity, Degree, Salary, Resume, Meno, Status, Name, DepartmentID, Department, Sex, Birthday, IdCard, Position, Phone  ");
            strSql.Append("  from View_EmployeeSEL ");
            strSql.Append(" where ID=@ID and Name=@Name and DepartmentID=@DepartmentID and Department=@Department and Sex=@Sex and Birthday=@Birthday and IdCard=@IdCard and Position=@Position and Phone=@Phone and Email=@Email and Nation=@Nation and Polity=@Polity and Degree=@Degree and Salary=@Salary and Resume=@Resume and Meno=@Meno and Status=@Status ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@Name", SqlDbType.VarChar,255),
                    new SqlParameter("@DepartmentID", SqlDbType.Int,4),
                    new SqlParameter("@Department", SqlDbType.VarChar,255),
                    new SqlParameter("@Sex", SqlDbType.Int,4),
                    new SqlParameter("@Birthday", SqlDbType.DateTime),
                    new SqlParameter("@IdCard", SqlDbType.VarChar,255),
                    new SqlParameter("@Position", SqlDbType.VarChar,255),
                    new SqlParameter("@Phone", SqlDbType.VarChar,255),
                    new SqlParameter("@Email", SqlDbType.VarChar,255),
                    new SqlParameter("@Nation", SqlDbType.VarChar,255),
                    new SqlParameter("@Polity", SqlDbType.VarChar,255),
                    new SqlParameter("@Degree", SqlDbType.VarChar,255),
                    new SqlParameter("@Salary", SqlDbType.Money,8),
                    new SqlParameter("@Resume", SqlDbType.VarChar,255),
                    new SqlParameter("@Meno", SqlDbType.VarChar,255),
                    new SqlParameter("@Status", SqlDbType.VarChar,255)          };
            parameters[0].Value = ID;
            parameters[1].Value = Name;
            parameters[2].Value = DepartmentID;
            parameters[3].Value = Department;
            parameters[4].Value = Sex;
            parameters[5].Value = Birthday;
            parameters[6].Value = IdCard;
            parameters[7].Value = Position;
            parameters[8].Value = Phone;
            parameters[9].Value = Email;
            parameters[10].Value = Nation;
            parameters[11].Value = Polity;
            parameters[12].Value = Degree;
            parameters[13].Value = Salary;
            parameters[14].Value = Resume;
            parameters[15].Value = Meno;
            parameters[16].Value = Status;


            ManpowerMODEL.View_EmployeeSEL model = new ManpowerMODEL.View_EmployeeSEL();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Nation = ds.Tables[0].Rows[0]["Nation"].ToString();
                model.Polity = ds.Tables[0].Rows[0]["Polity"].ToString();
                model.Degree = ds.Tables[0].Rows[0]["Degree"].ToString();
                if (ds.Tables[0].Rows[0]["Salary"].ToString() != "")
                {
                    model.Salary = decimal.Parse(ds.Tables[0].Rows[0]["Salary"].ToString());
                }
                model.Resume = ds.Tables[0].Rows[0]["Resume"].ToString();
                model.Meno = ds.Tables[0].Rows[0]["Meno"].ToString();
                model.Status =Convert.ToInt32( ds.Tables[0].Rows[0]["Status"]);
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["DepartmentID"].ToString() != "")
                {
                    model.DepartmentID = int.Parse(ds.Tables[0].Rows[0]["DepartmentID"].ToString());
                }
                model.Department = ds.Tables[0].Rows[0]["Department"].ToString();
                if (ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(ds.Tables[0].Rows[0]["Birthday"].ToString());
                }
                model.IdCard = ds.Tables[0].Rows[0]["IdCard"].ToString();
                model.Position = ds.Tables[0].Rows[0]["Position"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();

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
            strSql.Append(" FROM View_EmployeeSEL ");
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
            strSql.Append(" FROM View_EmployeeSEL ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}
