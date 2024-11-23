using DocumentFormat.OpenXml.Bibliography;
using Final_Project_E_Fawatercom_System.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_E_Fawatercom_System.POM
{
	public class SearchByDatePage
	{
		public IWebDriver _driver;
		public SearchByDatePage(IWebDriver driver)
		{
			_driver = driver;
		}
		//input[@formcontrolname='DateFrom']

		public IWebElement StartDateInput => _driver.FindElement(By.XPath("/html/body/app-root/app-adminreport/div/div/div[1]/div/div/div/div/form/div[2]/input")); // استبدل بالمعرف الفعلي
		public IWebElement EndDateInput => _driver.FindElement(By.XPath("//input[@ng-reflect-name='DateTo']")); // استبدل بالمعرف الفعلي


		// طرق لتعيين التواريخ
		public void SetStartDate(string date)
		{
			SetDate(StartDateInput, date);
		}

		public void SetEndDate(string date)
		{
			SetDate(EndDateInput, date);
		}

		

		public void SetDate(IWebElement dateInputElement, string dateString)
		{
			// التحقق من أن قيمة التاريخ ليست فارغة قبل محاولة التحويل
			if (!string.IsNullOrEmpty(dateString))
			{
				DateTime parsedDate;
				// محاولة تحليل التاريخ بتنسيق "dd-MM-yyyy"
				bool isValidDate = DateTime.TryParseExact(dateString, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);

				if (!isValidDate)
				{
					// في حال كان التاريخ بتنسيق غير صحيح، نقوم بطباعة رسالة للمستخدم
					Console.WriteLine($"Error: The date '{dateString}' is in an incorrect format. Please use 'dd-MM-yyyy'.");
					// يمكنك هنا إيقاف العملية أو الاستمرار حسب احتياجك
					return; // إيقاف العملية في حال كان التاريخ غير صالح
				}

				// إذا كان التاريخ صالحًا، نقوم بتنسيقه إلى "yyyy-MM-dd"
				string formattedDate = parsedDate.ToString("yyyy-MM-dd");

				// استخدام JavaScript لتعيين قيمة حقل التاريخ
				IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
				jsExecutor.ExecuteScript("arguments[0].value = arguments[1];", dateInputElement, formattedDate);

				// الانتظار لبعض الوقت للسماح بتحديث واجهة المستخدم إن لزم الأمر
				System.Threading.Thread.Sleep(3000);

				// محاكاة الضغط على الأسهم إذا لزم الأمر
				dateInputElement.SendKeys(Keys.ArrowUp);
				dateInputElement.SendKeys(Keys.ArrowDown);
			}
			else
			{
				// إذا كانت قيمة التاريخ فارغة، نطبع تحذيرًا
				Console.WriteLine("Warning: Date string is empty or null, skipping date input.");
			}
		}



		public void ClickSearchButton()
		{
			
			IWebElement searchButton = _driver.FindElement(By.XPath("/html/body/app-root/app-adminreport/div/div/div[2]/div/table/tbody/tr[1]/td[4]/button"));
		     	searchButton.Click();
		}

	}
}
