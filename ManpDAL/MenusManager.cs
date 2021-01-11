using System.Data;

namespace ManpDAL
{
    public class MenusManager
    {
        string strConn = "server=.;database=Manpower;uid=sa;pwd=111";

        public DataTable MenusPrint()
        {
            string strSql = "SELECT * FROM [dbo].[Menus]";
            DataTable dt = SqlHelper.ExecuteDataset(strConn, CommandType.Text, strSql).Tables[0];
            return dt;
        }
    }
}
