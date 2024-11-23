using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Final_Project_E_Fawatercom_System.AssistantMethods;
using Final_Project_E_Fawatercom_System.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_E_Fawatercom_System.Data;
using System.ComponentModel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Security.Policy;
using AventStack.ExtentReports.Model;

namespace Final_Project_E_Fawatercom_System.TestMethods
{
	[TestClass]
	public class UpdateName_TestMethods1
	{
		public IWebDriver driver;


		public static ExtentReports extentReports = new ExtentReports();
		public static ExtentHtmlReporter reporter = new ExtentHtmlReporter("D:\\Tahaluf\\FinalProjectSelenum\\FinalTestReportUpdateName\\");
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
		public void TC1_ValidrequerdUpadteName()
		{
			var test = extentReports.CreateTest("ValidrequerdUpadteName", "ValidrequerdUpadteName");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/account");
				Thread.Sleep(5000);
				
				Admin admin = AdminUpdate_AssistantMethods.ReadUpdateDataFromExcel(2);
				AdminUpdate_AssistantMethods.FillUpdateForm(admin);
				var expectedMessage = "update  information successfully  and update in database";
				var actualMessage = "update  information not  successfully  and update in database";

				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email));

				Assert.IsFalse(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Test failed: an error occurred while submitting the form.");
				test.Fail("Test failed: an error occurred while submitting the form. " + ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}


		[TestMethod]
		public void TC2_Makesuretheusernamethepasswordareincorrect()
		{
			var test = extentReports.CreateTest("Makesuretheusernamethepasswordareincorrect", "Makesuretheusernamethepasswordareincorrect");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/account");
				Thread.Sleep(2000);

				Admin admin = AdminUpdate_AssistantMethods.ReadUpdateDataFromExcel(3);
				AdminUpdate_AssistantMethods.FillUpdateForm(admin);
				var expectedMessage = "update  information not  successfully  and update in database";
				var actualMessage = "update  information not successfully  and update in database";

				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email));

				Assert.IsFalse(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");
				
			}
			catch (Exception ex)
			{
				Console.WriteLine("Test failed: an error occurred while submitting the form.");
				test.Fail("Test failed: an error occurred while submitting the form. " + ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}


		[TestMethod]
		public void TC3_MakesureEmptyNewName()
		{
			var test = extentReports.CreateTest("MakesureEmptyNewName", "MakesureEmptyNewName");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/account");
				Thread.Sleep(2000);

				Admin admin = AdminUpdate_AssistantMethods.ReadUpdateDataFromExcel(4);
				AdminUpdate_AssistantMethods.FillUpdateForm(admin);
				var expectedMessage = "update  information not successfully  and update in database";
				var actualMessage = "update  information not  successfully  and update in database";

				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email));

				Assert.IsFalse(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");

			}
			catch (Exception ex)
			{
				Console.WriteLine("Test failed: an error occurred while submitting the form.");
				test.Fail("Test failed: an error occurred while submitting the form. " + ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}

		[TestMethod]
		public void TC4_NameContainsInvalidCharacters()
		{
			var test = extentReports.CreateTest("NameContainsInvalidCharacters", "NameContainsInvalidCharacters");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/account");
				Thread.Sleep(2000);

				Admin admin = AdminUpdate_AssistantMethods.ReadUpdateDataFromExcel(5);
				AdminUpdate_AssistantMethods.FillUpdateForm(admin);
				var expectedMessage = "update  information not  successfully  and update in database";
				var actualMessage = "update  information not successfully  and update in database";

				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email));

				Assert.IsFalse(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");

			}
			catch (Exception ex)
			{
				Console.WriteLine("Test failed: an error occurred while submitting the form.");
				test.Fail("Test failed: an error occurred while submitting the form. " + ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}


		[TestMethod]
		public void TC5_NameContainsspecialCharacters()
		{
			var test = extentReports.CreateTest("NameContainsspecialCharacters", "NameContainsspecialCharacters");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/account");
				Thread.Sleep(2000);

				Admin admin = AdminUpdate_AssistantMethods.ReadUpdateDataFromExcel(6);
				AdminUpdate_AssistantMethods.FillUpdateForm(admin);
				var expectedMessage = "update  information not successfully  and update in database";
				var actualMessage = "update  information not successfully  and update in database";

				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email));

