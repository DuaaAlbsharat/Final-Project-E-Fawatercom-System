using DocumentFormat.OpenXml.Spreadsheet;
using Final_Project_E_Fawatercom_System.Data;
using Final_Project_E_Fawatercom_System.Helpers;
using Final_Project_E_Fawatercom_System.POM;
using OpenQA.Selenium;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_E_Fawatercom_System.AssistantMethods
{
	public class AdminUpdate_AssistantMethods
	{
		public static Admin ReadUpdateDataFromExcel(int row)
		{

			Admin admin = new Admin();
			Bytescout.Spreadsheet.Worksheet worksheet = CommonMethods.ReadExcel("UpdateAdmin");

			admin.FullName = Convert.ToString(worksheet.Cell(row, 2).Value);
			admin.Curentpassword = Convert.ToString(worksheet.Cell(row, 3).Value);
			admin.NewPassword = Convert.ToString(worksheet.Cell(row, 4).Value);
			admin.phonenumber = Convert.ToString(worksheet.Cell(row, 5).Value);
			admin.Adress = Convert.ToString(worksheet.Cell(row, 6).Value);
			admin.Email = Convert.ToString(worksheet.Cell(row, 7).Value);
			admin.UserName = Convert.ToString(worksheet.Cell(row, 8).Value);

			return admin;
		}
		public static void FillUpdateForm(Admin admin)
		{

			ChangeNamePage namePage = new ChangeNamePage(ManageDriver.driver);


			namePage.EnterFullName(admin.FullName);
			namePage.EnterCurentpassword(admin.Curentpassword);
			namePage.EnterNewPassword(admin.NewPassword);
			namePage.EnterEmail(admin.Email);
			namePage.EnterUserName(admin.UserName);
			namePage.Enterphonenumber(admin.phonenumber);
			namePage.EnterAdress(admin.Adress);
			namePage.ClickSubmitButton();
		}

		public static bool CheckSuccessUpdate(string email)
		{

			bool isDataExist = false;
			string query = "Select count(*) from userf where EMAIL = :value";
			using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
			{

				connection.Open();
				OracleCommand command = new OracleCommand(query, connection);
				command.Parameters.Add(new OracleParameter(":value", email));
				int result = Convert.ToInt32(command.ExecuteScalar());
				isDataExist = result > 0;
				return isDataExist;

			}
		}

		public static void ClearFormFields(IWebDriver driver)
		{
			// تحديد جميع الحقول داخل النموذج (مثل الحقول النصية)
			var inputFields = driver.FindElements(By.TagName("input"));

			foreach (var field in inputFields)
			{
				// مسح الحقول النصية
				if (field.Displayed && field.Enabled && field.TagName == "input")
				{
					field.Clear();
				}
			}
		}
	}
}
