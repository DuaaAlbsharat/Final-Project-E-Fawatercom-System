using DocumentFormat.OpenXml.Bibliography;
using Final_Project_E_Fawatercom_System.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Final_Project_E_Fawatercom_System.POM
{
	public class CategoryPage
	{
		public IWebDriver _driver;
		public CategoryPage(IWebDriver driver)
		{
			_driver = driver;
		}


		// Locators (عناصر الصفحة)

		By Name = By.XPath("//input[@formcontrolname='Billname']");
		By Email = By.XPath("//input[@ng-reflect-name='Email']");
		By Location = By.XPath("//input[@formcontrolname='Location']");
		By ShowButton = By.XPath("//button[contains(text(), 'show')]");
		By Rows = By.XPath("//tbody/tr");  // للعثور على كل صف داخل الجدول

		public List<IWebElement> SubmitCreateButton = new List<IWebElement>
		{
		 CommonMethods.WaitAndFindElement(By.XPath("/html/body/app-root/app-home/div/div/div/table/tbody[1]/tr/td[6]/button[1]")),
		 CommonMethods.WaitAndFindElement(By.XPath("/html/body/app-root/app-home/div/div/div/table/tbody[2]/tr/td[6]/button[1]")),
		 CommonMethods.WaitAndFindElement(By.XPath("/html/body/app-root/app-home/div/div/div/table/tbody[3]/tr/td[6]/button[1]")),
		 CommonMethods.WaitAndFindElement(By.XPath("/html/body/app-root/app-home/div/div/div/table/tbody[4]/tr/td[6]/button[1]")),

		};

		By createButtonSubmit = By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/form/div/div/div[4]/button");

		public void EnterName(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(Name);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);
		}
		public void EnterEmail(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(Email);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);
		}
		public void EnterLocation(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(Location);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);
		}


		public void ClickCreateButtonSubmit()
		{

			// تأكد من أن WebDriver ليس null
			if (_driver == null)
			{
				throw new ArgumentNullException(nameof(_driver), "WebDriver cannot be null");
			}

			// إنشاء Fluent Wait
			var wait = new DefaultWait<IWebDriver>(_driver)
			{
				/*Timeout = TimeSpan.FromSeconds(10),   */ //الوقت الكلي للانتظار
				PollingInterval = TimeSpan.FromMilliseconds(500),  //تكرار الاستعلام عن الشرط
				Message = "Waiting for the create button to be clickable."
			};
		}
			

		
	}
}

