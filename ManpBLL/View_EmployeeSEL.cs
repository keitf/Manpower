using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ManpBLL
{
    //View_EmployeeSEL
    public partial class View_EmployeeSEL
    {

        private readonly ManpDAL.View_EmployeeSEL dal = new ManpDAL.View_EmployeeSEL();
        public View_EmployeeSEL()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID, string Name, int DepartmentID, string Department, int Sex, DateTime Birthday, string IdCard, string Position, string Phone, string Email, string Nation, string Polity, string Degree, decimal Salary, string Resume, string Meno, string Status)
        {
            return dal.Exists(ID, Name, DepartmentID, Department, Sex, Birthday, IdCard, Position, Phone, Email, Nation, Polity, Degree, Salary, Resume, Meno, Status);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(ManpowerMODEL.View_EmployeeSEL model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ManpowerMODEL.View_EmployeeSEL model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID, string Name, int DepartmentID, string Department, int Sex, DateTime Birthday, string IdCard, string Position, string Phone, string Email, string Nation, string Polity, string Degree, decimal Salary, string Resume, string Meno, string Status)
        {

            return dal.Delete(ID, Name, DepartmentID, Department, Sex, Birthday, IdCard, Position, Phone, Email, Nation, Polity, Degree, Salary, Resume, Meno, Status);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ManpowerMODEL.View_EmployeeSEL GetModel(int ID, string Name, int DepartmentID, string Department, int Sex, DateTime Birthday, string IdCard, string Position, string Phone, string Email, string Nation, string Polity, string Degree, decimal Salary, string Resume, string Meno, string Status)
        {

            return dal.GetModel(ID, Name, DepartmentID, Department, Sex, Birthday, IdCard, Position, Phone, Email, Nation, Polity, Degree, Salary, Resume, Meno, Status);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public ManpowerMODEL.View_EmployeeSEL GetModelByCache(int ID, string Name, int DepartmentID, string Department, int Sex, DateTime Birthday, string IdCard, string Position, string Phone, string Email, string Nation, string Polity, string Degree, decimal Salary, string Resume, string Meno, string Status)
        //{

        //    string CacheKey = "View_EmployeeSELModel-" + ID + Name + DepartmentID + Department + Sex + Birthday + IdCard + Position + Phone + Email + Nation + Polity + Degree + Salary + Resume + Meno + Status;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(ID, Name, DepartmentID, Department, Sex, Birthday, IdCard, Position, Phone, Email, Nation, Polity, Degree, Salary, Resume, Meno, Status);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (ManpowerMODEL.View_EmployeeSEL)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ManpowerMODEL.View_EmployeeSEL> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ManpowerMODEL.View_EmployeeSEL> DataTableToList(DataTable dt)
        {
            List<ManpowerMODEL.View_EmployeeSEL> modelList = new List<ManpowerMODEL.View_EmployeeSEL>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ManpowerMODEL.View_EmployeeSEL model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ManpowerMODEL.View_EmployeeSEL();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.Email = dt.Rows[n]["Email"].ToString();
                    model.Nation = dt.Rows[n]["Nation"].ToString();
                    model.Polity = dt.Rows[n]["Polity"].ToString();
                    model.Degree = dt.Rows[n]["Degree"].ToString();
                    if (dt.Rows[n]["Salary"].ToString() != "")
                    {
                        model.Salary = decimal.Parse(dt.Rows[n]["Salary"].ToString());
                    }
                    model.Resume = dt.Rows[n]["Resume"].ToString();
                    model.Meno = dt.Rows[n]["Meno"].ToString();
                    model.Status =Convert.ToInt32(dt.Rows[n]["Status"]);
                    model.Name = dt.Rows[n]["Name"].ToString();
                    if (dt.Rows[n]["DepartmentID"].ToString() != "")
                    {
                        model.DepartmentID = int.Parse(dt.Rows[n]["DepartmentID"].ToString());
                    }
                    model.Department = dt.Rows[n]["Department"].ToString();
                    if (dt.Rows[n]["Sex"].ToString() != "")
                    {
                        model.Sex = int.Parse(dt.Rows[n]["Sex"].ToString());
                    }
                    if (dt.Rows[n]["Birthday"].ToString() != "")
                    {
                        model.Birthday = DateTime.Parse(dt.Rows[n]["Birthday"].ToString());
                    }
                    model.IdCard = dt.Rows[n]["IdCard"].ToString();
                    model.Position = dt.Rows[n]["Position"].ToString();
                    model.Phone = dt.Rows[n]["Phone"].ToString();


                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        #endregion

    }
}
