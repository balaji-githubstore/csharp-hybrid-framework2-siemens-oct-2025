using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.Extensions.Configuration;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalRecordAutomation.Base
{
    public class AutomationWrapper
    {
        protected IWebDriver driver;
        protected BrowserSettings browserSettings;
        private static ExtentReports extent;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void Init()
        {
            if (extent == null)
            {
                extent = new ExtentReports();
                var spark = new ExtentSparkReporter("Spark.html");
                extent.AttachReporter(spark);
            }
        }

        [OneTimeTearDown]
        public void End()
        {
            extent.Flush();
        }


        public void LoadAppSettings()
        {
            var config = new ConfigurationBuilder()
                  .SetBasePath(AppContext.BaseDirectory)
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                  .Build();

            browserSettings = config.GetSection("BrowserSettings").Get<BrowserSettings>();
        }

        [SetUp]
        public void BeforeTestMethod()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

            LoadAppSettings();

            if (browserSettings.BrowserName.ToLower().Equals("ff"))
            {
                driver = new FirefoxDriver();
            }
            else if (browserSettings.BrowserName.ToLower().Equals("edge"))
            {
                EdgeOptions options = new EdgeOptions();
                options.BinaryLocation = browserSettings.EdgeBinaryLocation;

                driver = new EdgeDriver(options);
            }

            else
            {
                ChromeOptions options = new ChromeOptions();
                options.BinaryLocation = browserSettings.ChromeBinaryLocation;

                driver = new ChromeDriver(options);
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(browserSettings.TimeOut);
            driver.Navigate().GoToUrl(browserSettings.BaseUrl);
        }

        [TearDown]
        public void AfterTestMethod()
        {
            string testName = TestContext.CurrentContext.Test.Name;
            TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == TestStatus.Failed)
            {
                var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                var errorMessage = TestContext.CurrentContext.Result.Message;

                test.Log(Status.Fail, stackTrace + errorMessage);

                Screenshot sc = driver.TakeScreenshot();
                test.AddScreenCaptureFromBase64String(sc.AsBase64EncodedString, testName + " failed");

            }
            else if (status == TestStatus.Passed)
            {
                test.Log(Status.Pass, "Passed");
            }
            else if (status == TestStatus.Skipped)
            {
                test.Log(Status.Skip, "Skipped - " + testName);
            }

            //check current [Test] pass or fail and log it
            driver.Dispose();
        }
    }
}
