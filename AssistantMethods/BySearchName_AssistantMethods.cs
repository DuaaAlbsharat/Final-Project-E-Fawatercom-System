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
  public  class BySearchName_AssistantMethods
  {
		public IWebDriver _driver;
		public BySearchName_AssistantMethods(IWebDriver driver)
		{
			_driver = driver;
			
		}
		

		//public static bool VerifyReportData(string expectedCategory, int expectedCount, decimal expectedSumProfit, decimal expectedTotalProfit)
		//{
		//	SearchbyCategoryname searchby = new SearchbyCategoryname(ManageDriver.driver);
		//	// الحصول على القيم من الصفحة
		//	string actualCategory = searchby.GetCategoryName();
		//	int actualCount = searchby.GetCountPay();
		//	decimal actualSumProfit = searchby.GetSumProfit();
		//	decimal actualTotalProfit = searchby.GetTotalProfit();

		//	// التحقق من صحة القيم
		//	return actualCategory.Equals(expectedCategory) &&
		//		   actualCount == expectedCount &&
		//		   actualSumProfit == expectedSumProfit &&
		//		   actualTotalProfit == expectedTotalProfit;
		//}

		public static bool CheckSuccessSearchBillCategory(string Email)
		{

			bool isDataExist = false;
			string query = "SELECT COUNT(*) FROM BILLERNAME WHERE Email = :value";
			using (OracleConnection connection = new OracleConnection(GlobalConstants.connectionString))
			{
				connection.Open();
				OracleCommand command = new OracleCommand(query, connection);
				command.Parameters.Add(new OracleParameter(":value", Email));
				// Execute the query and convert the result to an integer.
				// If the email exists, the result will be greater than 0.
				int result = Convert.ToInt32(command.ExecuteScalar());
				isDataExist = result > 0;
				return isDataExist;

			}
		}

		
	}

	
}
