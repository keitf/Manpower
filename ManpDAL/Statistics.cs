using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;

namespace ManpDAL
{
    public class Statistics
    {
        /// <summary>
        /// 性别统计
        /// </summary>
        /// <returns></returns>
        public string SexStatis()
        {
            StringBuilder sb = new StringBuilder();

            string strSql = "SELECT Employee.Sex AS '性别' ,COUNT(*) AS '人数' FROM Employee GROUP BY Employee.Sex";

            DataTable dt = SqlHelper.ExecuteDataset(DbHelperSQL.connectionString, CommandType.Text, strSql).Tables[0];

            List<DegreeS> degreeS = new List<DegreeS>();

            if (dt.Rows.Count>0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DegreeS degree = new DegreeS();
                    if (dt.Rows[i][0].ToString() == "0")
                    {
                        degree.name = "女";
                    }
                    else
                    {
                        degree.name = "男";
                    }
                    degree.value = Convert.ToInt32(dt.Rows[i][1]);
                    degreeS.Add(degree);
                }
            }

            string s = JsonConvert.SerializeObject(degreeS);

            return s;

        }

        /// <summary>
        /// 【部门.学历】返回数据
        /// </summary>
        /// <param name="viewnaem">视图名</param>
        /// <returns>Json</returns>
        public string EchartsData(string viewnaem)
        {
            string strSql =string.Format( "SELECT * FROM {0}",viewnaem);

            DataTable dt = SqlHelper.ExecuteDataset(DbHelperSQL.connectionString, CommandType.Text, strSql).Tables[0];

            List<DegreeS> degreeS = new List<DegreeS>();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DegreeS degree = new DegreeS();
                    if (dt.Rows[i][2].ToString() == "0")
                    {
                        degree.value = 0;
                    }
                    else
                    {
                        degree.value = Convert.ToInt32(dt.Rows[i][1]);
                    }
                    degree.name = dt.Rows[i][0].ToString();

                    degreeS.Add(degree);
                }
            }

            string s = JsonConvert.SerializeObject(degreeS);

            return s;
        }

        public string Salary()
        {

            string strSql = "SELECT * FROM View_Salary";

            DataTable dt = SqlHelper.ExecuteDataset(DbHelperSQL.connectionString, CommandType.Text, strSql).Tables[0];

            List<DegreeS> degreeS = new List<DegreeS>();

            if (dt.Rows.Count>0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DegreeS degree = new DegreeS()
                    {
                        value = Convert.ToInt32(dt.Rows[i][1]),
                        name = dt.Rows[i][0].ToString()
                    };
                    degreeS.Add(degree);
                }
            }

            string s = JsonConvert.SerializeObject(degreeS);

            return s;
        }

        public class DegreeS
        {
            public int value { get; set; }
            public string name { get; set; }
        }
        
    }
}
