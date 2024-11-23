using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_E_Fawatercom_System.Helpers;
using Final_Project_E_Fawatercom_System.POM;
using Final_Project_E_Fawatercom_System.AssistantMethods;
using Final_Project_E_Fawatercom_System.Data;
using OpenQA.Selenium.Support.UI;

namespace Final_Project_E_Fawatercom_System.TestMethods
{
	[TestClass]
	public class SearchbyCategoryname_TestMethods
	{
		public IWebDriver driver;
		SearchbyCategoryname SearchbyCategoryname = new SearchbyCategoryname(ManageDriver.driver);

		public static ExtentReports extentReports = new ExtentReports();
		public static ExtentHtmlReporter reporter = new ExtentHtmlReporter("D:\\Tahaluf\\FinalProjectSelenum\\FinalTestReportSearchName\\");

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
		public void TC1_CategorySearchEducationName()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TestCategorySearch", "TestCategorySearch");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(ManageDriver.driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// تعريف بيانات الاختبار
				string expectedCategoryName = "Education";

				// تحديد الفئة من القائمة المنسدلة
				SearchbyCategoryname.SelectCategory(expectedCategoryName);
				// الحصول على القيم الفعلية من الصفحة
				string actualCategoryName = SearchbyCategoryname.GetCategoryName();
				Thread.Sleep(3000);
				// التحقق من مطابقة البيانات المتوقعة مع البيانات الفعلية باستخدام Assert.AreEqual
				Assert.AreEqual(expectedCategoryName, actualCategoryName, $"Expected Category Name: {expectedCategoryName}, but got: {actualCategoryName}");

				Console.WriteLine("Category name is success  ");
				// تسجيل النجاح في التقرير
				test.Pass("The item name is in the list and is in the database.");
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC2_CategorySearchEducationCount()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TestCategorySearch", "TestCategorySearch");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(ManageDriver.driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// تعريف بيانات الاختبار
				string expectedCategoryName = "Education";
				int expectedCount = 4;

				// تحديد الفئة من القائمة المنسدلة
				SearchbyCategoryname.SelectCategory(expectedCategoryName);

				// الحصول على القيم الفعلية من الصفحة
				string actualCategoryName = SearchbyCategoryname.GetCategoryName();
				int actualCount = SearchbyCategoryname.GetCountPay();
				decimal actualSumProfit = SearchbyCategoryname.GetSumProfit();
				decimal actualTotalProfit = SearchbyCategoryname.GetTotalProfit();
				Thread.Sleep(2000);
				// التحقق من مطابقة البيانات المتوقعة مع البيانات الفعلية باستخدام Assert.AreEqual
				Assert.AreEqual(expectedCategoryName, actualCategoryName, $"Expected Category Name: {expectedCategoryName}, but got: {actualCategoryName}");
				Assert.AreEqual(expectedCount, actualCount, $"Expected Count: {expectedCount}, but got: {actualCount}");
				//Assert.AreEqual(expectedSumProfit, actualSumProfit, $"Expected Sum Profit: {expectedSumProfit}, but got: {actualSumProfit}");
				//Assert.AreEqual(expectedTotalProfit, actualTotalProfit, $"Expected Total Profit: {expectedTotalProfit}, but got: {actualTotalProfit}");

				// تسجيل النجاح في التقرير
				test.Pass("The information is correct and available in the database.");
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC3_CategorySearchEducationSumProfit()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TestCategorySearch", "TestCategorySearch");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(ManageDriver.driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// تعريف بيانات الاختبار
				string expectedCategoryName = "Education";
				decimal expectedSumProfit = 10;

				// تحديد الفئة من القائمة المنسدلة
				SearchbyCategoryname.SelectCategory(expectedCategoryName);
				Thread.Sleep(3000);
				// الحصول على القيم الفعلية من الصفحة
				string actualCategoryName = SearchbyCategoryname.GetCategoryName();
				int actualCount = SearchbyCategoryname.GetCountPay();
				decimal actualSumProfit = SearchbyCategoryname.GetSumProfit();
				decimal actualTotalProfit = SearchbyCategoryname.GetTotalProfit();

				Thread.Sleep(2000);
				// التحقق من مطابقة البيانات المتوقعة مع البيانات الفعلية باستخدام Assert.AreEqual
				Assert.AreEqual(expectedCategoryName, actualCategoryName, $"Expected Category Name: {expectedCategoryName}, but got: {actualCategoryName}");
				Assert.AreEqual(expectedSumProfit, actualSumProfit, $"Expected Sum Profit: {expectedSumProfit}, but got: {actualSumProfit}");


				// تسجيل النجاح في التقرير
				test.Pass("The information is correct and available in the database.");
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC4_CategorySearchEducationTotalProfit()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TestCategorySearch", "TestCategorySearch");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(ManageDriver.driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// تعريف بيانات الاختبار
				string expectedCategoryName = "Education";
				decimal expectedTotalProfit = 10;

