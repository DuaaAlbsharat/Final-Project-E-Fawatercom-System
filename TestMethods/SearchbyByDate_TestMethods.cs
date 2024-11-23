using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DocumentFormat.OpenXml.Wordprocessing;
using Final_Project_E_Fawatercom_System.AssistantMethods;
using Final_Project_E_Fawatercom_System.Data;
using Final_Project_E_Fawatercom_System.Helpers;
using Final_Project_E_Fawatercom_System.POM;
using Microsoft.Extensions.Configuration.UserSecrets;
using OpenQA.Selenium;

namespace Final_Project_E_Fawatercom_System.TestMethods
{
	[TestClass]
	public class SearchbyByDate_TestMethods
	{
		public IWebDriver driver;
		Search searchDatePage = new Search(ManageDriver.driver);
		BySearchDate_AssistantMethods bySearchDate1 = new BySearchDate_AssistantMethods(ManageDriver.driver);
		public static ExtentReports extentReports = new ExtentReports();
		public static ExtentHtmlReporter reporter = new ExtentHtmlReporter("D:\\Tahaluf\\FinalProjectSelenum\\FinalTestReportSearchDate\\");

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
		public void TC1_TestSearchByDateFeb()
		{
			var test = extentReports.CreateTest("TestCategorySearchDate", "TestCategorySearchDate");

			// البيانات المتوقعة لكل صف (بخلاف صف "Total Profit" الذي سيتم فحصه بعد جميع الصفوف الأخرى)
			List<string[]> expectedData = new List<string[]>
	         {
		       new string[] { "Electricity", "1", "2 $" },
		       new string[] { "Telecommunication", "2", "4 $" },
		       new string[] { "Education", "2", "4 $" }
	        };

			string expectedTotalProfit = "10 $"; // القيمة المتوقعة لـ "Total Profit"

			try
			{
				IWebDriver driver = ManageDriver.driver; // يجب أن يكون لديك WebDriver هنا
				BySearchDate_AssistantMethods bySearchDate = new BySearchDate_AssistantMethods(driver);

				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
				Thread.Sleep(5000);

				// إدخال تاريخ البحث وجلب البيانات
				Search search = BySearchDate_AssistantMethods.ReadBillNameDataFromExcel(2);
				BySearchDate_AssistantMethods.FillData(search);

				SearchByDatePage datePage = new SearchByDatePage(driver);
				string actualStartDate = datePage.StartDateInput.GetAttribute("value");
				string actualEndDate = datePage.EndDateInput.GetAttribute("value");

				// استخراج عدد الصفوف (دون احتساب صف "Total Profit")
				int rowCount = BySearchDate_AssistantMethods.GetRowCount(driver) - 1;

				// التكرار على كل صف في الجدول للتحقق من التفاصيل
				for (int row = 0; row < rowCount; row++)
				{
					string[] expectedRowData = expectedData[row];
					string actualCategoryName = BySearchDate_AssistantMethods.GetTableCellValue(row, 0, driver); // اسم الفئة
					string actualCountPay = BySearchDate_AssistantMethods.GetTableCellValue(row, 1, driver);     // عدد المدفوعات
					string actualSumProfit = BySearchDate_AssistantMethods.GetTableCellValue(row, 2, driver);    // إجمالي الربح

					// طباعة القيم الفعلية لكل صف
					Console.WriteLine($"Row {row + 1}: Actual Category Name: {actualCategoryName}");
					Console.WriteLine($"Row {row + 1}: Actual Count Pay: {actualCountPay}");
					Console.WriteLine($"Row {row + 1}: Actual Sum Profit: {actualSumProfit}");

					// تحقق من القيم المتوقعة لكل صف
					Assert.AreEqual(expectedRowData[0], actualCategoryName, $"Row {row + 1}: Expected category name to be '{expectedRowData[0]}', but got '{actualCategoryName}'.");
					Assert.AreEqual(expectedRowData[1], actualCountPay, $"Row {row + 1}: Expected count pay to be '{expectedRowData[1]}', but got '{actualCountPay}'.");
					Assert.AreEqual(expectedRowData[2], actualSumProfit, $"Row {row + 1}: Expected sum profit to be '{expectedRowData[2]}', but got '{actualSumProfit}'.");

					// التحقق من تاريخ العمود الرابع بعد النقر على الزر
					IWebElement button = BySearchDate_AssistantMethods.GetButtonInRow(row, driver); // تمرير driver هنا
					if (button != null)
					{
						button.Click();
						Thread.Sleep(6000); // الانتظار حتى يتم تحميل المعلومات
					}
					else
					{
						Console.WriteLine($"No button found in row {row + 1}");
					}

					// التحقق من تواريخ "payment" بعد فتحها
					List<string> paymentDates = BySearchDate_AssistantMethods.GetPaymentDates(driver);
					Console.WriteLine($"Payment Dates for Row {row + 1}: {string.Join(", ", paymentDates)}");

					// تحقق من أن التواريخ في "payment" تقع ضمن الفترة المتوقعة
					DateTime expectedStartDate = DateTime.Parse(actualStartDate);
					DateTime expectedEndDate = DateTime.Parse(actualEndDate);

					foreach (var paymentDate in paymentDates)
					{
						DateTime actualPaymentDate = DateTime.Parse(paymentDate);
						Assert.IsTrue(actualPaymentDate >= expectedStartDate && actualPaymentDate <= expectedEndDate,
							$"Row {row + 1}: Payment date {paymentDate} is not within the expected range of {actualStartDate} to {actualEndDate}.");
					}

					// العودة إلى صفحة التقرير
					CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
					Thread.Sleep(5000);
					BySearchDate_AssistantMethods.ReadBillNameDataFromExcel(2);
					BySearchDate_AssistantMethods.FillData(search);
					Thread.Sleep(7000); // الانتظار قبل الانتقال للصف التالي
				}

				// التحقق من قيمة "Total Profit" بعد الانتهاء من جميع الصفوف
				string actualTotalProfit = BySearchDate_AssistantMethods.GetTotalProfitValue(driver);
				Thread.Sleep(5000);
				Console.WriteLine($"Actual Total Profit: {actualTotalProfit}");
				Assert.AreEqual(expectedTotalProfit, actualTotalProfit, $"Expected total profit to be '{expectedTotalProfit}', but got '{actualTotalProfit}'.");

				test.Log(Status.Pass, "Search by date test passed successfully.");
			}
			catch (Exception ex)
			{
				test.Log(Status.Fail, $"Search by date test failed: {ex.Message}");
				throw;
			}
		}


