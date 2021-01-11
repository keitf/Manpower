using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManpowerMODEL
{
	/// <summary>
	/// View_EmployeeSEL:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class View_EmployeeSEL
	{
		public View_EmployeeSEL()
		{ }
		#region Model
		private int _id;
		private string _name;
		private int _departmentid;
		private string _department;
		private int _sex;
		private DateTime _birthday;
		private string _idcard;
		private string _position;
		private string _phone;
		private string _email;
		private string _nation;
		private string _polity;
		private string _degree;
		private decimal _salary;
		private string _resume;
		private string _meno;
		private int _status;
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
		public int DepartmentID
		{
			set { _departmentid = value; }
			get { return _departmentid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Department
		{
			set { _department = value; }
			get { return _department; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int Sex
		{
			set { _sex = value; }
			get { return _sex; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Birthday
		{
			set { _birthday = value; }
			get { return _birthday; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string IdCard
		{
			set { _idcard = value; }
			get { return _idcard; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Position
		{
			set { _position = value; }
			get { return _position; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set { _phone = value; }
			get { return _phone; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set { _email = value; }
			get { return _email; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Nation
		{
			set { _nation = value; }
			get { return _nation; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Polity
		{
			set { _polity = value; }
			get { return _polity; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Degree
		{
			set { _degree = value; }
			get { return _degree; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Salary
		{
			set { _salary = value; }
			get { return _salary; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Resume
		{
			set { _resume = value; }
			get { return _resume; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string Meno
		{
			set { _meno = value; }
			get { return _meno; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			set { _status = value; }
			get { return _status; }
		}
		#endregion Model

	}
}