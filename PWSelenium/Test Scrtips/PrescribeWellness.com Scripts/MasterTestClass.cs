using PrescribeWellness;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using Selenio.Core.Reporting;
using PrescribeWellness;
using PrescribeWellness.Driver;

namespace PrescribeWellness
{
    [TestFixture]
    public class MasterTestClass
    {
        public IReporter Reporter;


        [SetUp]
        public void Setup()
        {
            PWDriver.Initialize<ChromeDriver>();
            Reporter = PWDriver.Reporter;
        }

        [TearDown]
        public void Teardown()
        {
            PWDriver.Reporter.FinishTest(TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed, TestContext.CurrentContext.Result.Message);
            PWDriver.Driver?.Quit();
        }
    }
}
