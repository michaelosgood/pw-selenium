using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace KinectaSelenium.Support
{
    public static class Helpers
    {
        public static void SelectItem(this IWebElement element, string text)
        {
            new SelectElement(element).SelectByText(text);
        }

        public static string SelectURL(string url)
        {
            switch (url)
            {
                case "QA":
                    return AutoConfig.QA;
                case "STAGE":
                    return AutoConfig.STAGE;
                case "PROD":
                    return AutoConfig.PROD;
                default:
                    return "";
            }
        }
    }
}
