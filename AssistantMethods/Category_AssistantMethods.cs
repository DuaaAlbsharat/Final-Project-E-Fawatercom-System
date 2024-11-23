
using Bytescout.Spreadsheet;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Final_Project_E_Fawatercom_System.Data;
using Final_Project_E_Fawatercom_System.Helpers;
using Final_Project_E_Fawatercom_System.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_E_Fawatercom_System.AssistantMethods
{
	public class Category_AssistantMethods
	{
		public IWebDriver _driver;

		public Category_AssistantMethods(IWebDriver driver)
		{
			_driver = driver;
		}

		static By Rows = By.XPath("//table/tbody/tr");  // لتحديد كل صف داخل الجدول

		public static void GetRandomRowIndex()
		{
			CategoryPage manageCategoryPage = new CategoryPage(ManageDriver.driver);
			List<IWebElement> TableRows = ManageDriver.driver.FindElements(By.XPath("//tbody/tr")).ToList();

			if (TableRows.Count > 0)
			{
				Random rand = new Random();

				// اختيار فئة عشوائية من الصفوف
				int randomRowIndex = rand.Next(TableRows.Count);
				IWebElement selectedRow = TableRows[randomRowIndex];

				// الحصول على اسم الفئة من الصف المختار (افترض أن الاسم موجود في عمود محدد)
				string categoryName = selectedRow.FindElement(By.XPath(".//td[1]")).Text; // تغيير XPath حسب العمود الذي يحتوي على اسم الفئة

				// العثور على زر "Submit" داخل الصف المختار
				IWebElement selectedButton = selectedRow.FindElement(By.XPath(".//button[contains(text(), 'Create')]"));

				// تمييز العنصر
				CommonMethods.HighlightElement(selectedButton);

				// النقر على الزر
				selectedButton.Click();

				// استخدام اسم الفئة المحدد
				Console.WriteLine($"Bill added successfully to the category: {categoryName}.");

			}

		}

		public static Category ReadBillNameDataFromExcel(int row)
		{

			Category category = new Category();
			Bytescout.Spreadsheet.Worksheet worksheet = CommonMethods.ReadExcel("Category");
			category.Name = Convert.ToString(worksheet.Cell(row, 2).Value);
			category.Email = Convert.ToString(worksheet.Cell(row, 3).Value);
			category.Location = Convert.ToString(worksheet.Cell(row, 4).Value);
			return category;
		}

		public static void FillCategoryFormsFromTable(Category category)
		{

			// إنشاء كائن من صفحة الفئة
			CategoryPage categoryPage = new CategoryPage(ManageDriver.driver);
				// إدخال بيانات الفئة
			categoryPage.EnterName(category.Name);
			categoryPage.EnterEmail(category.Email);
			categoryPage.EnterLocation(category.Location);
			categoryPage.ClickCreateButtonSubmit();
			Console.WriteLine($"Category form submitted successfully for: {category.Name}");
		
		}
		public static bool CheckSuccessAddBillCategory(string Email)
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
	



	









