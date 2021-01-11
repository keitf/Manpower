using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ManpowerMODEL
{
	/// <summary>
	/// Employee:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Employee
	{
		public Employee()
		{ }
		#region Model
		private int _id;
		private int _departmentid;
		private string _name;
		private int _sex;
		private DateTime _birthday;
		private string _idcard;
		private int _position;
		private string _phone;
		private string _email;
		private int _nation;
		private int _polity;
		private int _degree;
		private decimal _salary;
		private string _resume;
		private string _meno;
		private string _status = "1";
		/// <summary>
		/// 员工编号
		/// </summary>
		public int ID
		{
			set { _id = value; }
			get { return _id; }
		}
		/// <summary>
		/// 部门编号
		/// </summary>
		public int DepartmentID
		{
			set { _departmentid = value; }
			get { return _departmentid; }
		}
		/// <summary>
		/// 员工姓名
		/// </summary>
		public string Name
		{
			set { _name = value; }
			get { return _name; }
		}
		/// <summary>
		/// 性别
		/// </summary>
		public int Sex
		{
			set { _sex = value; }
			get { return _sex; }
		}
		/// <summary>
		/// 生日
		/// </summary>
		public DateTime Birthday
		{
			set { _birthday = value; }
			get { return _birthday; }
		}
		/// <summary>
		/// 身份证
		/// </summary>
		public string IdCard
		{
			set { _idcard = value; }
			get { return _idcard; }
		}
		/// <summary>
		/// 职位
		/// </summary>
		public int Position
		{
			set { _position = value; }
			get { return _position; }
		}
		/// <summary>
		/// 电话
		/// </summary>
		public string Phone
		{
			set { _phone = value; }
			get { return _phone; }
		}
		/// <summary>
		/// 邮箱
		/// </summary>
		public string Email
		{
			set { _email = value; }
			get { return _email; }
		}
		/// <summary>
		/// 民族
		/// </summary>
		public int Nation
		{
			set { _nation = value; }
			get { return _nation; }
		}
		/// <summary>
		/// 政治面貌
		/// </summary>
		public int Polity
		{
			set { _polity = value; }
			get { return _polity; }
		}
		/// <summary>
		/// 学历
		/// </summary>
		public int Degree
		{
			set { _degree = value; }
			get { return _degree; }
		}
		/// <summary>
		/// 月薪
		/// </summary>
		public decimal Salary
		{
			set { _salary = value; }
			get { return _salary; }
		}
		/// <summary>
		/// 个人履历
		/// </summary>
		public string Resume
		{
			set { _resume = value; }
			get { return _resume; }
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Meno
		{
			set { _meno = value; }
			get { return _meno; }
		}
		/// <summary>
		/// 是否在职
		/// </summary>
		public string Status
		{
			set { _status = value; }
			get { return _status; }
		}
		#endregion Model
	}
}

