using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalRecordAutomation.Test
{
    public class Demo1Extent
    {

        [Test]
        public void DemoExtentReport()
        {
            //only once in the beginning [OneTimeSetup]
            var extent = new ExtentReports();
            var spark = new ExtentSparkReporter("Spark.html");
            extent.AttachReporter(spark);

            //create a test -->[Setup] 
            ExtentTest test = extent.CreateTest("MyFirstTestIiudsiuidsiu");

            test.Log(Status.Info, "Entered username!!");

            //after each test ==> [TearDown]
            test.Log(Status.Fail, "This is a logging event for MyFirstTest, and it passed!");



            //publish the report --> [OneTimeTearDown]
            extent.Flush();

        }
    }
}
