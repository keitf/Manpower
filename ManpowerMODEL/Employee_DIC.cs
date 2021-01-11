using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace ManpowerMODEL
{
	 	//Employee_DIC
		public class Employee_DIC
	{
   		     
      	/// <summary>
		/// ID
        /// </summary>		
		private int _id;
        public int ID
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// Name
        /// </summary>		
		private string _name;
        public string Name
        {
            get{ return _name; }
            set{ _name = value; }
        }        
		/// <summary>
		/// PID
        /// </summary>		
		private int _pid;
        public int PID
        {
            get{ return _pid; }
            set{ _pid = value; }
        }        
		   
	}
}

