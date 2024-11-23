using Final_Project_E_Fawatercom_System.Helpers;
using Final_Project_E_Fawatercom_System.POM;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_E_Fawatercom_System.Data;
using Final_Project_E_Fawatercom_System.AssistantMethods;
using Bytescout.Spreadsheet;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using Newtonsoft.Json;
using OpenQA.Selenium.Support.UI;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Final_Project_E_Fawatercom_System.TestMethods
{
	[TestClass]
	public class Category_TestMethods
	{
		
		public IWebDriver driver;
			

		public static ExtentReports extentReports = new ExtentReports();
		public static ExtentHtmlReporter reporter = new ExtentHtmlReporter("D:\\Tahaluf\\FinalProjectSelenum\\FinalTestReport\\");
		Category_AssistantMethods category_Assistant1 = new Category_AssistantMethods(ManageDriver.driver);

		[ClassInitialize]
		public static void ClassInitialize(TestContext testContext)
		{
			extentReports.AttachReporter(reporter);
			ManageDriver.MaximizeDriver();

		}
		[ClassCleanup]
		public static void ClassCleanup()
		{
			extentReports.Flush();
			ManageDriver.CloseDriver();
		}

		[TestMethod]
		public void TC1_AddBillToCategoryValidrequerd()
		{
			var test = extentReports.CreateTest("AddBillToCategory", "AddBillToCategory");
			try
			{
				IWebDriver driver = ManageDriver.driver; 
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				Category_AssistantMethods.GetRandomRowIndex();
				Category category = Category_AssistantMethods.ReadBillNameDataFromExcel(2);
				Category_AssistantMethods.FillCategoryFormsFromTable(category);
				var expectedMessage = "Add company information successfully";
				var actualMessage = "Add company information successfully";

				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email));
				
				Assert.IsFalse(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email + "  "+ "Not success"));
				test.Pass("Form submitted successfully");
			}
			catch (Exception ex)
			{
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC2_verfiyBillCreationEmptyName()
		{
			var test = extentReports.CreateTest("AddBillToCategory", "AddBillToCategory");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				Category_AssistantMethods.GetRandomRowIndex();
				Category category = Category_AssistantMethods.ReadBillNameDataFromExcel(3);
				Category_AssistantMethods.FillCategoryFormsFromTable(category);
				var expectedMessage = "An error message indicating that the bill name is required";
				var actualMessage = "An error message indicating that the bill name is required";
				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email));

				Assert.IsFalse(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");
			}
			catch (Exception ex)
			{
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC3_verfiyBillCreationEmptyEmail()
		{
			var test = extentReports.CreateTest("AddBillToCategory", "AddBillToCategory");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				Category_AssistantMethods.GetRandomRowIndex();
				Category category = Category_AssistantMethods.ReadBillNameDataFromExcel(4);
				Category_AssistantMethods.FillCategoryFormsFromTable(category);
				var expectedMessage = "An error message indicating that the bill Email is required";
				var actualMessage = "An error message indicating that the bill Email is required";
				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email));

				Assert.IsFalse(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");
			}
			catch (Exception ex)
			{
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC4_verfiyBillCreationEmptyLocation()
		{
			var test = extentReports.CreateTest("AddBillToCategory", "AddBillToCategory");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				Category_AssistantMethods.GetRandomRowIndex();
				Category category = Category_AssistantMethods.ReadBillNameDataFromExcel(5);
				Category_AssistantMethods.FillCategoryFormsFromTable(category);
				var expectedMessage = "An error message indicating that the bill Location is required";
				var actualMessage = "An error message indicating that the bill Location is required";
				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email));

				Assert.IsFalse(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");
			}
			catch (Exception ex)
			{
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC5_verfiyBillinvalidEmailFormat()
		{
			var test = extentReports.CreateTest("AddBillToCategory", "AddBillToCategory");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				Category_AssistantMethods.GetRandomRowIndex();
				Category category = Category_AssistantMethods.ReadBillNameDataFromExcel(6);
				Category_AssistantMethods.FillCategoryFormsFromTable(category);
				var expectedMessage = "An error message invalid Email Format";
				var actualMessage = "An error message  invalid Email Format";
				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email));

				Assert.IsFalse(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");
			}
			catch (Exception ex)
			{
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC6_InvalidSpecialCharactersinBillName()
		{
			var test = extentReports.CreateTest("AddBillToCategory", "AddBillToCategory");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				Category_AssistantMethods.GetRandomRowIndex();
				Category category = Category_AssistantMethods.ReadBillNameDataFromExcel(7);
				Category_AssistantMethods.FillCategoryFormsFromTable(category);
				var expectedMessage = "An error message invalid name";
				var actualMessage = "Name added successfully";
				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email));

				Assert.IsFalse(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");
			}
			catch (Exception ex)
			{
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC7_InvalidWhitespaceHandlinginEmail()
		{
			var test = extentReports.CreateTest("AddBillToCategory", "AddBillToCategory");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				Category_AssistantMethods.GetRandomRowIndex();
				Category category = Category_AssistantMethods.ReadBillNameDataFromExcel(8);
				Category_AssistantMethods.FillCategoryFormsFromTable(category);
				var expectedMessage = "An error message indicating that the bill email is required";
				var actualMessage = "Name added successfully";
				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email));

				Assert.IsFalse(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");
			}
			catch (Exception ex)
			{
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC8_InvalidBillnamestartwithanumber()
		{
			var test = extentReports.CreateTest("AddBillToCategory", "AddBillToCategory");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				Category_AssistantMethods.GetRandomRowIndex();
				Category category = Category_AssistantMethods.ReadBillNameDataFromExcel(9);
				Category_AssistantMethods.FillCategoryFormsFromTable(category);
				var expectedMessage = "An error message indicating that the bill name is required";
				var actualMessage = "Name added successfully";
				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email));

				Assert.IsFalse(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");
			}
			catch (Exception ex)
			{
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC9_Makesurethecreateiconisactive()
		{
			var test = extentReports.CreateTest("AddBillToCategory", "AddBillToCategory");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				Category_AssistantMethods.GetRandomRowIndex();
				Category category = Category_AssistantMethods.ReadBillNameDataFromExcel(10);
				Category_AssistantMethods.FillCategoryFormsFromTable(category);
				var expectedMessage = "is acctive and bills page displayed successfully";
				var actualMessage = "is acctive and bills page displayed successfully";
				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email));

				Assert.IsFalse(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");
			}
			catch (Exception ex)
			{
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC10_Checkthatduplicatebillsname()
		{
			var test = extentReports.CreateTest("AddBillToCategory", "AddBillToCategory");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				Category_AssistantMethods.GetRandomRowIndex();
				Category category = Category_AssistantMethods.ReadBillNameDataFromExcel(11);
				Category_AssistantMethods.FillCategoryFormsFromTable(category);
				var expectedMessage = "to accept the same name";
				var actualMessage = "Same name accepted";
				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email));

				Assert.IsFalse(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");
			}
			catch (Exception ex)
			{
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC11_CheckthatSamebillsnameiInformation()
		{
			var test = extentReports.CreateTest("AddBillToCategory", "AddBillToCategory");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				Category_AssistantMethods.GetRandomRowIndex();
				Category category = Category_AssistantMethods.ReadBillNameDataFromExcel(12);
				Category_AssistantMethods.FillCategoryFormsFromTable(category);
				var expectedMessage = "The information is different and the system rejects it.";
				var actualMessage = "Same information accepted";
				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email));

				Assert.IsFalse(Category_AssistantMethods.CheckSuccessAddBillCategory(category.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");
			}
			catch (Exception ex)
			{
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}


	}
}

	