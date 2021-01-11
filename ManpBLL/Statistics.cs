using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ManpBLL
{
    public class Statistics
    {
        ManpDAL.Statistics Statisticss = new ManpDAL.Statistics();
        public string SexStatis()
        {
            return Statisticss.SexStatis();
        }
        /// <summary>
        /// 【部门.学历】
        /// </summary>
        /// <param name="viewnaem">视图名</param>
        /// <returns>Json</returns>
        public string EchartsData(string viewnaem)
        {
            return Statisticss.EchartsData(viewnaem);
        }

        public string Salary()
        {
            return Statisticss.Salary();
        }
    }
}
