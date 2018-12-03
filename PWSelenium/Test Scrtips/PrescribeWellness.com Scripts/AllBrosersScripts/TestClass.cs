using System;
using PrescribeWellness;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using Selenio.Core.Reporting;
using PrescribeWellness.Support;
using PrescribeWellness.Driver;

namespace PrescribeWellness.Scrtip
{
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(EdgeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    public class TestClass<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        public IReporter Reporter;

        [SetUp]
        public void Setup()
        {
            PWDriver.Initialize<TWebDriver>();
            Reporter = PWDriver.Reporter;
        }

        [Test]
        public void SanityPW()
        {
            Reporter.TestDescription = "Validate Business Sign In Page";

            Reporter.TestStep = "Go to Business Sign In Page";
            PWDriver.BusinessPage.Open(AutoConfig.PWBusinessPage);

            Reporter.TestStep = "Validate PWLogo is present";
            Assert.AreEqual(true, PWDriver.BusinessPage.PWLogo.Displayed, "PWLogo is not in display.");

            Reporter.TestStep = "Validate PageImage is present";
            Assert.AreEqual(true, PWDriver.BusinessPage.PageImage.Displayed, "PageImage is not in display.");

            Reporter.TestStep = "Validate Solution Tab is present and enabled";
            Assert.AreEqual(true, PWDriver.BusinessPage.SolutionTab.Displayed, "SolutionTab is not in display.");
            Assert.AreEqual(true, PWDriver.BusinessPage.SolutionTab.Enabled, "SolutionTab is not in display.");

            Reporter.TestStep = "Validate Company Tab is present and enabled";
            Assert.AreEqual(true, PWDriver.BusinessPage.CompanyTab.Displayed, "CompanyTab is not in display.");
            Assert.AreEqual(true, PWDriver.BusinessPage.CompanyTab.Enabled, "CompanyTab is not in display.");

            Reporter.TestStep = "Validate Contact Tab is present and enabled";
            Assert.AreEqual(true, PWDriver.BusinessPage.ContactTab.Displayed, "ContactTab is not in display.");
            Assert.AreEqual(true, PWDriver.BusinessPage.ContactTab.Enabled, "ContactTab is not in display.");

            Reporter.TestStep = "Validate Blog Tab is present and enabled";
            Assert.AreEqual(true, PWDriver.BusinessPage.BlogTab.Displayed, "BlogTab is not in display.");
            Assert.AreEqual(true, PWDriver.BusinessPage.BlogTab.Enabled, "BlogTab is not in display.");

            Reporter.TestStep = "Validate SignIn Tab is present and enabled";
            Assert.AreEqual(true, PWDriver.BusinessPage.SignInTab.Displayed, "SignInTab is not in display.");
            Assert.AreEqual(true, PWDriver.BusinessPage.SignInTab.Enabled, "SignInTab is not in display.");

            Reporter.TestStep = "Click SignIn Tab";
            PWDriver.BusinessPage.SignInTab.Click();
        }

        [Test]
       

        [TearDown]
        public void Teardown()
        {
            PWDriver.Reporter.FinishTest(TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed, TestContext.CurrentContext.Result.Message);
            PWDriver.Driver?.Quit();
        }
    }

}