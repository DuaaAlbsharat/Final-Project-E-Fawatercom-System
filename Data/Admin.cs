using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_E_Fawatercom_System.Data
{
	public  class Admin
	{
		public Admin() { }
        public Admin(string FullName, string Curentpassword ,string NewPassword,string phonenumber,string Adress ,string Email, 
                     string UserName ,string image = null)

		{
             this.FullName = FullName;
			 this.Curentpassword = Curentpassword;
			 this.NewPassword = NewPassword;
			 this.phonenumber = phonenumber;
			 this.Adress = Adress;	
			 this.Email = Email;	
			 this.UserName = UserName;	
			


		}
		public string FullName { get; set; }
		public string Curentpassword { get; set; }
		public string NewPassword { get; set; }
		public string phonenumber { get; set; }
		public string Adress { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		

	}
}
