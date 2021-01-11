using ManpowerMODEL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;


namespace Manpower
{
    public partial class AllTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ManpBLL.Statistics statistics = new ManpBLL.Statistics();

            string s = statistics.Salary();
        }
    }
}