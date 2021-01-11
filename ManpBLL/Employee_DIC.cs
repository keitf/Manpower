using System;
using System.Text;
using System.Collections.Generic;
using System.Data;

namespace ManpBLL
{
    //Employee_DIC
    public partial class Employee_DIC
    {

        private readonly ManpDAL.Employee_DIC dal = new ManpDAL.Employee_DIC();
        public Employee_DIC()
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
        public int Add(ManpowerMODEL.Employee_DIC model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ManpowerMODEL.Employee_DIC model)
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
        public ManpowerMODEL.Employee_DIC GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        ///// <summary>
        ///// 得到一个对象实体，从缓存中
        ///// </summary>
        //public ManpowerMODEL.Employee_DIC GetModelByCache(int ID)
        //{

        //	string CacheKey = "Employee_DICModel-" + ID;
        //	object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
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
        //	return (Maticsoft.Model.Employee_DIC)objModel;
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
        public List<ManpowerMODEL.Employee_DIC> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ManpowerMODEL.Employee_DIC> DataTableToList(DataTable dt)
        {
            List<ManpowerMODEL.Employee_DIC> modelList = new List<ManpowerMODEL.Employee_DIC>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                ManpowerMODEL.Employee_DIC model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new ManpowerMODEL.Employee_DIC();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.Name = dt.Rows[n]["Name"].ToString();
                    if (dt.Rows[n]["PID"].ToString() != "")
                    {
                        model.PID = int.Parse(dt.Rows[n]["PID"].ToString());
                    }


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