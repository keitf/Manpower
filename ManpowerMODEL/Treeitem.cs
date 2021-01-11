using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManpowerMODEL
{
    public class Treeitem
    {
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

            public List<ChildrenItem> children { get; set; }
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