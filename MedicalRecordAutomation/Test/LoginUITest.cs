using AventStack.ExtentReports;
using DocumentFormat.OpenXml.Bibliography;
using MedicalRecordAutomation.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalRecordAutomation.Test
{
    public class LoginUITest : AutomationWrapper
    {
        [Test,Category("smoke")]
        public void TitleTest()
        {
            test.Log(Status.Info, "Title is " + driver.Title);
            Assert.That(driver.Title, Is.EqualTo("OpenEMR Login123"));
        }

        [Test,Category("regression")]
        public void PlaceholderTest()
        {
            var actualUsername= driver.FindElement(By.Id("authUser")).GetAttribute("placeholder");

            Assert.That(actualUsername, Is.EqualTo("Username"));
        }
    }
}
