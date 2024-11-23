using DocumentFormat.OpenXml.Spreadsheet;
using Final_Project_E_Fawatercom_System.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_E_Fawatercom_System.POM
{
	public class ChangeNamePage
	{
		public IWebDriver _driver;
		public ChangeNamePage(IWebDriver driver)
		{
			_driver = driver;
		}

		By FullName = By.XPath("//input[@formcontrolname='FullName']");
		By Curentpassword = By.XPath("//input[@formcontrolname='password']"); 
		By NewPassword = By.XPath("//input[@formcontrolname='curenrpassword']");
		By phonenumber = By.XPath("//input[@formcontrolname='PhoneNumber']");
		By Adress = By.XPath("//input[@formcontrolname='address']");
		By Email = By.XPath("//input[@formcontrolname='Email']");
		By UserName = By.XPath("//input[@formcontrolname='username']");
		By image = By.XPath("//input[@type='file']");
		By UpdateButton = By.XPath("//button[@class='bac' and text()='Update']");


		public void EnterFullName(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(FullName); 
			CommonMethods.HighlightElement(element); 
			element.SendKeys(value);
		}
		public void EnterCurentpassword(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(Curentpassword);
			CommonMethods.HighlightElement(element); 
			element.SendKeys(value); 
		}

		public void EnterNewPassword(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(NewPassword); 
			CommonMethods.HighlightElement(element); 
			element.SendKeys(value); 
		}

		public void Enterphonenumber(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(phonenumber); 
			CommonMethods.HighlightElement(element); 
			element.SendKeys(value); 
		}
		public void EnterAdress(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(Adress); 
			CommonMethods.HighlightElement(element); 
			element.SendKeys(value); 
		}

		public void EnterEmail(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(Email); 
			CommonMethods.HighlightElement(element); 
			element.SendKeys(value); 
		}
		public void EnterUserName(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(UserName); 
			CommonMethods.HighlightElement(element); 
			element.SendKeys(value); 
		}
		public void Enterimage(string value)
		{
			IWebElement element = CommonMethods.WaitAndFindElement(image); 
			CommonMethods.HighlightElement(element); 
			element.SendKeys(value); 
		}

		public void ClickSubmitButton()
		{
			CommonMethods.WaitAndFindElement(UpdateButton).Click(); 
		}


	}
}
