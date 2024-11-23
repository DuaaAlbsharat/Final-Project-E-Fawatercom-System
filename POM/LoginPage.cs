using Final_Project_E_Fawatercom_System.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Final_Project_E_Fawatercom_System.POM
{
	public class LoginPage
	{
		public IWebDriver driver;
		public  LoginPage(IWebDriver driver)
		{
			this.driver = driver;
		}
	
		By username = By.XPath("//div//input[@type='email']");
		By password = By.XPath("//div//input[@type='password']");
		By ButtonSubmit = By.XPath("//button[@class='text-center btn btn-info btn-block LoginBtn'][1]");


		public void EnterName(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(username);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);
		}
		public void EnterPassword(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(password);
			CommonMethods.HighlightElement(element);
			element.SendKeys(value);
		}
		
		public void ClickSubmitButton()
		{
			CommonMethods.WaitAndFindElement(ButtonSubmit).Click();
		}

	}
}
