using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManpowerMODEL
{
	/// <summary>
	/// Department:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Department
	{
		public Department()
		{ }
		#region Model
		private int _id;
		private string _name;
		private int _pid;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set { _id = value; }
			get { return _id; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set { _name = value; }
			get { return _name; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int PID
		{
			set { _pid = value; }
			get { return _pid; }
		}
		#endregion Model

	}
}