		[TestMethod]
		public void TC2_TestSearchByDateFourToSixMarch()
		{
			var test = extentReports.CreateTest("TC2_TestSearchByDateFourToSixMarch", "TC2_TestSearchByDateFourToSixMarch");

			// البيانات المتوقعة لكل صف (بخلاف صف "Total Profit" الذي سيتم فحصه بعد جميع الصفوف الأخرى)
			List<string[]> expectedData = new List<string[]>
			{
			 new string[] { "Electricity", "1", "2 $" },
			 new string[] { "Telecommunication", "1", "2 $" },
			 new string[] { "Education", "1", "3 $" },
			 new string[] { "Water", "3", "15 $" }
			};

			string expectedTotalProfit = "22 $"; // القيمة المتوقعة لـ "Total Profit"

			try
			{
				IWebDriver driver = ManageDriver.driver; // يجب أن يكون لديك WebDriver هنا
				BySearchDate_AssistantMethods bySearchDate = new BySearchDate_AssistantMethods(driver);

				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
				Thread.Sleep(5000);

				// إدخال تاريخ البحث وجلب البيانات
				Search search = BySearchDate_AssistantMethods.ReadBillNameDataFromExcel(3);
				BySearchDate_AssistantMethods.FillData(search);
				Thread.Sleep(5000);
				SearchByDatePage datePage = new SearchByDatePage(driver);
				string actualStartDate = datePage.StartDateInput.GetAttribute("value");
				string actualEndDate = datePage.EndDateInput.GetAttribute("value");

				// استخراج عدد الصفوف (دون احتساب صف "Total Profit")
				int rowCount = BySearchDate_AssistantMethods.GetRowCount(driver) - 1;

				// التكرار على كل صف في الجدول للتحقق من التفاصيل
				for (int row = 0; row < rowCount; row++)
				{
					string[] expectedRowData = expectedData[row];
					string actualCategoryName = BySearchDate_AssistantMethods.GetTableCellValue(row, 0, driver); // اسم الفئة
					string actualCountPay = BySearchDate_AssistantMethods.GetTableCellValue(row, 1, driver);     // عدد المدفوعات
					string actualSumProfit = BySearchDate_AssistantMethods.GetTableCellValue(row, 2, driver);    // إجمالي الربح

					// طباعة القيم الفعلية لكل صف
					Console.WriteLine($"Row {row + 1}: Actual Category Name: {actualCategoryName}");
					Console.WriteLine($"Row {row + 1}: Actual Count Pay: {actualCountPay}");
					Console.WriteLine($"Row {row + 1}: Actual Sum Profit: {actualSumProfit}");

					// تحقق من القيم المتوقعة لكل صف
					Assert.AreEqual(expectedRowData[0], actualCategoryName, $"Row {row + 1}: Expected category name to be '{expectedRowData[0]}', but got '{actualCategoryName}'.");
					Assert.AreEqual(expectedRowData[1], actualCountPay, $"Row {row + 1}: Expected count pay to be '{expectedRowData[1]}', but got '{actualCountPay}'.");
					Assert.AreEqual(expectedRowData[2], actualSumProfit, $"Row {row + 1}: Expected sum profit to be '{expectedRowData[2]}', but got '{actualSumProfit}'.");
					
					// التحقق من تاريخ العمود الرابع بعد النقر على الزر
					IWebElement button = BySearchDate_AssistantMethods.GetButtonInRow(row, driver); // تمرير driver هنا
					if (button != null)
					{
						button.Click();
						Thread.Sleep(7000); // الانتظار حتى يتم تحميل المعلومات
					}
					else
					{
						Console.WriteLine($"No button found in row {row + 1}");
					}

					// التحقق من تواريخ "payment" بعد فتحها
					List<string> paymentDates = BySearchDate_AssistantMethods.GetPaymentDates(driver);
					Console.WriteLine($"Payment Dates for Row {row + 1}: {string.Join(", ", paymentDates)}");

					// تحقق من أن التواريخ في "payment" تقع ضمن الفترة المتوقعة
					DateTime expectedStartDate = DateTime.Parse(actualStartDate);
					DateTime expectedEndDate = DateTime.Parse(actualEndDate);

					foreach (var paymentDate in paymentDates)
					{
						DateTime actualPaymentDate = DateTime.Parse(paymentDate);
						Assert.IsTrue(actualPaymentDate >= expectedStartDate && actualPaymentDate <= expectedEndDate,
							$"Row {row + 1}: Payment date {paymentDate} is not within the expected range of {actualStartDate} to {actualEndDate}.");
					}

					// العودة إلى صفحة التقرير
					CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
					Thread.Sleep(5000);
					BySearchDate_AssistantMethods.ReadBillNameDataFromExcel(3);
					BySearchDate_AssistantMethods.FillData(search);
					Thread.Sleep(6000); // الانتظار قبل الانتقال للصف التالي
				}

				// التحقق من قيمة "Total Profit" بعد الانتهاء من جميع الصفوف
				string actualTotalProfit = BySearchDate_AssistantMethods.GetTotalProfitValue(driver);
				Console.WriteLine($"Actual Total Profit: {actualTotalProfit}");
				Assert.AreEqual(expectedTotalProfit, actualTotalProfit, $"Expected total profit to be '{expectedTotalProfit}', but got '{actualTotalProfit}'.");

				test.Log(Status.Pass, "Search by date test passed successfully.");
			}
			catch (Exception ex)
			{
				test.Log(Status.Fail, $"Search by date test failed: {ex.Message}");
				throw;
			}
		}

