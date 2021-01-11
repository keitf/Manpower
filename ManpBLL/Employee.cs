using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace ManpBLL
{
    //Employee
    public partial class Employee
    {

        private readonly ManpDAL.Employee dal = new ManpDAL.Employee();
        public Employee()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ManpowerMODEL.Employee model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ManpowerMODEL.Employee model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ManpowerMODEL.Employee GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public ManpowerMODEL.Employee GetModelByCache(int ID)
        //{

        //	string CacheKey = "EmployeeModel-" + ID;
        //	object objModel = ManpDAL.Common.DataCache.GetCache(CacheKey);
        //	if (objModel == null)
        //	{
        //		try
        //		{
        //			objModel = dal.GetModel(ID);
        //			if (objModel != null)
        //			{
        //				int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //				Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //			}
        //		}
        //		catch{}
        //	}
        //	return (Maticsoft.Model.Employee)objModel;
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
        public List<ManpowerMODEL.Employee> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ManpowerMODEL.Employee> DataTableToList(DataTable dt)
        {
            List<ManpowerMODEL.Employee> modelList = new List<ManpowerMODEL.Employee>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ManpowerMODEL.Employee model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ManpowerMODEL.Employee();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["DepartmentID"].ToString() != "")
                    {
                        model.DepartmentID = int.Parse(dt.Rows[n]["DepartmentID"].ToString());
                    }
                    model.Name = dt.Rows[n]["Name"].ToString();
                    model.Sex = Convert.ToInt32( dt.Rows[n]["Sex"]);
                    if (dt.Rows[n]["Birthday"].ToString() != "")
                    {
                        model.Birthday = DateTime.Parse(dt.Rows[n]["Birthday"].ToString());
                    }
                    model.IdCard = dt.Rows[n]["IdCard"].ToString();
                    model.Position = Convert.ToInt32( dt.Rows[n]["Position"]);
                    model.Phone = dt.Rows[n]["Phone"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    model.Nation = Convert.ToInt32(dt.Rows[n]["Nation"]);
                    model.Polity = Convert.ToInt32( dt.Rows[n]["Polity"]);
                    model.Degree = Convert.ToInt32( dt.Rows[n]["Degree"]);
                    if (dt.Rows[n]["Salary"].ToString() != "")
                    {
                        model.Salary = decimal.Parse(dt.Rows[n]["Salary"].ToString());
                    }
                    model.Resume = dt.Rows[n]["Resume"].ToString();
                    if (dt.Rows[n]["Meno"].ToString() != "")
                    {
                        model.Meno = dt.Rows[n]["Meno"].ToString();
                    }
                    model.Status = dt.Rows[n]["Status"].ToString();


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

        public int EmpDel(string id)
        {
            return dal.EmpDel(id);
        }

    }
}