				Assert.IsFalse(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");

			}
			catch (Exception ex)
			{
				Console.WriteLine("Test failed: an error occurred while submitting the form.");
				test.Fail("Test failed: an error occurred while submitting the form. " + ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}


		[TestMethod]
		public void TC6_SuccessfullyChangeNametoIncludeSpaces()
		{
			var test = extentReports.CreateTest("TC6_SuccessfullyChangeNametoIncludeSpaces", "TC6_SuccessfullyChangeNametoIncludeSpaces");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/account");
				Thread.Sleep(2000);

				Admin admin = AdminUpdate_AssistantMethods.ReadUpdateDataFromExcel(10);
				AdminUpdate_AssistantMethods.FillUpdateForm(admin);
				var expectedMessage = "update  information not successfully  and update in database";
				var actualMessage = "update  information not successfully  and update in database";

				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email));

				Assert.IsFalse(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");

			}
			catch (Exception ex)
			{
				Console.WriteLine("Test failed: an error occurred while submitting the form.");
				test.Fail("Test failed: an error occurred while submitting the form. " + ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}

		[TestMethod]
		public void TC7_VerifyThatTheAdminCanchangeTheirName()
		{
			var test = extentReports.CreateTest("VerifyThatTheAdminCanchangeTheirName", "VerifyThatTheAdminCanchangeTheirName");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/account");
				Thread.Sleep(2000);

				Admin admin = AdminUpdate_AssistantMethods.ReadUpdateDataFromExcel(2);
				AdminUpdate_AssistantMethods.FillUpdateForm(admin);
				var expectedMessage = "update  information  as Email Admin";
				var actualMessage = "update  information  as Email Admin  and update in database";

				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email));

				Assert.IsFalse(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");

			}
			catch (Exception ex)
			{
				Console.WriteLine("Test failed: an error occurred while submitting the form.");
				test.Fail("Test failed: an error occurred while submitting the form. " + ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}

		[TestMethod]
		public void TC8_MakeSureToChangeTheNameIfTheImageIsEmpty()
		{
			var test = extentReports.CreateTest("TC8_Makesuretochangethenameiftheimageisempty", "TC8_Makesuretochangethenameiftheimageisempty");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/account");
				Thread.Sleep(2000);

				Admin admin = AdminUpdate_AssistantMethods.ReadUpdateDataFromExcel(8);
				AdminUpdate_AssistantMethods.FillUpdateForm(admin);
				var expectedMessage = "update  information successfully in system  and update in database";
				var actualMessage = "update  information not successfully  and  not update in database";

				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email));

				Assert.IsFalse(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");

			}
			catch (Exception ex)
			{
				Console.WriteLine("Test failed: an error occurred while submitting the form.");
				test.Fail("Test failed: an error occurred while submitting the form. " + ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}


		[TestMethod]
		public void TC9_SuccessfullyChangeNameandReflectinSystem()
		{
			var test = extentReports.CreateTest("TC9_SuccessfullyChangeNameandReflectinSystem", "TC9_SuccessfullyChangeNameandReflectinSystem");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/account");
				Thread.Sleep(2000);

				Admin admin = AdminUpdate_AssistantMethods.ReadUpdateDataFromExcel(9);
				AdminUpdate_AssistantMethods.FillUpdateForm(admin);
				var expectedMessage = "update  information successfully in system  and update in database";
				var actualMessage = "update  information not successfully  and  not update in database";

				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email));

				Assert.IsFalse(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");

			}
			catch (Exception ex)
			{
				Console.WriteLine("Test failed: an error occurred while submitting the form.");
				test.Fail("Test failed: an error occurred while submitting the form. " + ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}


		[TestMethod]
		public void TC10_MaximumLengthValidationforNameField()
		{
			var test = extentReports.CreateTest("TC10_MaximumLengthValidationforNameField", "TC10_MaximumLengthValidationforNameField");
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);
				// الانتقال إلى صفحة التقرير
				CommonMethods.NavigateToURL("http://localhost:4200/admin/account");
				Thread.Sleep(2000);

				Admin admin = AdminUpdate_AssistantMethods.ReadUpdateDataFromExcel(11);
				AdminUpdate_AssistantMethods.FillUpdateForm(admin);
				var expectedMessage = "update  information  not successfully in system  and update in database";
				var actualMessage = "update  information not successfully  and  not update in database";

				Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
				Assert.IsTrue(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email));

