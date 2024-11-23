using Bytescout.Spreadsheet;
using Final_Project_E_Fawatercom_System.Data;
using Final_Project_E_Fawatercom_System.Helpers;
using Final_Project_E_Fawatercom_System.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_E_Fawatercom_System.Data;

namespace Final_Project_E_Fawatercom_System.AssistantMethods
{
	public class Login_AssistantMethods
	{
		public static void FillLoginForm(string Username, string password)
		{
			LoginPage loginPage = new LoginPage(ManageDriver.driver);
			loginPage.EnterName(Username);
			loginPage.EnterPassword(password);
			loginPage.ClickSubmitButton();

		}


	}
}
