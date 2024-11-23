using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_E_Fawatercom_System.Data
{
	
	public class Search
	{
		public IWebDriver driver;
		public Search(IWebDriver driver) 
		{
			this.driver = driver;
		}
		public string StartDate { get; set; }
		public string EndDate { get; set; }
	}


	
	
}
