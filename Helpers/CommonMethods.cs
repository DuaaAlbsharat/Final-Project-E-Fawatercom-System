using Bytescout.Spreadsheet;
using Final_Project_E_Fawatercom_System.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_E_Fawatercom_System.Helpers
{
	public class CommonMethods
	{
		public static void NavigateToURL(string url)
		{

			ManageDriver.driver.Navigate().GoToUrl(url);
		}
		public static IWebElement WaitAndFindElement(By by)
		{

			var fluentWait = new DefaultWait<IWebDriver>(ManageDriver.driver)
			{

				Timeout = TimeSpan.FromSeconds(20),

				PollingInterval = TimeSpan.FromMilliseconds(500),
			};

			fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
			IWebElement element = fluentWait.Until(x => x.FindElement(by));
			return element;
		}
		public static void HighlightElement(IWebElement element)
		{

			IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)ManageDriver.driver;
			javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'background: lightpink !important')", element);
			javaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
			Thread.Sleep(1000);
			javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', 'background: none !important')", element);
		}
		public static Worksheet ReadExcel(string sheetName)
		{
			// Create a new instance of the Spreadsheet class
			Spreadsheet Excel = new Spreadsheet();

			// Load the Excel file from the specified path in GlobalConstants
			Excel.LoadFromFile(GlobalConstants.TestDataPath);

			// Retrieve the worksheet by its name from the loaded workbook
			Worksheet worksheet = Excel.Workbook.Worksheets.ByName(sheetName);

			// Return the retrieved worksheet
			return worksheet;
		}
		public static string TakeScreenShot()
		{

			ITakesScreenshot takesScreenshot = (ITakesScreenshot)ManageDriver.driver;
			Screenshot screenshot = takesScreenshot.GetScreenshot();
			string path = "D:\\Tahaluf\\FinalProjectSelenum\\FinalTestReport\\ScreenShoot";
			string imageName = Guid.NewGuid().ToString() + "_image.png";
			string fullPath = Path.Combine(path + $"\\{imageName}");
			screenshot.SaveAsFile(fullPath);
			return fullPath;
		}
	}
}