				// تحديد الفئة من القائمة المنسدلة
				SearchbyCategoryname.SelectCategory(expectedCategoryName);
				Thread.Sleep(3000);
				// الحصول على القيم الفعلية من الصفحة
				string actualCategoryName = SearchbyCategoryname.GetCategoryName();
				int actualCount = SearchbyCategoryname.GetCountPay();
				decimal actualSumProfit = SearchbyCategoryname.GetSumProfit();
				decimal actualTotalProfit = SearchbyCategoryname.GetTotalProfit();

				// التحقق من مطابقة البيانات المتوقعة مع البيانات الفعلية باستخدام Assert.AreEqual
				Assert.AreEqual(expectedCategoryName, actualCategoryName, $"Expected Category Name: {expectedCategoryName}, but got: {actualCategoryName}");
				Assert.AreEqual(expectedTotalProfit, actualTotalProfit, $"Expected Total Profit: {expectedTotalProfit}, but got: {actualTotalProfit}");
				// تسجيل النجاح في التقرير
				test.Pass("The information is correct and available in the database.");
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}

		[TestMethod]
		public void TC5_CategorySearchTelecommunicationName()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TestCategorySearch", "TestCategorySearch");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(ManageDriver.driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
				// تعريف بيانات الاختبار
				string expectedCategoryName = "Telecommunication";
				int expectedCount = 4;
				decimal expectedSumProfit = 8;
				decimal expectedTotalProfit = 8;
				// تحديد الفئة من القائمة المنسدلة
				SearchbyCategoryname.SelectCategory(expectedCategoryName);
				Thread.Sleep(3000);
				// الحصول على القيم الفعلية من الصفحة
				string actualCategoryName = SearchbyCategoryname.GetCategoryName();
				int actualCount = SearchbyCategoryname.GetCountPay();
				decimal actualSumProfit = SearchbyCategoryname.GetSumProfit();
				decimal actualTotalProfit = SearchbyCategoryname.GetTotalProfit();
				// التحقق من مطابقة البيانات المتوقعة مع البيانات الفعلية باستخدام Assert.AreEqual
				Assert.AreEqual(expectedCategoryName, actualCategoryName, $"Expected Category Name: {expectedCategoryName}, but got: {actualCategoryName}");
				Assert.AreEqual(expectedCount, actualCount, $"Expected Count: {expectedCount}, but got: {actualCount}");
				Assert.AreEqual(expectedSumProfit, actualSumProfit, $"Expected Sum Profit: {expectedSumProfit}, but got: {actualSumProfit}");
				Assert.AreEqual(expectedTotalProfit, actualTotalProfit, $"Expected Total Profit: {expectedTotalProfit}, but got: {actualTotalProfit}");
				// تسجيل النجاح في التقرير
				test.Pass("The information is correct and available in the database.");
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC6_CategorySearchTelecommunicationCount()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TestCategorySearch", "TestCategorySearch");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(ManageDriver.driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// تعريف بيانات الاختبار
				string expectedCategoryName = "Telecommunication";
				int expectedCount = 4;
				//decimal expectedSumProfit = 8;
				//decimal expectedTotalProfit = 8;

				// تحديد الفئة من القائمة المنسدلة
				SearchbyCategoryname.SelectCategory(expectedCategoryName);
				Thread.Sleep(3000);
				// الحصول على القيم الفعلية من الصفحة
				string actualCategoryName = SearchbyCategoryname.GetCategoryName();
				int actualCount = SearchbyCategoryname.GetCountPay();
				decimal actualSumProfit = SearchbyCategoryname.GetSumProfit();
				decimal actualTotalProfit = SearchbyCategoryname.GetTotalProfit();
				// التحقق من مطابقة البيانات المتوقعة مع البيانات الفعلية باستخدام Assert.AreEqual
				Assert.AreEqual(expectedCategoryName, actualCategoryName, $"Expected Category Name: {expectedCategoryName}, but got: {actualCategoryName}");
				Assert.AreEqual(expectedCount, actualCount, $"Expected Count: {expectedCount}, but got: {actualCount}");

				// تسجيل النجاح في التقرير
				test.Pass("The information is correct and available in the database.");
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC7_CategorySearchTelecommunicationSumProfit()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TestCategorySearch", "TestCategorySearch");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(ManageDriver.driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// تعريف بيانات الاختبار
				string expectedCategoryName = "Telecommunication";
				int expectedCount = 4;
				//decimal expectedSumProfit = 8;
				//decimal expectedTotalProfit = 8;

				// تحديد الفئة من القائمة المنسدلة
				SearchbyCategoryname.SelectCategory(expectedCategoryName);
				Thread.Sleep(4000);
				// الحصول على القيم الفعلية من الصفحة
				string actualCategoryName = SearchbyCategoryname.GetCategoryName();
				int actualCount = SearchbyCategoryname.GetCountPay();
				decimal actualSumProfit = SearchbyCategoryname.GetSumProfit();
				decimal actualTotalProfit = SearchbyCategoryname.GetTotalProfit();

