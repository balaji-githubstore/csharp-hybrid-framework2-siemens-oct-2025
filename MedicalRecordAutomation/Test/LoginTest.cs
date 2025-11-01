using MedicalRecordAutomation.Base;
using MedicalRecordAutomation.Pages;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalRecordAutomation.Test
{
    public class LoginTest : AutomationWrapper
    {
        [Test,Category("regression"),Category("sanity")]
        public void ValidLoginTest()
        {
           LoginPage login=new LoginPage(driver);
           login.LoginIntoSystem("","");

        }
    }
}