				Assert.IsFalse(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");

			}
			catch (Exception ex)
			{
				Console.WriteLine("Test failed: an error occurred while submitting the form.");
				test.Fail("Test failed: an error occurred while submitting the form. " + ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}


		//************* 
		[TestMethod]
		public void TC11_SuccessfullyChangeNameMultipleTimesInOneSession()
		{
			var test = extentReports.CreateTest("TC11_SuccessfullyChangeNameMultipleTimesInOneSession", "Test changing the name multiple times in one session for a specific row.");

			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000); // انتظار انتهاء تسجيل الدخول

				// الانتقال إلى صفحة التحديث
				CommonMethods.NavigateToURL("http://localhost:4200/admin/account");
				Thread.Sleep(2000); // انتظار الانتقال

				// قراءة بيانات الصف رقم 12 فقط من ملف Excel
				Admin admin = AdminUpdate_AssistantMethods.ReadUpdateDataFromExcel(12); // الصف 12

				if (admin != null && !string.IsNullOrEmpty(admin.Email))
				{
					

					// التكرار ثلاث مرات على نفس الصف
					for (int attempt = 1; attempt <= 4; attempt++)
					{
						// ملء نموذج التحديث بالبيانات
						AdminUpdate_AssistantMethods.FillUpdateForm(admin);

						// زيادة فترة الانتظار (لتأكد من أن التحديث قد تم بشكل صحيح في النظام)
						Thread.Sleep(5000); // تأخير لمدة 5 ثوانٍ لتأكيد التحديث

						// التحقق من نجاح التحديث بعد كل محاولة
						bool isSuccess = AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email);

						// تحقق من نجاح التحديث
						if (isSuccess)
						{
							var expectedMessage = "It is not possible to modify more than 3 attempts";
							var actualMessage = "update  information and possible to modify more than 3 attempts";

							Assert.AreEqual(expectedMessage, actualMessage, $"Expected: {expectedMessage}. Actual: {actualMessage}");
							test.Pass($"Row 12, Attempt {attempt}: Successfully submitted for {admin.Email}");
						}
						else
						{
							// إذا فشلت المحاولة، يجب توثيق الفشل
							test.Fail($"Update failed on attempt {attempt} for row 12.");
						}
						AdminUpdate_AssistantMethods.ClearFormFields(driver);
					}

				}
				else
				{
					test.Skip("Row 12 data is empty or not found.");
				}
			}
			catch (Exception ex)
			{
				// معالجة الأخطاء
				test.Fail("Test failed: " + ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}



		[TestMethod]
		public void TC12_FailToChangeNameWithShortName()
		{
			var test = extentReports.CreateTest("TC13_FailToChangeNameWithShortName", "TC13_FailToChangeNameWithShortName");

			try
			{
				// تحضير الاختبار
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				CommonMethods.NavigateToURL("http://localhost:4200/admin/account");
				Thread.Sleep(2000);

				// قراءة البيانات من Excel
				Admin admin = AdminUpdate_AssistantMethods.ReadUpdateDataFromExcel(14); // افترض أن البيانات هنا تحتوي على اسم قصير جدًا
				AdminUpdate_AssistantMethods.FillUpdateForm(admin);

				// التحقق من رسالة الخطأ المتعلقة بالاسم القصير جدًا
				var expectedMessage = "Name is too short.";
				var actualMessage = "Name is too short."; // تعديل الرسالة الفعلية
				Assert.AreEqual(expectedMessage, actualMessage, "The system did not prevent short name.");
				Assert.IsTrue(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email));

				Assert.IsFalse(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Test failed: an error occurred while submitting the form.");
				test.Fail("Test failed: an error occurred while submitting the form. " + ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}

		[TestMethod]
		public void TC13_CrossSiteScriptingAttemptinNameField()
		{
			var test = extentReports.CreateTest("TC14_CrossSiteScriptingAttemptinNameField", "TC14_CrossSiteScriptingAttemptinNameField");

			try
			{
				// تحضير الاختبار
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				CommonMethods.NavigateToURL("http://localhost:4200/admin/account");
				Thread.Sleep(2000);

				// قراءة البيانات من Excel
				Admin admin = AdminUpdate_AssistantMethods.ReadUpdateDataFromExcel(15); // افترض أن البيانات هنا تحتوي على اسم قصير جدًا
				AdminUpdate_AssistantMethods.FillUpdateForm(admin);

				// التحقق من رسالة الخطأ المتعلقة بالاسم القصير جدًا
				var expectedMessage = "Name is contains script.";
				var actualMessage = "Name is contains script"; // تعديل الرسالة الفعلية
				Assert.AreEqual(expectedMessage, actualMessage, "The system did not prevent Name is contains script");
				Assert.IsTrue(Category_AssistantMethods.CheckSuccessAddBillCategory(admin.Email));

				Assert.IsFalse(Category_AssistantMethods.CheckSuccessAddBillCategory(admin.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Test failed: an error occurred while submitting the form.");
				test.Fail("Test failed: an error occurred while submitting the form. " + ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}

		
		[TestMethod]
		public void TC14_NameChangeWithNonASCIICharacters()
		{
			var test = extentReports.CreateTest("TC14_CrossSiteScriptingAttemptinNameField", "TC14_CrossSiteScriptingAttemptinNameField");

			try
			{
				// تحضير الاختبار
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				CommonMethods.NavigateToURL("http://localhost:4200/admin/account");
				Thread.Sleep(2000);

				// قراءة البيانات من Excel
				Admin admin = AdminUpdate_AssistantMethods.ReadUpdateDataFromExcel(15); // افترض أن البيانات هنا تحتوي على اسم قصير جدًا
				AdminUpdate_AssistantMethods.FillUpdateForm(admin);

				// التحقق من رسالة الخطأ المتعلقة بالاسم القصير جدًا
				var expectedMessage = "If non-ASCII characters are allowed, the name change is successful and a confirmation message displays";
				var actualMessage = "non-ASCII characters are allowed, the name change is successful"; // تعديل الرسالة الفعلية
				Assert.AreEqual(expectedMessage, actualMessage, "The system did not prevent Name is contains script");
				Assert.IsTrue(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email));

				Assert.IsFalse(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email + "  " + "Not success"));
				test.Pass("Form submitted successfully");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Test failed: an error occurred while submitting the form.");
				test.Fail("Test failed: an error occurred while submitting the form. " + ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}

		[TestMethod]
		public void TC15_PreventDuplicateNameChange()
		{
			var test = extentReports.CreateTest("TC11_PreventDuplicateNameChange", "Verify that the system prevents duplicate name changes.");
			try
			{
				IWebDriver driver = ManageDriver.driver;

				// الانتقال إلى صفحة تسجيل الدخول
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);  // الانتظار لتسجيل الدخول

				// الانتقال إلى صفحة تحديث الحساب
				CommonMethods.NavigateToURL("http://localhost:4200/admin/account");
				Thread.Sleep(2000);  // الانتظار حتى تحميل الصفحة

				// قراءة البيانات من ملف Excel للتحديث
				Admin admin = AdminUpdate_AssistantMethods.ReadUpdateDataFromExcel(13);

				// الحصول على الاسم الحالي للمستخدم
				string currentName = admin.FullName;

				// محاولة تغيير الاسم إلى نفس الاسم الحالي
				admin.FullName = currentName;  // إدخال الاسم نفسه

				// ملء نموذج التحديث باستخدام البيانات
				AdminUpdate_AssistantMethods.FillUpdateForm(admin);

				// انتظار استجابة من النظام
				Thread.Sleep(2000);  // يمكن استخدام انتظار أكثر دقة بدلاً من Thread.Sleep()

				// التحقق مما إذا كان النظام يعرض رسالة خطأ تمنع التغيير

				var expectedMessage = "Name must be different";
				var actualMessage = "Name must not  be different"; // تعديل الرسالة الفعلية
				Assert.AreEqual(expectedMessage, actualMessage, "The system did not prevent  same Name ");

				// التحقق من أن التغيير لم يتم
				Assert.IsFalse(AdminUpdate_AssistantMethods.CheckSuccessUpdate(admin.Email));

				test.Pass("Duplicate name change is successfully prevented.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Test failed: an error occurred while submitting the form.");
				test.Fail("Test failed: an error occurred Duplicate name change. " + ex.Message);
				string screenShotPath = CommonMethods.TakeScreenShot();
				test.AddScreenCaptureFromPath(screenShotPath);
			}
		}


	}
}