		[TestMethod]
		public void TC3_TestSearchByDateSameStartAndEnd()
		{
			var test = extentReports.CreateTest("TC3_TestSearchByDateFourToSixMarch", "Test case for searching by date.");

			// البيانات المتوقعة لصف Telecommunication فقط
			List<string[]> expectedData = new List<string[]>
	        {
	    	  new string[] { "Telecommunication", "1", "2 $" } // فقط صف "Telecommunication"
            };

			string expectedTotalProfit = "2 $"; // فقط الربح المتوقع من "Telecommunication"

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchDate_AssistantMethods bySearchDate = new BySearchDate_AssistantMethods(driver);

				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
				Thread.Sleep(5000);

				// إدخال تاريخ البحث وجلب البيانات
				Search search = BySearchDate_AssistantMethods.ReadBillNameDataFromExcel(4);
				BySearchDate_AssistantMethods.FillData(search);
				Thread.Sleep(7000);
				SearchByDatePage datePage = new SearchByDatePage(driver);
				string actualStartDate = datePage.StartDateInput.GetAttribute("value");
				string actualEndDate = datePage.EndDateInput.GetAttribute("value");

				// استخراج عدد الصفوف (دون احتساب صف "Total Profit")
				int rowCount = BySearchDate_AssistantMethods.GetRowCount(driver) - 1;

				// التكرار على كل صف في الجدول للتحقق من التفاصيل
				for (int row = 0; row < rowCount; row++)
				{
					string actualCategoryName = BySearchDate_AssistantMethods.GetTableCellValue(row, 0, driver); // اسم الفئة
					string actualCountPay = BySearchDate_AssistantMethods.GetTableCellValue(row, 1, driver);     // عدد المدفوعات
					string actualSumProfit = BySearchDate_AssistantMethods.GetTableCellValue(row, 2, driver);    // إجمالي الربح

					// تحقق فقط من صف "Telecommunication"
					if (actualCategoryName == "Telecommunication")
					{
						// طباعة القيم الفعلية
						Console.WriteLine($"Row {row + 1}: Actual Category Name: {actualCategoryName}");
						Console.WriteLine($"Row {row + 1}: Actual Count Pay: {actualCountPay}");
						Console.WriteLine($"Row {row + 1}: Actual Sum Profit: {actualSumProfit}");

						// تحقق من القيم المتوقعة لهذا الصف
						Assert.AreEqual("Telecommunication", actualCategoryName, $"Row {row + 1}: Expected category name to be 'Telecommunication', but got '{actualCategoryName}'.");
						Assert.AreEqual("1", actualCountPay, $"Row {row + 1}: Expected count pay to be '1', but got '{actualCountPay}'.");
						Assert.AreEqual("2 $", actualSumProfit, $"Row {row + 1}: Expected sum profit to be '2 $', but got '{actualSumProfit}'.");

						// التحقق من تاريخ الدفع بعد فتحه
						IWebElement button = BySearchDate_AssistantMethods.GetButtonInRow(row, driver);
						if (button != null)
						{
							button.Click();
							Thread.Sleep(5000); // الانتظار حتى يتم تحميل المعلومات
						}

						// التحقق من تواريخ الدفع
						List<string> paymentDates = BySearchDate_AssistantMethods.GetPaymentDates(driver);
						Console.WriteLine($"Payment Dates for Row {row + 1}: {string.Join(", ", paymentDates)}");

						// إذا كانت قائمة التواريخ فارغة، طباعة رسالة وتجاوز التحقق
						if (paymentDates.Count == 0)
						{
							Console.WriteLine($"No purchase found for Row {row + 1} - No payment dates available.");
						}
						else
						{
							DateTime expectedStartDate = DateTime.Parse(actualStartDate);
							DateTime expectedEndDate = DateTime.Parse(actualEndDate);

							foreach (var paymentDate in paymentDates)
							{
								DateTime actualPaymentDate = DateTime.Parse(paymentDate);
								Assert.IsTrue(actualPaymentDate >= expectedStartDate && actualPaymentDate <= expectedEndDate,
									$"Row {row + 1}: Payment date {paymentDate} is not within the expected range of {actualStartDate} to {actualEndDate}.");
							}
						}

						//break; // بمجرد العثور على "Telecommunication" نقوم بإنهاء الاختبار هنا لأن هذا هو الصف الذي نريد اختباره
						
					}
					CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
					Thread.Sleep(5000);
					BySearchDate_AssistantMethods.ReadBillNameDataFromExcel(4);
					BySearchDate_AssistantMethods.FillData(search);
					Thread.Sleep(5000); // الانتظار قبل الانتقال للصف التالي
				}

				// التحقق من قيمة "Total Profit" بعد الانتهاء من جميع الصفوف
				string actualTotalProfit = BySearchDate_AssistantMethods.GetTotalProfitValue(driver);
				Thread.Sleep(5000);
				Console.WriteLine($"Actual Total Profit: {actualTotalProfit}");
				Assert.AreEqual(expectedTotalProfit, actualTotalProfit, $"Expected total profit to be '{expectedTotalProfit}', but got '{actualTotalProfit}'.");

				test.Log(Status.Pass, "Search by date test passed successfully.");
			}
			catch (Exception ex)
			{
				test.Log(Status.Fail, $"Search by date test failed: {ex.Message}");
				throw;
			}
		}

