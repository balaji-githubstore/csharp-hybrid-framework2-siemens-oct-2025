using MedicalRecordAutomation.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalRecordAutomation.Pages
{
    public class LoginPage
    {

        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void LoginIntoSystem(string username, string password)
        {
            _driver.FindElement(By.Id("username")).SendKeys(username);
            _driver.FindElement(By.Id("username")).SendKeys(password);
            _driver.FindElement(By.Id("username")).Click();
        }
    }
}
