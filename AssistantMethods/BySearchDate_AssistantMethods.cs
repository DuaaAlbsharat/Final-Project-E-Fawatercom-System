using AventStack.ExtentReports;
using Bytescout.Spreadsheet;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Wordprocessing;
using Final_Project_E_Fawatercom_System.Data;
using Final_Project_E_Fawatercom_System.Helpers;
using Final_Project_E_Fawatercom_System.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_E_Fawatercom_System.AssistantMethods
{
	public class BySearchDate_AssistantMethods
	{
		public IWebDriver _driver;
		public BySearchDate_AssistantMethods(IWebDriver driver)
		{
			_driver = driver;

		}

		public static Search ReadBillNameDataFromExcel(int row)
		{
			Search search = new Search(ManageDriver.driver);
	        Worksheet worksheet = CommonMethods.ReadExcel("SearchDate");
			search.StartDate = Convert.ToString(worksheet.Cell(row, 2).Value);
			search.EndDate = Convert.ToString(worksheet.Cell(row, 3).Value);
			Console.WriteLine($"StartDate: {search.StartDate}, EndDate: {search.EndDate}");
			return search;
		}

		public static void FillData(Search search)
		{
			
			SearchByDatePage searchByDate = new SearchByDatePage(ManageDriver.driver);
			// تعيين التواريخ في الحقول باستخدام الدوال الموجودة
			searchByDate.SetStartDate(search.StartDate);
			searchByDate.SetEndDate(search.EndDate);
			//searchByDate.ClickSearchButton();
		}
		public static int GetRowCount(IWebDriver driver)
		{
			try
			{
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


				var rows = driver.FindElements(By.XPath("//tbody//tr"));
				return rows.Count;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error getting row count: {ex.Message}");
				return 0;
			}
		}

		
		public static string GetTotalProfitValue(IWebDriver driver)
		{
			// البحث عن جميع الصفوف في الجدول
			IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//table/tbody/tr"));

			// التكرار على كل صف للعثور على الصف الذي يحتوي على "Total Profit"
			foreach (IWebElement row in rows)
			{
				// البحث عن جميع الأعمدة في الصف الحالي
				IReadOnlyCollection<IWebElement> cells = row.FindElements(By.TagName("th"));

				// التحقق إذا كان الصف يحتوي على النص "Total Profit"
				foreach (IWebElement cell in cells)
				{
					if (cell.Text.Contains("Total Profit"))
					{
						// بمجرد العثور على الصف، الوصول إلى العمود الثالث للحصول على قيمة الربح
						IWebElement totalProfitValueCell = row.FindElement(By.XPath("//table//tbody//th[2]")); // العمود الرابع الثابت
						CommonMethods.HighlightElement(totalProfitValueCell);

						// إعادة النص بعد إزالة المسافات غير الضرورية
						return totalProfitValueCell.Text.Trim();
					}
				}
			}

			// في حالة عدم العثور على "Total Profit"، يمكنك إرجاع قيمة فارغة أو رسالة خطأ حسب الحاجة
			throw new Exception("Could not find 'Total Profit' row in the table.");
		}

		public static string GetTableCellValue(int row, int column, IWebDriver driver)
		{

			// تحديد مسار XPath للخلية بناءً على الرقم الصف والعمود
			// XPath يعتمد على هيكل الجدول
			string xpath = $"//tbody/tr[{row + 1}]/td[{column + 1}]";
			try
			{
				// البحث عن العنصر (الخلية) باستخدام XPath
				var cellElement = driver.FindElement(By.XPath(xpath));
				CommonMethods.HighlightElement(cellElement);
				return cellElement.Text; // إرجاع النص الموجود في الخلية
			}
			catch (NoSuchElementException)
			{
				// إذا لم يتم العثور على العنصر، إرجاع قيمة فارغة أو معالجة حسب الحاجة
				return string.Empty;
			}
		}


		public static IWebElement GetButtonInRow(int rowIndex, IWebDriver driver)
		{
			// افترض أن الزر في العمود الرابع (أي داخل <td> في العمود الرابع في صف <tr>) داخل الجدول
			string buttonXPath = $"//table/tbody/tr[{rowIndex + 1}]/td[4]//button";  // تعديل حسب هيكل HTML

			try
			{
				// العثور على الزر داخل الصف باستخدام XPath
				IWebElement button = driver.FindElement(By.XPath(buttonXPath));
				CommonMethods.HighlightElement(button);
				return button;
			}
			catch (NoSuchElementException)
			{
				// في حال عدم العثور على الزر، يمكنك إرجاع null أو التعامل مع الخطأ بطريقة أخرى
				Console.WriteLine($"Button not found in row {rowIndex + 1}");
				return null;
			}
		}
		


		public static List<string> GetPaymentDates(IWebDriver driver)
		{
			try
			{
				// الـ XPath الذي يستهدف جميع الخلايا في العمود الرابع (تواريخ الدفع) في جميع الصفوف
				string paymentDateXPath = "/html/body/app-root/app-detels/div/div/div/div/table/tbody/tr/td[4]";

				// الحصول على جميع العناصر التي تحتوي على تواريخ الدفع
				IReadOnlyCollection<IWebElement> paymentDateElements = driver.FindElements(By.XPath(paymentDateXPath));

				List<string> paymentDates = new List<string>();

				// التكرار على جميع العناصر وإضافة التواريخ إلى القائمة
				foreach (var element in paymentDateElements)
				{
					CommonMethods.HighlightElement(element);  // تمييز العنصر إذا كنت بحاجة لهذا
					paymentDates.Add(element.Text);  // إضافة التاريخ إلى القائمة
				}

				return paymentDates;
			}
			catch (NoSuchElementException)
			{
				Console.WriteLine("عناصر تواريخ الدفع غير موجودة.");
				return new List<string>();  // إرجاع قائمة فارغة إذا لم يتم العثور على العناصر
			}
		}






	}
}