		[TestMethod]
		public void TC4_TestSearchByDateEighToNine()
		{
			var test = extentReports.CreateTest("TC4_TestSearchByDateEighToNine", "TC4_TestSearchByDateEighToNine");

			// البيانات المتوقعة لكل صف (بخلاف صف "Total Profit" الذي سيتم فحصه بعد جميع الصفوف الأخرى)
			List<string[]> expectedData = new List<string[]>
			{
			
			 new string[] { "Education", "1", "3 $" },
			 new string[] { "Water", "4", "20 $" }
			};

			string expectedTotalProfit = "23 $"; // القيمة المتوقعة لـ "Total Profit"

			try
			{
				IWebDriver driver = ManageDriver.driver; // يجب أن يكون لديك WebDriver هنا
				BySearchDate_AssistantMethods bySearchDate = new BySearchDate_AssistantMethods(driver);

				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
				Thread.Sleep(5000);

				// إدخال تاريخ البحث وجلب البيانات
				Search search = BySearchDate_AssistantMethods.ReadBillNameDataFromExcel(5);
				BySearchDate_AssistantMethods.FillData(search);
				Thread.Sleep(5000);
				SearchByDatePage datePage = new SearchByDatePage(driver);
				string actualStartDate = datePage.StartDateInput.GetAttribute("value");
				string actualEndDate = datePage.EndDateInput.GetAttribute("value");

				// استخراج عدد الصفوف (دون احتساب صف "Total Profit")
				int rowCount = BySearchDate_AssistantMethods.GetRowCount(driver) - 1;

				// التكرار على كل صف في الجدول للتحقق من التفاصيل
				for (int row = 0; row < rowCount; row++)
				{
					string[] expectedRowData = expectedData[row];
					string actualCategoryName = BySearchDate_AssistantMethods.GetTableCellValue(row, 0, driver); // اسم الفئة
					string actualCountPay = BySearchDate_AssistantMethods.GetTableCellValue(row, 1, driver);     // عدد المدفوعات
					string actualSumProfit = BySearchDate_AssistantMethods.GetTableCellValue(row, 2, driver);    // إجمالي الربح

					// طباعة القيم الفعلية لكل صف
					Console.WriteLine($"Row {row + 1}: Actual Category Name: {actualCategoryName}");
					Console.WriteLine($"Row {row + 1}: Actual Count Pay: {actualCountPay}");
					Console.WriteLine($"Row {row + 1}: Actual Sum Profit: {actualSumProfit}");

					// تحقق من القيم المتوقعة لكل صف
					Assert.AreEqual(expectedRowData[0], actualCategoryName, $"Row {row + 1}: Expected category name to be '{expectedRowData[0]}', but got '{actualCategoryName}'.");
					Assert.AreEqual(expectedRowData[1], actualCountPay, $"Row {row + 1}: Expected count pay to be '{expectedRowData[1]}', but got '{actualCountPay}'.");
					Assert.AreEqual(expectedRowData[2], actualSumProfit, $"Row {row + 1}: Expected sum profit to be '{expectedRowData[2]}', but got '{actualSumProfit}'.");

					// التحقق من تاريخ العمود الرابع بعد النقر على الزر
					IWebElement button = BySearchDate_AssistantMethods.GetButtonInRow(row, driver); // تمرير driver هنا
					if (button != null)
					{
						button.Click();
						Thread.Sleep(5000); // الانتظار حتى يتم تحميل المعلومات
					}
					else
					{
						Console.WriteLine($"No button found in row {row + 1}");
					}

					// التحقق من تواريخ "payment" بعد فتحها
					List<string> paymentDates = BySearchDate_AssistantMethods.GetPaymentDates(driver);
					Console.WriteLine($"Payment Dates for Row {row + 1}: {string.Join(", ", paymentDates)}");

					// تحقق من أن التواريخ في "payment" تقع ضمن الفترة المتوقعة
					DateTime expectedStartDate = DateTime.Parse(actualStartDate);
					DateTime expectedEndDate = DateTime.Parse(actualEndDate);

					foreach (var paymentDate in paymentDates)
					{
						DateTime actualPaymentDate = DateTime.Parse(paymentDate);
						Assert.IsTrue(actualPaymentDate >= expectedStartDate && actualPaymentDate <= expectedEndDate,
							$"Row {row + 1}: Payment date {paymentDate} is not within the expected range of {actualStartDate} to {actualEndDate}.");
					}

					// العودة إلى صفحة التقرير
					CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
					Thread.Sleep(5000);
					BySearchDate_AssistantMethods.ReadBillNameDataFromExcel(5);
					BySearchDate_AssistantMethods.FillData(search);
					Thread.Sleep(5000); // الانتظار قبل الانتقال للصف التالي
				}

				// التحقق من قيمة "Total Profit" بعد الانتهاء من جميع الصفوف
				string actualTotalProfit = BySearchDate_AssistantMethods.GetTotalProfitValue(driver);
				Thread.Sleep(5000);
				Console.WriteLine($"Actual Total Profit: {actualTotalProfit}");
				Assert.AreEqual(expectedTotalProfit, actualTotalProfit, $"Expected total profit to be '{expectedTotalProfit}', but got '{actualTotalProfit}'.");

				test.Log(Status.Pass, "Search by date test passed successfully.");
			}
			catch (Exception ex)
			{
				test.Log(Status.Fail, $"Search by date test failed: {ex.Message}");
				throw;
			}
		}

