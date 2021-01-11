using System.Collections.Generic;

namespace ManpowerMODEL
{
    public class RoleJsonEdit
    {
        public class JsonData
        {
            /// <summary>
            ///  
            /// <summary>
            public int ID { get; set; }

            /// <summary>
            ///  
            /// <summary>
            public string Name { get; set; }

            /// <summary>
            ///  
            /// <summary>
            public string CreateDate { get; set; }

            /// <summary>
            ///  
            /// <summary>
            public string Content { get; set; }

            public string Expower { get; set; }
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
        public class ChildrenItem
        {
            /// <summary>
            /// 子级
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 父级
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<ChildrenItem> children { get; set; }
        }

    }
}
