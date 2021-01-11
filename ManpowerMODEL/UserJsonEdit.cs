using System.Collections.Generic;

namespace ManpowerMODEL
{
    public class UserJsonEdit
    {
        public class JsonData
        {
            /// <summary>
            /// 
            /// </summary>
            public string ID { get; set; }
            /// <summary>
            /// 用户名
            /// </summary>
            public string Account { get; set; }
            /// <summary>
            /// 密码
            /// </summary>
            public string Password { get; set; }
            /// <summary>
            /// 密码
            /// </summary>
            /// <summary>
            /// RoleID
            /// </summary>
            public string IsActive { get; set; }
            /// <summary>
            /// 时间
            /// </summary>
            public string CreatDate { get; set; }
            public int RowID { get; set; }
            public string Name { get; set; }
            public string RID { get; set; }
        }

        public class JsonRoot
        {
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int count { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<JsonData> data { get; set; }
        }
    }
}
