using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_E_Fawatercom_System.Data
{
	public class Category
	{
        public Category() { }
        public Category(string Name, string Email, string Location )
		{
            this.Name = Name;
			this.Email = Email;
			this.Location = Location;
			

		}
        public string Name { get; set; }
		public string Email { get; set; }
		public string Location { get; set; }

	}
}