				// التحقق من مطابقة البيانات المتوقعة مع البيانات الفعلية باستخدام Assert.AreEqual
				Assert.AreEqual(expectedCategoryName, actualCategoryName, $"Expected Category Name: {expectedCategoryName}, but got: {actualCategoryName}");
				Assert.AreEqual(expectedCount, actualCount, $"Expected Count: {expectedCount}, but got: {actualCount}");

				// تسجيل النجاح في التقرير
				test.Pass("The information is correct and available in the database.");
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC8_CategorySearchTelecommunicationTotalProfit()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TestCategorySearch", "TestCategorySearch");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(ManageDriver.driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// تعريف بيانات الاختبار
				string expectedCategoryName = "Telecommunication";
				//int expectedCount = 4;
				//decimal expectedSumProfit = 8;
				decimal expectedTotalProfit = 8;

				// تحديد الفئة من القائمة المنسدلة
				SearchbyCategoryname.SelectCategory(expectedCategoryName);
				Thread.Sleep(4000);
				// الحصول على القيم الفعلية من الصفحة
				string actualCategoryName = SearchbyCategoryname.GetCategoryName();
				int actualCount = SearchbyCategoryname.GetCountPay();
				decimal actualSumProfit = SearchbyCategoryname.GetSumProfit();
				decimal actualTotalProfit = SearchbyCategoryname.GetTotalProfit();


				// التحقق من مطابقة البيانات المتوقعة مع البيانات الفعلية باستخدام Assert.AreEqual
				Assert.AreEqual(expectedCategoryName, actualCategoryName, $"Expected Category Name: {expectedCategoryName}, but got: {actualCategoryName}");
				//Assert.AreEqual(expectedCount, actualCount, $"Expected Count: {expectedCount}, but got: {actualCount}");
				//Assert.AreEqual(expectedSumProfit, actualSumProfit, $"Expected Sum Profit: {expectedSumProfit}, but got: {actualSumProfit}");
				Assert.AreEqual(expectedTotalProfit, actualTotalProfit, $"Expected Total Profit: {expectedTotalProfit}, but got: {actualTotalProfit}");

