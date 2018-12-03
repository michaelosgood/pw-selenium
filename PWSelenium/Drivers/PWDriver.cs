using PrescribeWellness.Reports;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenio.Core.SUT;
using Selenio.HtmlReporter;
using System.Diagnostics;
using PrescribeWellness.Page;

namespace PrescribeWellness.Driver
{
    public class PWDriver : SUTDriver 
    {
        
        public static void Initialize<T>() where T : IWebDriver
        {   string assemblyLocation = TestContext.CurrentContext.TestDirectory;
            string methodName = TestContext.CurrentContext.Test.MethodName;
            string className = TestContext.CurrentContext.Test.ClassName;
            string[] browsers = { "chrome", "firefox", "iexplore", "MicrosoftEdge" };

            foreach (string b in browsers)
            { Process[] localByName = Process.GetProcessesByName(b);

                foreach (Process item in localByName)
                {
                    item.Kill();
                }

            }
            
            InitDriver<T>(new Reporter(new ReportSettingsProvider(), assemblyLocation, className, methodName));
           
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Manage().Window.Maximize();
        }
        
        #region PrescrbeWellness.com Pages

        public static BusinessPage BusinessPage => GetPage<BusinessPage>();

        public static Contact Contact => GetPage<Contact>();







        #endregion PW Pages

        




    }
}