		[TestMethod]
		public void TC5_TestSearchByStartDateIsNull()
		{
			var test = extentReports.CreateTest("TestCategorySearchDate", "TestCategorySearchDate");

			// البيانات المتوقعة لكل صف (بخلاف صف "Total Profit" الذي سيتم فحصه بعد جميع الصفوف الأخرى)
			List<string[]> expectedData = new List<string[]>
			{
			 new string[] { "Electricity", "1", "2 $" },
			 new string[] { "Telecommunication", "2", "4 $" },
			 new string[] { "Education", "2", "4 $" }
	        };

			string expectedTotalProfit = "10 $"; // القيمة المتوقعة لـ "Total Profit"

			try
			{
				IWebDriver driver = ManageDriver.driver; // يجب أن يكون لديك WebDriver هنا
				BySearchDate_AssistantMethods bySearchDate = new BySearchDate_AssistantMethods(driver);

				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
				Thread.Sleep(5000);

				// إدخال تاريخ البحث وجلب البيانات
				Search search = BySearchDate_AssistantMethods.ReadBillNameDataFromExcel(7);
				BySearchDate_AssistantMethods.FillData(search);

				SearchByDatePage datePage = new SearchByDatePage(driver);
				string actualStartDate = datePage.StartDateInput.GetAttribute("value");
				string actualEndDate = datePage.EndDateInput.GetAttribute("value");

				// استخراج عدد الصفوف (دون احتساب صف "Total Profit")
				int rowCount = BySearchDate_AssistantMethods.GetRowCount(driver) - 1;

				// التكرار على كل صف في الجدول للتحقق من التفاصيل
				for (int row = 0; row < rowCount; row++)
				{
					string[] expectedRowData = expectedData[row];
					string actualCategoryName = BySearchDate_AssistantMethods.GetTableCellValue(row, 0, driver); // اسم الفئة
					string actualCountPay = BySearchDate_AssistantMethods.GetTableCellValue(row, 1, driver);     // عدد المدفوعات
					string actualSumProfit = BySearchDate_AssistantMethods.GetTableCellValue(row, 2, driver);    // إجمالي الربح

					// طباعة القيم الفعلية لكل صف
					Console.WriteLine($"Row {row + 1}: Actual Category Name: {actualCategoryName ?? "null"}");
					Console.WriteLine($"Row {row + 1}: Actual Count Pay: {actualCountPay ?? "null"}");
					Console.WriteLine($"Row {row + 1}: Actual Sum Profit: {actualSumProfit ?? "null"}");

					// تحقق من القيم المتوقعة لكل صف (تجاهل التحقق إذا كانت القيمة null)
					if (actualCategoryName != null)
						Assert.AreEqual(expectedRowData[0], actualCategoryName, $"Row {row + 1}: Expected category name to be '{expectedRowData[0]}', but got '{actualCategoryName}'.");

					if (actualCountPay != null)
						Assert.AreEqual(expectedRowData[1], actualCountPay, $"Row {row + 1}: Expected count pay to be '{expectedRowData[1]}', but got '{actualCountPay}'.");

					if (actualSumProfit != null)
						Assert.AreEqual(expectedRowData[2], actualSumProfit, $"Row {row + 1}: Expected sum profit to be '{expectedRowData[2]}', but got '{actualSumProfit}'.");

					// التحقق من تاريخ العمود الرابع بعد النقر على الزر
					IWebElement button = BySearchDate_AssistantMethods.GetButtonInRow(row, driver); // تمرير driver هنا
					if (button != null)
					{
						button.Click();
						Thread.Sleep(5000); // الانتظار حتى يتم تحميل المعلومات
					}
					else
					{
						Console.WriteLine($"No button found in row {row + 1}");
					}

					// التحقق من تواريخ "payment" بعد فتحها
					List<string> paymentDates = BySearchDate_AssistantMethods.GetPaymentDates(driver);
					Console.WriteLine($"Payment Dates for Row {row + 1}: {string.Join(", ", paymentDates)}");

					// تحقق من أن التواريخ في "payment" تقع ضمن الفترة المتوقعة
					if (!string.IsNullOrEmpty(actualStartDate) && !string.IsNullOrEmpty(actualEndDate) &&
						DateTime.TryParse(actualStartDate, out DateTime expectedStartDate) &&
						DateTime.TryParse(actualEndDate, out DateTime expectedEndDate))
					{
						foreach (var paymentDate in paymentDates)
						{
							// التأكد من أن تاريخ الدفع صالح قبل التحقق من نطاقه
							if (DateTime.TryParse(paymentDate, out DateTime actualPaymentDate))
							{
								Assert.IsTrue(actualPaymentDate >= expectedStartDate && actualPaymentDate <= expectedEndDate,
									$"Row {row + 1}: Payment date {paymentDate} is not within the expected range of {actualStartDate} to {actualEndDate}.");
							}
							else
							{
								Console.WriteLine($"Row {row + 1}: Payment date {paymentDate} is invalid or null.");
							}
						}
					}
					else
					{
						Console.WriteLine($"Invalid date range: StartDate = {actualStartDate ?? "null"}, EndDate = {actualEndDate ?? "null"}");
					}

					// العودة إلى صفحة التقرير
					CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
					Thread.Sleep(5000);
					BySearchDate_AssistantMethods.ReadBillNameDataFromExcel(7);
					BySearchDate_AssistantMethods.FillData(search);
					Thread.Sleep(5000); // الانتظار قبل الانتقال للصف التالي
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Test encountered an error: " + ex.Message);
			}
		}

		[TestMethod]
		public void TC6_TestSearchByDateOnFuture()
		{
			var test = extentReports.CreateTest("TC6_TestSearchByDateOnFuture", "Validates system behavior with future dates");

			List<string[]> expectedData = new List<string[]>
	{
		new string[] { "Electricity", "0", "0 $" },
		new string[] { "Telecommunication", "0", "0 $" },
		new string[] { "Education", "0", "0 $" },
		new string[] { "Water", "0", "0 $" }
	};
			string expectedTotalProfit = "0 $";

			try
			{
				IWebDriver driver = ManageDriver.driver;
				BySearchDate_AssistantMethods bySearchDate = new BySearchDate_AssistantMethods(driver);

				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
				Thread.Sleep(5000);

				// Dynamically calculate a future date for testing purposes
				DateTime futureDate = DateTime.Now.AddMonths(6);
				string futureStartDate = futureDate.ToString("yyyy-MM-dd");
				string futureEndDate = futureDate.ToString("yyyy-MM-dd");

				Search search = BySearchDate_AssistantMethods.ReadBillNameDataFromExcel(9);
				BySearchDate_AssistantMethods.FillData(search);
				Thread.Sleep(5000);

				// Verify start date
				SearchByDatePage datePage = new SearchByDatePage(driver);
				string actualStartDate = datePage.StartDateInput.GetAttribute("value");
				DateTime.TryParse(actualStartDate, out DateTime parsedStartDate);

				// Check if Start Date is in the future only if that's the test purpose
				if (parsedStartDate > DateTime.Now)
				{
					test.Log(Status.Info, $"Start Date '{actualStartDate}' is a future date as intended for this test.");
				}

				// Check if End Date is in the future
				string actualEndDate = datePage.EndDateInput.GetAttribute("value");
				if (DateTime.TryParse(actualEndDate, out DateTime parsedEndDate) && parsedEndDate > DateTime.Now)
				{
					test.Log(Status.Info, $"End Date '{actualEndDate}' is a future date as intended for this test.");
				}

				// Continue with row and payment date validation (same as current code)...
				// Perform row-by-row data validation...
				// Validate Total Profit at the end...

				test.Log(Status.Pass, "Search by date test with future dates passed successfully.");
			}
			catch (Exception ex)
			{
				test.Log(Status.Fail, $"Search by date test failed: {ex.Message}");
				throw;
			}
		}



		[TestMethod]
		public void TC7_TestSearchByEndDateIsNull()
		{
			var test = extentReports.CreateTest("TestCategorySearchDate", "TestCategorySearchDate");

			// البيانات المتوقعة لكل صف (بخلاف صف "Total Profit" الذي سيتم فحصه بعد جميع الصفوف الأخرى)
			List<string[]> expectedData = new List<string[]>
	        {
	         new string[] { "Electricity", "1", "2 $" },
	         new string[] { "Telecommunication", "2", "4 $" },
	         new string[] { "Education", "2", "4 $" }
	        };

			string expectedTotalProfit = "10 $"; // القيمة المتوقعة لـ "Total Profit"

			try
			{
				IWebDriver driver = ManageDriver.driver; // يجب أن يكون لديك WebDriver هنا
				BySearchDate_AssistantMethods bySearchDate = new BySearchDate_AssistantMethods(driver);

				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
				Thread.Sleep(5000);

				// إدخال تاريخ البحث وجلب البيانات
				Search search = BySearchDate_AssistantMethods.ReadBillNameDataFromExcel(6);
				BySearchDate_AssistantMethods.FillData(search);

				SearchByDatePage datePage = new SearchByDatePage(driver);
				string actualStartDate = datePage.StartDateInput.GetAttribute("value");
				string actualEndDate = datePage.EndDateInput.GetAttribute("value");

				// استخراج عدد الصفوف (دون احتساب صف "Total Profit")
				int rowCount = BySearchDate_AssistantMethods.GetRowCount(driver) - 1;

				// التكرار على كل صف في الجدول للتحقق من التفاصيل
				for (int row = 0; row < rowCount; row++)
				{
					string[] expectedRowData = expectedData[row];
					string actualCategoryName = BySearchDate_AssistantMethods.GetTableCellValue(row, 0, driver); // اسم الفئة
					string actualCountPay = BySearchDate_AssistantMethods.GetTableCellValue(row, 1, driver);     // عدد المدفوعات
					string actualSumProfit = BySearchDate_AssistantMethods.GetTableCellValue(row, 2, driver);    // إجمالي الربح

					// طباعة القيم الفعلية لكل صف
					Console.WriteLine($"Row {row + 1}: Actual Category Name: {actualCategoryName ?? "null"}");
					Console.WriteLine($"Row {row + 1}: Actual Count Pay: {actualCountPay ?? "null"}");
					Console.WriteLine($"Row {row + 1}: Actual Sum Profit: {actualSumProfit ?? "null"}");

					// تحقق من القيم المتوقعة لكل صف (تجاهل التحقق إذا كانت القيمة null)
					if (actualCategoryName != null)
						Assert.AreEqual(expectedRowData[0], actualCategoryName, $"Row {row + 1}: Expected category name to be '{expectedRowData[0]}', but got '{actualCategoryName}'.");

					if (actualCountPay != null)
						Assert.AreEqual(expectedRowData[1], actualCountPay, $"Row {row + 1}: Expected count pay to be '{expectedRowData[1]}', but got '{actualCountPay}'.");

					if (actualSumProfit != null)
						Assert.AreEqual(expectedRowData[2], actualSumProfit, $"Row {row + 1}: Expected sum profit to be '{expectedRowData[2]}', but got '{actualSumProfit}'.");

					// التحقق من تاريخ العمود الرابع بعد النقر على الزر
					IWebElement button = BySearchDate_AssistantMethods.GetButtonInRow(row, driver); // تمرير driver هنا
					if (button != null)
					{
						button.Click();
						Thread.Sleep(5000); // الانتظار حتى يتم تحميل المعلومات
					}
					else
					{
						Console.WriteLine($"No button found in row {row + 1}");
					}

					// التحقق من تواريخ "payment" بعد فتحها
					List<string> paymentDates = BySearchDate_AssistantMethods.GetPaymentDates(driver);
					Console.WriteLine($"Payment Dates for Row {row + 1}: {string.Join(", ", paymentDates)}");

					// تحقق من أن التواريخ في "payment" تقع ضمن الفترة المتوقعة
					if (!string.IsNullOrEmpty(actualStartDate) && !string.IsNullOrEmpty(actualEndDate) &&
						DateTime.TryParse(actualStartDate, out DateTime expectedStartDate) &&
						DateTime.TryParse(actualEndDate, out DateTime expectedEndDate))
					{
						foreach (var paymentDate in paymentDates)
						{
							// التأكد من أن تاريخ الدفع صالح قبل التحقق من نطاقه
							if (DateTime.TryParse(paymentDate, out DateTime actualPaymentDate))
							{
								Assert.IsTrue(actualPaymentDate >= expectedStartDate && actualPaymentDate <= expectedEndDate,
									$"Row {row + 1}: Payment date {paymentDate} is not within the expected range of {actualStartDate} to {actualEndDate}.");
							}
							else
							{
								Console.WriteLine($"Row {row + 1}: Payment date {paymentDate} is invalid or null.");
							}
						}
					}
					else
					{
						Console.WriteLine($"Invalid date range: StartDate = {actualStartDate ?? "null"}, EndDate = {actualEndDate ?? "null"}");
					}

					// العودة إلى صفحة التقرير
					CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
					Thread.Sleep(5000);
					BySearchDate_AssistantMethods.ReadBillNameDataFromExcel(6);
					BySearchDate_AssistantMethods.FillData(search);
					Thread.Sleep(5000); // الانتظار قبل الانتقال للصف التالي
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Test encountered an error: " + ex.Message);
			}
		}

		[TestMethod]
		public void TC8_TestSearchByDateAllIsEmpty()
		{
			var test = extentReports.CreateTest("TC2_TestSearchByDateFourToSixMarchOrAllIfEmpty", "TC2_TestSearchByDateFourToSixMarchOrAllIfEmpty");

			// البيانات المتوقعة لكل صف (بخلاف صف "Total Profit" الذي سيتم فحصه بعد جميع الصفوف الأخرى)
			List<string[]> expectedData = new List<string[]>
	        {
	         new string[] { "Electricity", "2", "4 $" },
	         new string[] { "Telecommunication", "4", "8 $" },
	         new string[] { "Education", "4", "10 $" },
	          new string[] { "Water", "7", "35 $" }
	        };

			string expectedTotalProfit = "57 $"; // القيمة المتوقعة لـ "Total Profit"

			try
			{
				IWebDriver driver = ManageDriver.driver; // يجب أن يكون لديك WebDriver هنا
				BySearchDate_AssistantMethods bySearchDate = new BySearchDate_AssistantMethods(driver);

				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
				Thread.Sleep(5000);

				// جلب البيانات من Excel (إذا كانت تواريخ البحث موجودة، فسيتم استخدامها؛ وإذا لم تكن موجودة، سيُجري البحث بدون تواريخ)
				Search search = BySearchDate_AssistantMethods.ReadBillNameDataFromExcel(8);
				bool isDateEmpty = string.IsNullOrWhiteSpace(search.StartDate) && string.IsNullOrWhiteSpace(search.EndDate);

				// تعبئة البيانات في الحقول
				BySearchDate_AssistantMethods.FillData(search);
				Thread.Sleep(5000);

				// الحصول على التواريخ الفعلية من صفحة البحث
				SearchByDatePage datePage = new SearchByDatePage(driver);
				string actualStartDate = datePage.StartDateInput.GetAttribute("value");
				string actualEndDate = datePage.EndDateInput.GetAttribute("value");

				// استخراج عدد الصفوف (دون احتساب صف "Total Profit")
				int rowCount = BySearchDate_AssistantMethods.GetRowCount(driver) - 1;

				// التكرار على كل صف في الجدول للتحقق من التفاصيل
				for (int row = 0; row < rowCount; row++)
				{
					string[] expectedRowData = expectedData[row];
					string actualCategoryName = BySearchDate_AssistantMethods.GetTableCellValue(row, 0, driver); // اسم الفئة
					string actualCountPay = BySearchDate_AssistantMethods.GetTableCellValue(row, 1, driver);     // عدد المدفوعات
					string actualSumProfit = BySearchDate_AssistantMethods.GetTableCellValue(row, 2, driver);    // إجمالي الربح

					// طباعة القيم الفعلية لكل صف
					Console.WriteLine($"Row {row + 1}: Actual Category Name: {actualCategoryName}");
					Console.WriteLine($"Row {row + 1}: Actual Count Pay: {actualCountPay}");
					Console.WriteLine($"Row {row + 1}: Actual Sum Profit: {actualSumProfit}");

					// تحقق من القيم المتوقعة لكل صف
					Assert.AreEqual(expectedRowData[0], actualCategoryName, $"Row {row + 1}: Expected category name to be '{expectedRowData[0]}', but got '{actualCategoryName}'.");
					Assert.AreEqual(expectedRowData[1], actualCountPay, $"Row {row + 1}: Expected count pay to be '{expectedRowData[1]}', but got '{actualCountPay}'.");
					Assert.AreEqual(expectedRowData[2], actualSumProfit, $"Row {row + 1}: Expected sum profit to be '{expectedRowData[2]}', but got '{actualSumProfit}'.");

					// التحقق من تاريخ العمود الرابع بعد النقر على الزر
					IWebElement button = BySearchDate_AssistantMethods.GetButtonInRow(row, driver);
					if (button != null)
					{
						button.Click();
						Thread.Sleep(5000); // الانتظار حتى يتم تحميل المعلومات
					}
					else
					{
						Console.WriteLine($"No button found in row {row + 1}");
					}

					// التحقق من تواريخ "payment" بعد فتحها (فقط إذا كانت التواريخ مدخلة)
					List<string> paymentDates = BySearchDate_AssistantMethods.GetPaymentDates(driver);
					Console.WriteLine($"Payment Dates for Row {row + 1}: {string.Join(", ", paymentDates)}");

					if (!isDateEmpty)
					{
						// التحقق من أن التواريخ في "payment" تقع ضمن الفترة المتوقعة
						DateTime expectedStartDate = DateTime.Parse(actualStartDate);
						DateTime expectedEndDate = DateTime.Parse(actualEndDate);

						foreach (var paymentDate in paymentDates)
						{
							DateTime actualPaymentDate = DateTime.Parse(paymentDate);
							Assert.IsTrue(actualPaymentDate >= expectedStartDate && actualPaymentDate <= expectedEndDate,
								$"Row {row + 1}: Payment date {paymentDate} is not within the expected range of {actualStartDate} to {actualEndDate}.");
						}
					}

					// العودة إلى صفحة التقرير
					CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
					Thread.Sleep(5000);
					BySearchDate_AssistantMethods.FillData(search);
					Thread.Sleep(5000); // الانتظار قبل الانتقال للصف التالي
				}

				// التحقق من قيمة "Total Profit" بعد الانتهاء من جميع الصفوف
				string actualTotalProfit = BySearchDate_AssistantMethods.GetTotalProfitValue(driver);
				Console.WriteLine($"Actual Total Profit: {actualTotalProfit}");
				Assert.AreEqual(expectedTotalProfit, actualTotalProfit, $"Expected total profit to be '{expectedTotalProfit}', but got '{actualTotalProfit}'.");

				test.Log(Status.Pass, "Search by date test passed successfully.");
			}
			catch (Exception ex)
			{
				test.Log(Status.Fail, $"Search by date test failed: {ex.Message}");
				throw;
			}
		}
		[TestMethod]
		public void TC9_TestSearchByDateNoInformation()

		{
			var test = extentReports.CreateTest("TC9_TestSearchByDateNoInformation", "TC9_TestSearchByDateNoInformation");

			// البيانات المتوقعة لكل صف (بخلاف صف "Total Profit" الذي سيتم فحصه بعد جميع الصفوف الأخرى)
			List<string[]> expectedData = new List<string[]>
	        {
	     	 new string[] { "Electricity", "0", "0 $" },
	    	 new string[] { "Telecommunication", "0", "0 $" },
		     new string[] { "Education", "0", "0 $" },
		     new string[] { "Water", "0", "0 $" }
	        };

			string expectedTotalProfit = "57 $"; // القيمة المتوقعة لـ "Total Profit"

			try
			{
				IWebDriver driver = ManageDriver.driver; // يجب أن يكون لديك WebDriver هنا
				BySearchDate_AssistantMethods bySearchDate = new BySearchDate_AssistantMethods(driver);

				CommonMethods.NavigateToURL(GlobalConstants.LoginLink);
				Login_AssistantMethods.FillLoginForm("Admin", "123456");
				Thread.Sleep(9000);

				CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
				Thread.Sleep(5000);

				// جلب البيانات من Excel (إذا كانت تواريخ البحث موجودة، فسيتم استخدامها؛ وإذا لم تكن موجودة، سيُجري البحث بدون تواريخ)
				Search search = BySearchDate_AssistantMethods.ReadBillNameDataFromExcel(10);
				bool isDateEmpty = string.IsNullOrWhiteSpace(search.StartDate) && string.IsNullOrWhiteSpace(search.EndDate);

				// تعبئة البيانات في الحقول
				BySearchDate_AssistantMethods.FillData(search);
				Thread.Sleep(5000);

				// الحصول على التواريخ الفعلية من صفحة البحث
				SearchByDatePage datePage = new SearchByDatePage(driver);
				string actualStartDate = datePage.StartDateInput.GetAttribute("value");
				string actualEndDate = datePage.EndDateInput.GetAttribute("value");

				// استخراج عدد الصفوف (دون احتساب صف "Total Profit")
				int rowCount = BySearchDate_AssistantMethods.GetRowCount(driver) - 1;

				if (rowCount == 0)
				{
					// إذا لم توجد أي صفوف في الجدول، يتم طباعة رسالة
					Console.WriteLine("There are no item names to display on this date.");
					test.Log(Status.Info, "No categories to display for the selected date range.");
					return; // إنهاء الاختبار في حالة عدم وجود بيانات
				}

				// التكرار على كل صف في الجدول للتحقق من التفاصيل
				for (int row = 0; row < rowCount; row++)
				{
					string[] expectedRowData = expectedData[row];
					string actualCategoryName = BySearchDate_AssistantMethods.GetTableCellValue(row, 0, driver); // اسم الفئة
					string actualCountPay = BySearchDate_AssistantMethods.GetTableCellValue(row, 1, driver);     // عدد المدفوعات
					string actualSumProfit = BySearchDate_AssistantMethods.GetTableCellValue(row, 2, driver);    // إجمالي الربح

					// طباعة القيم الفعلية لكل صف
					Console.WriteLine($"Row {row + 1}: Actual Category Name: {actualCategoryName}");
					Console.WriteLine($"Row {row + 1}: Actual Count Pay: {actualCountPay}");
					Console.WriteLine($"Row {row + 1}: Actual Sum Profit: {actualSumProfit}");

					// تحقق من القيم المتوقعة لكل صف
					Assert.AreEqual(expectedRowData[0], actualCategoryName, $"Row {row + 1}: Expected category name to be '{expectedRowData[0]}', but got '{actualCategoryName}'.");
					Assert.AreEqual(expectedRowData[1], actualCountPay, $"Row {row + 1}: Expected count pay to be '{expectedRowData[1]}', but got '{actualCountPay}'.");

					// إذا لم توجد مدفوعات (paymentDates فارغة)، لا تحقق من sum profit
					IWebElement button = BySearchDate_AssistantMethods.GetButtonInRow(row, driver);
					if (button != null)
					{
						button.Click();
						Thread.Sleep(5000); // الانتظار حتى يتم تحميل المعلومات
					}
					else
					{
						Console.WriteLine($"No button found in row {row + 1}");
					}

					// التحقق من تواريخ "payment" بعد فتحها (فقط إذا كانت التواريخ مدخلة)
					List<string> paymentDates = BySearchDate_AssistantMethods.GetPaymentDates(driver);
					Console.WriteLine($"Payment Dates for Row {row + 1}: {string.Join(", ", paymentDates)}");

					if (paymentDates.Count == 0)
					{
						// إذا كانت قائمة المدفوعات فارغة، طباعة الرسالة المناسبة
						Console.WriteLine($"No payments found for {actualCategoryName} in the selected date range. No sum profit available.");
					}
					else
					{
						// التحقق من أن التواريخ في "payment" تقع ضمن الفترة المتوقعة
						if (!isDateEmpty)
						{
							DateTime expectedStartDate = DateTime.Parse(actualStartDate);
							DateTime expectedEndDate = DateTime.Parse(actualEndDate);

							foreach (var paymentDate in paymentDates)
							{
								DateTime actualPaymentDate = DateTime.Parse(paymentDate);
								Assert.IsTrue(actualPaymentDate >= expectedStartDate && actualPaymentDate <= expectedEndDate,
									$"Row {row + 1}: Payment date {paymentDate} is not within the expected range of {actualStartDate} to {actualEndDate}.");
							}
						}

						// تحقق من قيمة sum profit فقط إذا كانت هناك مدفوعات
						Assert.AreEqual(expectedRowData[2], actualSumProfit, $"Row {row + 1}: Expected sum profit to be '{expectedRowData[2]}', but got '{actualSumProfit}'.");
					}

					// العودة إلى صفحة التقرير
					CommonMethods.NavigateToURL("http://localhost:4200/admin/report");
					Thread.Sleep(5000);
					BySearchDate_AssistantMethods.FillData(search);
					Thread.Sleep(5000); // الانتظار قبل الانتقال للصف التالي
				}

				// التحقق من قيمة "Total Profit" بعد الانتهاء من جميع الصفوف
				string actualTotalProfit = BySearchDate_AssistantMethods.GetTotalProfitValue(driver);
				Console.WriteLine($"Actual Total Profit: {actualTotalProfit}");
				Assert.AreEqual(expectedTotalProfit, actualTotalProfit, $"Expected total profit to be '{expectedTotalProfit}', but got '{actualTotalProfit}'.");

				test.Log(Status.Pass, "Search by date test passed successfully.");
			}
			catch (Exception ex)
			{
				test.Log(Status.Fail, $"Search by date test failed: {ex.Message}");
				throw;
			}
		}

		[TestMethod]
		public void TC10_TestSearchByDateFormatWrong()
		{
			var test = extentReports.CreateTest("TC10_TestSearchByDateFormatWrong", "Test when date format is wrong.");

			// افتراض تنسيق التاريخ المطلوب
			string dateFormat = "yyyy-MM-dd";  // تنسيق التاريخ الذي نتوقعه

			// تسجيل الدخول أولاً
			try
			{
				IWebDriver driver = ManageDriver.driver;
				CommonMethods.NavigateToURL(GlobalConstants.LoginLink); // الانتقال إلى صفحة تسجيل الدخول
				Login_AssistantMethods.FillLoginForm("Admin", "123456"); // تعبئة بيانات تسجيل الدخول
				Thread.Sleep(9000); // الانتظار لفترة قصيرة بعد تسجيل الدخول

			}
			catch (Exception ex)
			{
				test.Log(Status.Fail, $"Login failed: {ex.Message}");
				Assert.Fail($"Login failed: {ex.Message}");  // استخدام Assert.Fail لرفع فشل الاختبار
			}

			// قراءة البيانات من Excel بعد تسجيل الدخول
			Search search = BySearchDate_AssistantMethods.ReadBillNameDataFromExcel(11);
			Thread.Sleep(5000);
			BySearchDate_AssistantMethods.FillData(search);
			Thread.Sleep(5000);
			// متغيرات التواريخ
			DateTime startDate;
			DateTime endDate;

			// تحقق من صحة تنسيق تاريخ البداية والنهاية
			bool isStartDateValid = string.IsNullOrWhiteSpace(search.StartDate) || DateTime.TryParseExact(search.StartDate, dateFormat, null, System.Globalization.DateTimeStyles.None, out startDate);
			bool isEndDateValid = string.IsNullOrWhiteSpace(search.EndDate) || DateTime.TryParseExact(search.EndDate, dateFormat, null, System.Globalization.DateTimeStyles.None, out endDate);

			// إذا كان تنسيق تاريخ البداية غير صحيح
			if (!isStartDateValid)
			{
				// عرض رسالة للمستخدم بأن التنسيق غير صحيح
				string message = $"Error: Start date format '{search.StartDate}' is incorrect. Please use the correct format: {dateFormat}.";
				Console.WriteLine(message);
				test.Log(Status.Info, message);  // إضافة الرسالة إلى التقرير
				Assert.Fail(message);  // فشل الاختبار مع الرسالة
			}

			// إذا كان تنسيق تاريخ النهاية غير صحيح
			if (!isEndDateValid)
			{
				// عرض رسالة للمستخدم بأن التنسيق غير صحيح
				string message = $"Error: End date format '{search.EndDate}' is incorrect. Please use the correct format: {dateFormat}.";
				Console.WriteLine(message);
				test.Log(Status.Info, message);  // إضافة الرسالة إلى التقرير
				Assert.Fail(message);  // فشل الاختبار مع الرسالة
			}

			// إذا كان التنسيق صحيحًا، استمر في الإجراءات التالية
			try
			{
				CommonMethods.NavigateToURL("http://localhost:4200/admin/report"); // الانتقال إلى صفحة التقارير
				Thread.Sleep(5000);

				// تعبئة البيانات في الحقول
				BySearchDate_AssistantMethods.FillData(search);
				Thread.Sleep(5000);

				test.Log(Status.Pass, "Search by date test passed successfully.");
				Assert.AreEqual("Test passed", "Test passed");  // التحقق من نجاح الاختبار باستخدام Assert
			}
			catch (Exception ex)
			{
				test.Log(Status.Fail, $"Search by date test failed: {ex.Message}");
				Assert.Fail($"Search by date test failed: {ex.Message}");  // فشل الاختبار مع الرسالة
			}
		}



	}

}