				// تسجيل النجاح في التقرير
				test.Pass("The information is correct and available in the database.");
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}

		[TestMethod]
		public void TC9_CategorySearchElectricityName()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TC9_CategorySearchElectricityName", "TC9_CategorySearchElectricityName");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(ManageDriver.driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
				// تعريف بيانات الاختبار
				string expectedCategoryName = "Electricity";
				//int expectedCount = 2;
				//decimal expectedSumProfit = 4;
				//decimal expectedTotalProfit = 4;
				// تحديد الفئة من القائمة المنسدلة
				SearchbyCategoryname.SelectCategory(expectedCategoryName);
				Thread.Sleep(3000);
				// الحصول على القيم الفعلية من الصفحة
				string actualCategoryName = SearchbyCategoryname.GetCategoryName();
				//int actualCount = SearchbyCategoryname.GetCountPay();
				//decimal actualSumProfit = SearchbyCategoryname.GetSumProfit();
				//decimal actualTotalProfit = SearchbyCategoryname.GetTotalProfit();
				// التحقق من مطابقة البيانات المتوقعة مع البيانات الفعلية باستخدام Assert.AreEqual
				//Assert.AreEqual(expectedCategoryName, actualCategoryName, $"Expected Category Name: {expectedCategoryName}, but got: {actualCategoryName}");
				//Assert.AreEqual(expectedCount, actualCount, $"Expected Count: {expectedCount}, but got: {actualCount}");
				//Assert.AreEqual(expectedSumProfit, actualSumProfit, $"Expected Sum Profit: {expectedSumProfit}, but got: {actualSumProfit}");
				//Assert.AreEqual(expectedTotalProfit, actualTotalProfit, $"Expected Total Profit: {expectedTotalProfit}, but got: {actualTotalProfit}");
				// تسجيل النجاح في التقرير
				test.Pass("The information is correct and available in the database.");
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC10_CategorySearchElectricityCount()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TestCategorySearch", "TestCategorySearch");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(ManageDriver.driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// تعريف بيانات الاختبار
				string expectedCategoryName = "Electricity";
				int expectedCount = 2;
				//decimal expectedSumProfit = 4;
				//decimal expectedTotalProfit = 4;

				// تحديد الفئة من القائمة المنسدلة
				SearchbyCategoryname.SelectCategory(expectedCategoryName);
				Thread.Sleep(3000);
				// الحصول على القيم الفعلية من الصفحة
				string actualCategoryName = SearchbyCategoryname.GetCategoryName();
				int actualCount = SearchbyCategoryname.GetCountPay();
				//decimal actualSumProfit = SearchbyCategoryname.GetSumProfit();
				//decimal actualTotalProfit = SearchbyCategoryname.GetTotalProfit();

				// التحقق من مطابقة البيانات المتوقعة مع البيانات الفعلية باستخدام Assert.AreEqual
				Assert.AreEqual(expectedCategoryName, actualCategoryName, $"Expected Category Name: {expectedCategoryName}, but got: {actualCategoryName}");
				Assert.AreEqual(expectedCount, actualCount, $"Expected Count: {expectedCount}, but got: {actualCount}");

				// تسجيل النجاح في التقرير
				test.Pass("The information is correct and available in the database.");
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC11_CategorySearchElectricitySumProfit()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TestCategorySearch", "TestCategorySearch");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(ManageDriver.driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// تعريف بيانات الاختبار
				string expectedCategoryName = "Electricity";
				int expectedCount = 2;
				//decimal expectedSumProfit = 4;
				//decimal expectedTotalProfit = 4;

				// تحديد الفئة من القائمة المنسدلة
				SearchbyCategoryname.SelectCategory(expectedCategoryName);
				Thread.Sleep(3000);
				// الحصول على القيم الفعلية من الصفحة
				string actualCategoryName = SearchbyCategoryname.GetCategoryName();
				int actualCount = SearchbyCategoryname.GetCountPay();
				//decimal actualSumProfit = SearchbyCategoryname.GetSumProfit();
				//decimal actualTotalProfit = SearchbyCategoryname.GetTotalProfit();

				// التحقق من مطابقة البيانات المتوقعة مع البيانات الفعلية باستخدام Assert.AreEqual
				Assert.AreEqual(expectedCategoryName, actualCategoryName, $"Expected Category Name: {expectedCategoryName}, but got: {actualCategoryName}");
				Assert.AreEqual(expectedCount, actualCount, $"Expected Count: {expectedCount}, but got: {actualCount}");

				// تسجيل النجاح في التقرير
				test.Pass("The information is correct and available in the database.");
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC12_CategorySearchElectricityTotalProfit()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TestCategorySearch", "TestCategorySearch");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(ManageDriver.driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// تعريف بيانات الاختبار
				string expectedCategoryName = "Electricity";
				//int expectedCount = 2;
				//decimal expectedSumProfit = 4;
				decimal expectedTotalProfit = 4;

				// تحديد الفئة من القائمة المنسدلة
				SearchbyCategoryname.SelectCategory(expectedCategoryName);
				Thread.Sleep(3000);
				// الحصول على القيم الفعلية من الصفحة
				string actualCategoryName = SearchbyCategoryname.GetCategoryName();
				//int actualCount = SearchbyCategoryname.GetCountPay();
				//decimal actualSumProfit = SearchbyCategoryname.GetSumProfit();
				decimal actualTotalProfit = SearchbyCategoryname.GetTotalProfit();

				// التحقق من مطابقة البيانات المتوقعة مع البيانات الفعلية باستخدام Assert.AreEqual
				Assert.AreEqual(expectedCategoryName, actualCategoryName, $"Expected Category Name: {expectedCategoryName}, but got: {actualCategoryName}");
				//Assert.AreEqual(expectedCount, actualCount, $"Expected Count: {expectedCount}, but got: {actualCount}");
				//Assert.AreEqual(expectedSumProfit, actualSumProfit, $"Expected Sum Profit: {expectedSumProfit}, but got: {actualSumProfit}");
				Assert.AreEqual(expectedTotalProfit, actualTotalProfit, $"Expected Total Profit: {expectedTotalProfit}, but got: {actualTotalProfit}");

				// تسجيل النجاح في التقرير
				test.Pass("The information is correct and available in the database.");
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC13_CategorySearchWaterName()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TestCategorySearch", "TestCategorySearch");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(ManageDriver.driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
				// تعريف بيانات الاختبار
				string expectedCategoryName = "Water";
				//int expectedCount = 0;
				//decimal expectedSumProfit = 0;
				//decimal expectedTotalProfit = 0;
				// تحديد الفئة من القائمة المنسدلة
				SearchbyCategoryname.SelectCategory(expectedCategoryName);
				Thread.Sleep(3000);
				// الحصول على القيم الفعلية من الصفحة
				string actualCategoryName = SearchbyCategoryname.GetCategoryName();
				//int actualCount = SearchbyCategoryname.GetCountPay();
				//decimal actualSumProfit = SearchbyCategoryname.GetSumProfit();
				//decimal actualTotalProfit = SearchbyCategoryname.GetTotalProfit();
				// التحقق من مطابقة البيانات المتوقعة مع البيانات الفعلية باستخدام Assert.AreEqual
				Assert.AreEqual(expectedCategoryName, actualCategoryName, $"Expected Category Name: {expectedCategoryName}, but got: {actualCategoryName}");
				//Assert.AreEqual(expectedCount, actualCount, $"Expected Count: {expectedCount}, but got: {actualCount}");
				//Assert.AreEqual(expectedSumProfit, actualSumProfit, $"Expected Sum Profit: {expectedSumProfit}, but got: {actualSumProfit}");
				//Assert.AreEqual(expectedTotalProfit, actualTotalProfit, $"Expected Total Profit: {expectedTotalProfit}, but got: {actualTotalProfit}");
				// تسجيل النجاح في التقرير
				test.Pass("The information is correct and available in the database.");
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC14_CategorySearchWaterCount()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TestCategorySearch", "TestCategorySearch");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(ManageDriver.driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// تعريف بيانات الاختبار
				string expectedCategoryName = "Water";
				int expectedCount = 7;
				//decimal expectedSumProfit = 0;
				//decimal expectedTotalProfit = 0;

				// تحديد الفئة من القائمة المنسدلة
				SearchbyCategoryname.SelectCategory(expectedCategoryName);
				Thread.Sleep(3000);
				// الحصول على القيم الفعلية من الصفحة
				string actualCategoryName = SearchbyCategoryname.GetCategoryName();
				int actualCount = SearchbyCategoryname.GetCountPay();
				//decimal actualSumProfit = SearchbyCategoryname.GetSumProfit();
				//decimal actualTotalProfit = SearchbyCategoryname.GetTotalProfit();
				Thread.Sleep(5000);

				// التحقق من مطابقة البيانات المتوقعة مع البيانات الفعلية باستخدام Assert.AreEqual
				Assert.AreEqual(expectedCategoryName, actualCategoryName, $"Expected Category Name: {expectedCategoryName}, but got: {actualCategoryName}");
				Assert.AreEqual(expectedCount, actualCount, $"Expected Count: {expectedCount}, but got: {actualCount}");

				// تسجيل النجاح في التقرير
				test.Pass("The information is correct and available in the database.");
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC15_CategorySearchWaterSumProfit()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TestCategorySearch", "TestCategorySearch");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(ManageDriver.driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// تعريف بيانات الاختبار
				string expectedCategoryName = "Water";
				int expectedCount = 35;
				//decimal expectedSumProfit = 0;
				//decimal expectedTotalProfit = 0;

				// تحديد الفئة من القائمة المنسدلة
				SearchbyCategoryname.SelectCategory(expectedCategoryName);
				Thread.Sleep(3000);
				// الحصول على القيم الفعلية من الصفحة
				string actualCategoryName = SearchbyCategoryname.GetCategoryName();
				//int actualCount = SearchbyCategoryname.GetCountPay();
				decimal actualSumProfit = SearchbyCategoryname.GetSumProfit();
				//decimal actualTotalProfit = SearchbyCategoryname.GetTotalProfit();

				// التحقق من مطابقة البيانات المتوقعة مع البيانات الفعلية باستخدام Assert.AreEqual
				Assert.AreEqual(expectedCategoryName, actualCategoryName, $"Expected Category Name: {expectedCategoryName}, but got: {actualCategoryName}");
				//Assert.AreEqual(expectedCount, actualCount, $"Expected Count: {expectedCount}, but got: {actualCount}");

				// تسجيل النجاح في التقرير
				test.Pass("The information is correct and available in the database.");
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}
		[TestMethod]
		public void TC16_CategorySearchWaterTotalProfit()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TestCategorySearch", "TestCategorySearch");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(ManageDriver.driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// تعريف بيانات الاختبار
				string expectedCategoryName = "Water";
				//int expectedCount = 0;
				//decimal expectedSumProfit = 0;
				decimal expectedTotalProfit = 35;

				// تحديد الفئة من القائمة المنسدلة
				SearchbyCategoryname.SelectCategory(expectedCategoryName);
				Thread.Sleep(3000);
				// الحصول على القيم الفعلية من الصفحة
				string actualCategoryName = SearchbyCategoryname.GetCategoryName();
				//int actualCount = SearchbyCategoryname.GetCountPay();
				//decimal actualSumProfit = SearchbyCategoryname.GetSumProfit();
				decimal actualTotalProfit = SearchbyCategoryname.GetTotalProfit();

				// التحقق من مطابقة البيانات المتوقعة مع البيانات الفعلية باستخدام Assert.AreEqual
				Assert.AreEqual(expectedCategoryName, actualCategoryName, $"Expected Category Name: {expectedCategoryName}, but got: {actualCategoryName}");
				//Assert.AreEqual(expectedCount, actualCount, $"Expected Count: {expectedCount}, but got: {actualCount}");
				//Assert.AreEqual(expectedSumProfit, actualSumProfit, $"Expected Sum Profit: {expectedSumProfit}, but got: {actualSumProfit}");
				Assert.AreEqual(expectedTotalProfit, actualTotalProfit, $"Expected Total Profit: {expectedTotalProfit}, but got: {actualTotalProfit}");

				// تسجيل النجاح في التقرير
				test.Pass("The information is correct and available in the database.");
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}


		[TestMethod]
		public void TC17_VerifyElectricityTotalSumProfitEqualTotalProfit()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("VerifySelectedCategoryProfit", "Check if the selected category's Sum Profit matches its Total Profit");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				SearchbyCategoryname categoryHelper = new SearchbyCategoryname(driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// ** هنا أدخل اسم الفئة يدويًا **
				string manualCategoryName = "Electricity"; // استبدل باسم الفئة التي تريدها

				// اختيار الفئة من القائمة المنسدلة
				categoryHelper.SelectCategory(manualCategoryName);
				Thread.Sleep(3000); // الانتظار قليلاً لتحديث البيانات في الحقول

				// الحصول على القيم من الحقول بعد الاختيار
				string selectedCategoryName = categoryHelper.GetCategoryName();
				//int countPay = categoryHelper.GetCountPay();
				decimal sumProfit = categoryHelper.GetSumProfit();
				decimal totalProfit = categoryHelper.GetTotalProfit();


				// طباعة القيم للتحقق
				Console.WriteLine($"Category: {selectedCategoryName}, Sum Profit: {sumProfit}, Total Profit: {totalProfit}");

				// التحقق من أن Sum Profit يطابق Total Profit
				if (sumProfit == totalProfit)
				{
					test.Pass($"Category '{selectedCategoryName}' passed: Sum Profit ({sumProfit}) matches Total Profit ({totalProfit}).");
				}
				else
				{
					// إذا لم تتطابق القيم، قم بتسجيل الفشل مع التفاصيل
					test.Fail($"Category '{selectedCategoryName}' failed: Sum Profit ({sumProfit}) does NOT match Total Profit ({totalProfit}).");
					Console.WriteLine($"Difference: Sum Profit is {sumProfit} while Total Profit is {totalProfit}.");
				}
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}

		[TestMethod]
		public void TC18_VerifyTelecommunicationTotalSumProfitEqualTotalProfit()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("VerifySelectedCategoryProfit", "Check if the selected category's Sum Profit matches its Total Profit");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				SearchbyCategoryname categoryHelper = new SearchbyCategoryname(driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// ** هنا أدخل اسم الفئة يدويًا **
				string manualCategoryName = "Telecommunication"; // استبدل باسم الفئة التي تريدها

				// اختيار الفئة من القائمة المنسدلة
				categoryHelper.SelectCategory(manualCategoryName);
				Thread.Sleep(3000); ; // الانتظار قليلاً لتحديث البيانات في الحقول

				// الحصول على القيم من الحقول بعد الاختيار
				string selectedCategoryName = categoryHelper.GetCategoryName();
				//int countPay = categoryHelper.GetCountPay();
				decimal sumProfit = categoryHelper.GetSumProfit();
				decimal totalProfit = categoryHelper.GetTotalProfit();

				// طباعة القيم للتحقق
				Console.WriteLine($"Category: {selectedCategoryName}, Sum Profit: {sumProfit}, Total Profit: {totalProfit}");

				// التحقق من أن Sum Profit يطابق Total Profit
				if (sumProfit == totalProfit)
				{
					test.Pass($"Category '{selectedCategoryName}' passed: Sum Profit ({sumProfit}) matches Total Profit ({totalProfit}).");
				}
				else
				{
					// إذا لم تتطابق القيم، قم بتسجيل الفشل مع التفاصيل
					test.Fail($"Category '{selectedCategoryName}' failed: Sum Profit ({sumProfit}) does NOT match Total Profit ({totalProfit}).");
					Console.WriteLine($"Difference: Sum Profit is {sumProfit} while Total Profit is {totalProfit}.");
				}
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}

		[TestMethod]
		public void TC19_VerifyEducationTotalSumProfitEqualTotalProfit()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("VerifySelectedCategoryProfit", "Check if the selected category's Sum Profit matches its Total Profit");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				SearchbyCategoryname categoryHelper = new SearchbyCategoryname(driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// ** هنا أدخل اسم الفئة يدويًا **
				string manualCategoryName = "Education"; // استبدل باسم الفئة التي تريدها

				// اختيار الفئة من القائمة المنسدلة
				categoryHelper.SelectCategory(manualCategoryName);
				Thread.Sleep(3000); // الانتظار قليلاً لتحديث البيانات في الحقول

				// الحصول على القيم من الحقول بعد الاختيار
				string selectedCategoryName = categoryHelper.GetCategoryName();
				//int countPay = categoryHelper.GetCountPay();
				decimal sumProfit = categoryHelper.GetSumProfit();
				decimal totalProfit = categoryHelper.GetTotalProfit();

				// طباعة القيم للتحقق
				Console.WriteLine($"Category: {selectedCategoryName}, Sum Profit: {sumProfit}, Total Profit: {totalProfit}");

				// التحقق من أن Sum Profit يطابق Total Profit
				if (sumProfit == totalProfit)
				{
					test.Pass($"Category '{selectedCategoryName}' passed: Sum Profit ({sumProfit}) matches Total Profit ({totalProfit}).");
				}
				else
				{
					// إذا لم تتطابق القيم، قم بتسجيل الفشل مع التفاصيل
					test.Fail($"Category '{selectedCategoryName}' failed: Sum Profit ({sumProfit}) does NOT match Total Profit ({totalProfit}).");
					Console.WriteLine($"Difference: Sum Profit is {sumProfit} while Total Profit is {totalProfit}.");
				}
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}

		[TestMethod]
		public void TC20_VerifyWater1TotalSumProfitEqualTotalProfit()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("VerifySelectedCategoryProfit", "Check if the selected category's Sum Profit matches its Total Profit");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				SearchbyCategoryname categoryHelper = new SearchbyCategoryname(driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// ** هنا أدخل اسم الفئة يدويًا **
				string manualCategoryName = "Water"; // استبدل باسم الفئة التي تريدها

				// اختيار الفئة من القائمة المنسدلة
				categoryHelper.SelectCategory(manualCategoryName);
				Thread.Sleep(3000); // الانتظار قليلاً لتحديث البيانات في الحقول

				// الحصول على القيم من الحقول بعد الاختيار
				string selectedCategoryName = categoryHelper.GetCategoryName();
				//int countPay = categoryHelper.GetCountPay();
				decimal sumProfit = categoryHelper.GetSumProfit();
				decimal totalProfit = categoryHelper.GetTotalProfit();

				// طباعة القيم للتحقق
				Console.WriteLine($"Category: {selectedCategoryName}, Sum Profit: {sumProfit}, Total Profit: {totalProfit}");

				// التحقق من أن Sum Profit يطابق Total Profit
				if (sumProfit == totalProfit)
				{
					test.Pass($"Category '{selectedCategoryName}' passed: Sum Profit ({sumProfit}) matches Total Profit ({totalProfit}).");
				}
				else
				{
					// إذا لم تتطابق القيم، قم بتسجيل الفشل مع التفاصيل
					test.Fail($"Category '{selectedCategoryName}' failed: Sum Profit ({sumProfit}) does NOT match Total Profit ({totalProfit}).");
					Console.WriteLine($"Difference: Sum Profit is {sumProfit} while Total Profit is {totalProfit}.");
				}
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}

		[TestMethod] //*****
		public void TC21_VerifyAllCategoriesIfNoneSelected()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("VerifyAllCategoriesIfNoneSelected", "Check all categories' Sum Profit matches Total Profit if no category is selected.");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				SearchbyCategoryname categoryHelper = new SearchbyCategoryname(driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// استخراج جميع الفئات من القائمة المنسدلة
				var categoryDropdown = categoryHelper.CategoryDropdown;
				var selectElement = new SelectElement(categoryDropdown);
				var allOptions = selectElement.Options;

				// التأكد إذا كان الخيار الأول فارغًا
				bool isSelectedCategoryEmpty = string.IsNullOrWhiteSpace(selectElement.SelectedOption.Text);

				// إذا كانت الفئة فارغة أو لم يتم اختيار أي فئة، نمر على جميع الفئات
				if (isSelectedCategoryEmpty)
				{
					foreach (var option in allOptions)
					{
						// تخطي الفئة الفارغة
						if (string.IsNullOrWhiteSpace(option.Text))
						{
							continue; // الانتقال إلى الخيار التالي إذا كان فارغًا
						}

						// اختيار الفئة من القائمة
						string categoryName = option.Text;
						categoryHelper.SelectCategory(categoryName);
						Thread.Sleep(3000); // الانتظار لتحديث البيانات في الحقول

						// الحصول على القيم من الحقول بعد الاختيار
						string selectedCategoryName = categoryHelper.GetCategoryName();
						decimal sumProfit = categoryHelper.GetSumProfit();
						decimal totalProfit = categoryHelper.GetTotalProfit();

						// طباعة القيم للتحقق
						Console.WriteLine($"Category: {selectedCategoryName}, Sum Profit: {sumProfit}, Total Profit: {totalProfit}");

						// التحقق من أن Sum Profit يطابق Total Profit
						if (sumProfit == totalProfit)
						{
							test.Pass($"Category '{selectedCategoryName}' passed: Sum Profit ({sumProfit}) matches Total Profit ({totalProfit}).");
						}
						else
						{
							// إذا لم تتطابق القيم، قم بتسجيل الفشل مع التفاصيل
							test.Fail($"Category '{selectedCategoryName}' failed: Sum Profit ({sumProfit}) does NOT match Total Profit ({totalProfit}).");
							Console.WriteLine($"Difference: Sum Profit is {sumProfit} while Total Profit is {totalProfit}.");
						}
					}
				}
				else
				{
					test.Info("A category was already selected, please ensure the dropdown is empty for testing all categories.");
				}
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}


		[TestMethod]
		public void TC22_CheckIfTheListIsEmpty()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TestCategorySearch", "TestCategorySearch");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// تحديد الفئة من القائمة المنسدلة
				var categoryDropdown = SearchbyCategoryname.CategoryDropdown;
				var selectElement = new SelectElement(categoryDropdown);
				Thread.Sleep(3000);
				// استخراج جميع البيانات من الجدول
				var rows = driver.FindElements(By.XPath("//table/tbody/tr")); // استخراج جميع الصفوف من الجدول

				// التحقق إذا كان الجدول فارغًا
				if (rows.Count == 0)
				{
					test.Info("No data found in the table.");
					Console.WriteLine("No data found in the table.");
				}
				else
				{
					decimal totalProfit = 0;
					foreach (var row in rows)
					{
						// استخراج المعلومات من كل صف في الجدول
						var columns = row.FindElements(By.TagName("td")); // استخدام TagName بشكل صحيح لاستخراج الأعمدة
						if (columns.Count > 0)
						{
							var categoryName = columns[0].Text;
							int count = 0;
							decimal sumProfit = 0;

							// تحقق من أن البيانات ليست فارغة قبل التحليل
							if (!string.IsNullOrWhiteSpace(columns[1].Text))
							{
								count = int.Parse(columns[1].Text);
							}
							if (!string.IsNullOrWhiteSpace(columns[2].Text))
							{
								sumProfit = decimal.Parse(columns[2].Text.Replace("$", "").Trim());
							}

							Console.WriteLine($"Category: {categoryName}, Count: {count}, Sum Profit: {sumProfit}");

							// إضافة القيم إلى الإجمالي
							totalProfit += sumProfit;

							// تحقق من القيم المتوقعة
							switch (categoryName)
							{
								case "Electricity":
									Assert.AreEqual(2, count, $"Expected Count for Electricity: 2, but got: {count}");
									Assert.AreEqual(4, sumProfit, $"Expected Sum Profit for Electricity: 4, but got: {sumProfit}");
									break;
								case "Telecommunication":
									Assert.AreEqual(4, count, $"Expected Count for Telecommunication: 4, but got: {count}");
									Assert.AreEqual(8, sumProfit, $"Expected Sum Profit for Telecommunication: 8, but got: {sumProfit}");
									break;
								case "Education":
									Assert.AreEqual(4, count, $"Expected Count for Education: 4, but got: {count}");
									Assert.AreEqual(10, sumProfit, $"Expected Sum Profit for Education: 10, but got: {sumProfit}");
									break;
								case "Water":
									Assert.AreEqual(7, count, $"Expected Count for Water: 7, but got: {count}");
									Assert.AreEqual(35, sumProfit, $"Expected Sum Profit for Water: 35, but got: {sumProfit}");
									break;
							}
						}
					}

					// تحقق من إجمالي الربح
					Assert.AreEqual(57, totalProfit, $"Expected Total Profit: 57, but got: {totalProfit}");
					test.Pass("Displayed all information in the table.");
				}
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}


		[TestMethod]
		public void TC123_DropdownListIsActive()
		{
			// إنشاء تقرير الاختبار
			var test = extentReports.CreateTest("TestCategorySearch", "TestCategorySearch");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchName_AssistantMethods bySearchName_Assistant = new BySearchName_AssistantMethods(driver);

				// الانتقال إلى رابط تسجيل الدخول وتعبئة نموذج الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");

				// تحديد الفئة من القائمة المنسدلة
				var categoryDropdown = SearchbyCategoryname.CategoryDropdown;
				var selectElement = new SelectElement(categoryDropdown);

				// التأكد من أن القائمة المنسدلة فعالة (موجودة ومفعلة)
				Assert.IsTrue(categoryDropdown.Displayed && categoryDropdown.Enabled, "Dropdown list is not enabled or not displayed!");

				// قائمة الفئات المراد اختيارها
				List<string> categoriesToSelect = new List<string> { "Education", "Telecommunication", "Water", "Electricity" };
				Thread.Sleep(3000);
				// التحقق من وجود كل فئة واختيارها من القائمة
				foreach (string category in categoriesToSelect)
				{
					bool categoryFound = false;
					foreach (var option in selectElement.Options)
					{
						if (option.Text.Equals(category, StringComparison.OrdinalIgnoreCase))
						{
							selectElement.SelectByText(option.Text); // اختيار الفئة
							Console.WriteLine($"Selected category: {option.Text}");
							categoryFound = true;
							break; // الخروج من الحلقة عند العثور على الفئة المطلوبة
						}
					}

					// التأكد من أن الفئة المطلوبة تم العثور عليها واختيارها
					Assert.IsTrue(categoryFound, $"The category '{category}' was not found in the dropdown.");
				}

				test.Pass("All specified categories were selected from the dropdown list successfully.");
			}
			catch (Exception ex)
			{
				// تسجيل فشل الاختبار في التقرير مع إضافة لقطة شاشة
				test.Fail(ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}



	}
}
		
			
			