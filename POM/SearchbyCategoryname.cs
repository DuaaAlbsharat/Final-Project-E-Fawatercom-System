using DocumentFormat.OpenXml.Bibliography;
using Final_Project_E_Fawatercom_System.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_E_Fawatercom_System.POM
{
	public class SearchbyCategoryname
	{
		public IWebDriver _driver;
		public SearchbyCategoryname(IWebDriver  driver)
		{
			_driver = driver;
		}

		public IWebElement CategoryDropdown => CommonMethods.WaitAndFindElement(By.XPath("//select[@formcontrolname='Billercategoryname']"));
		public IWebElement CategoryNameField => CommonMethods.WaitAndFindElement(By.XPath("/html/body/app-root/app-adminreport/div/div/div[2]/div/table/tbody/tr[1]/td[1]"));
		public IWebElement CountPayField => CommonMethods.WaitAndFindElement(By.XPath("/html/body/app-root/app-adminreport/div/div/div[2]/div/table/tbody/tr[1]/td[2]"));
		public IWebElement SumProfitField => CommonMethods.WaitAndFindElement(By.XPath("/html/body/app-root/app-adminreport/div/div/div[2]/div/table/tbody/tr[1]/td[3]"));
		public IWebElement TotalProfitField => CommonMethods.WaitAndFindElement(By.XPath("/html/body/app-root/app-adminreport/div/div/div[2]/div/table/tbody/tr[2]/th[2]"));


		public void SelectCategory(string categoryName)
		{
			// استخدام WaitAndFindElement للوصول إلى القائمة المنسدلة مع الانتظار
			var categoryDropdown = CommonMethods.WaitAndFindElement(By.XPath("//select[@formcontrolname='Billercategoryname']"));
			CommonMethods.HighlightElement(categoryDropdown);
			// التحقق من عدم وجود مشكلة في العثور على العنصر
			if (categoryDropdown != null)
			{
				var selectElement = new SelectElement(categoryDropdown);
				selectElement.SelectByText(categoryName);

			}
			else
			{
				Console.WriteLine("Category dropdown not found.");
			}
		}



		public string GetCategoryName()
		{
			CommonMethods.HighlightElement(CategoryNameField);
			return CategoryNameField.Text;
		}

		public int GetCountPay()
		{
			CommonMethods.HighlightElement(CountPayField);
			return int.Parse(CountPayField.Text);
		}

		public decimal GetSumProfit()
		{
			CommonMethods.HighlightElement(SumProfitField);
			return decimal.Parse(SumProfitField.Text.Replace("$", "").Trim());
		}

		public decimal GetTotalProfit()
		{
			CommonMethods.HighlightElement(TotalProfitField);
			return decimal.Parse(TotalProfitField.Text.Replace("$", "").Trim());
		}




	}

}

